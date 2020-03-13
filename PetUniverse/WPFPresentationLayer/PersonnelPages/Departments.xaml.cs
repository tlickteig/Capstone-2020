﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayerInterfaces;
using DataTransferObjects;
using LogicLayer;
using PresentationUtilityCode;

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 2/13/2020
    /// Approver: Alex Diers
    /// 
    /// Interaction logic for Departments.xaml    
    /// <summary>
    public partial class Departments : Page
    {
        private IDepartmentManager _departmentManager;
        private Department _department;

        public Departments()
        {
            InitializeComponent();
            _departmentManager = new DepartmentManager();
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/13/2020
        /// Approver: Alex Diers
        /// 
        /// This is a method for add department click.
        /// </summ/ary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            canDepartmentList.Visibility = Visibility.Hidden;
            canAddDepartment.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/13/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method to try to safely retrieve data for departments.
        /// </summ/ary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void showDGDepartments()
        {
            try
            {

                dgDepartment.ItemsSource = _departmentManager.RetrieveAllDepartments();
                dgDepartment.IsReadOnly = true;

            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage("Data not found. " + ex.InnerException);
            }
        }



        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method for setting the column width.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDepartment_AutoGeneratedColumns(object sender, EventArgs e)
        {
            foreach (var col in dgDepartment.Columns)
            {
                col.Width = 500;
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is the method fills a data grid.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDepartment_Loaded(object sender, RoutedEventArgs e)
        {
            showDGDepartments();
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This button click listener sends the data for creating a new department record to the logic layer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDepartmentSave_Click(object sender, RoutedEventArgs e)
        {
            string departmentID = txtAddDepartmentDepartmentName.Text;
            string description = txtAddDepartmentDescription.Text;
            if (ValidateERole.checkDepartmentID(departmentID) && ValidateERole.checkDescription(description))
                try
                {
                    if (_departmentManager.AddDepartment(departmentID, description))
                    {
                        WPFErrorHandler.SuccessMessage("Department added.");
                        canAddDepartment.Visibility = Visibility.Hidden;
                        canDepartmentList.Visibility = Visibility.Visible;
                        showDGDepartments();
                    } 
                    else
                    {
                        WPFErrorHandler.ErrorMessage("Department not added.");
                    }
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage("Department failed to save. " + ex.Message);
                }
                finally
                {
                    txtAddDepartmentDepartmentName.Text = "";
                    txtAddDepartmentDescription.Text = "";
                }
            

            else
            {
                WPFErrorHandler.ErrorMessage("Department failed to save.");
            }
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This method hides the canvas.
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: 2/26/2020
        /// Update: Clears text box.
        /// Approver: Alex Diers
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDepartmentCancel_Click(object sender, RoutedEventArgs e)
        {
            canAddDepartment.Visibility = Visibility.Hidden;
            txtAddDepartmentDepartmentName.Text = "";
            txtAddDepartmentDescription.Text = "";
            canDepartmentList.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is a method for edit department click.
        /// </summ/ary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void btnEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (!dgDepartment.SelectedIndex.Equals(-1))
            {
                try
                {
                    _department = (Department)dgDepartment.SelectedItem;


                    lblEditDepartmentDepartmentName.Content = _department.DepartmentID;
                    txtEditDepartmentOldDescription.Text = _department.Description;

                    canDepartmentList.Visibility = Visibility.Hidden;
                    canEditDepartment.Visibility = Visibility.Visible;

                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage("Edit failed. " + ex.InnerException);
                }
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Please select a department to Edit.");
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is a method for clicking save.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string newDescription = txtEditDepartmentDescription.Text;

            try
            {
                bool result = _departmentManager.EditDepartment(_department, new Department
                {
                    DepartmentID = _department.DepartmentID,
                    Description = newDescription
                });

                if (result)
                {
                    WPFErrorHandler.SuccessMessage("The changes were successfully made.");
                    txtEditDepartmentDescription.Text = "";
                    canEditDepartment.Visibility = Visibility.Hidden;
                    canDepartmentList.Visibility = Visibility.Visible;
                    showDGDepartments();
                }
                else
                {
                    WPFErrorHandler.ErrorMessage("Your changes were not made.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage("Unable to save. " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/15/2020
        /// Approver: Alex Diers
        /// 
        /// This is a method for clicking cancel.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditDepartmentCancel_Click(object sender, RoutedEventArgs e)
        {
            txtEditDepartmentDescription.Text = "";
            canEditDepartment.Visibility = Visibility.Hidden;
            canDepartmentList.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 2/29/2020
        /// Approver: Alex Diers
        /// 
        /// This is a method for clicking cancel.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (!dgDepartment.SelectedIndex.Equals(-1))
            {
                try
                {
                    _department = (Department)dgDepartment.SelectedItem;
                    if (_departmentManager.EditDepartmentActive(_department.DepartmentID, false))
                    {
                        showDGDepartments();
                        WPFErrorHandler.SuccessMessage("Department Removed");
                    }

                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage("Removal failed. " + ex.InnerException);
                }
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Please select a department to Remove.");
            }
        }
    }
}

