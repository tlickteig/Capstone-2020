﻿using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFPresentationLayer.AMPages
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Interaction logic for frmanimals.xaml
    /// </summary>
    public partial class AnimalControls : Page
    {


        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/20/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// constructor for animal controls
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalControls()
        {
            InitializeComponent();
            _animalManager = new AnimalManager();
            cmbAnimalSpecies.ItemsSource = _animalManager.RetrieveAnimalSpecies();
        }

        private IAnimalManager _animalManager;
        private Animal selectedAnimal;

        private AnimalNames an;



        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// opens the add animal canvas
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            canAddAnimal.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// When the window is loaded the data grid is also loaded with its info
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refreshActiveData();
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// The method that calls the manager method to get the active data for the data grid
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 3/6/2020
        /// Update: Corrected the data grid column headers
        /// Approver: Carl Davis, 3/6/2020
        /// </remarks>
        private void refreshActiveData()
        {
            dgActiveAnimals.ItemsSource = _animalManager.RetrieveAnimalsByActive();


            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[0]);
            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[9]);
            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[8]);


            dgActiveAnimals.Columns[0].Header = "Name";
            dgActiveAnimals.Columns[1].Header = "Date of Birth";
            dgActiveAnimals.Columns[2].Header = "Breed";
            dgActiveAnimals.Columns[3].Header = "Arrival Date";
            dgActiveAnimals.Columns[4].Header = "Currently Housed";
            dgActiveAnimals.Columns[7].Header = "Species";

        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The method that calls the manager method to get the inactive data for the data grid
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 3/6/2020
        /// Update: Corrected the data grid column headers
        /// Approver: Carl Davis, 3/6/2020
        /// </remarks>
        private void refreshInactiveData()
        {
            dgActiveAnimals.ItemsSource = _animalManager.RetrieveAnimalsByInactive();

            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[0]);
            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[9]);
            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[8]);


            dgActiveAnimals.Columns[0].Header = "Name";
            dgActiveAnimals.Columns[1].Header = "Date of Birth";
            dgActiveAnimals.Columns[2].Header = "Breed";
            dgActiveAnimals.Columns[3].Header = "Arrival Date";
            dgActiveAnimals.Columns[4].Header = "Currently Housed";
            dgActiveAnimals.Columns[7].Header = "Species";
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The method that checks if the check box is checked or not and will call the correct
        /// method to supply the data grid with the correct data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void chkActive_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)chkActive.IsChecked)
            {
                refreshInactiveData();
            }
            else
            {
                refreshActiveData();
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The method opens the add animal canvas
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status and image location
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSubmitAnimalAdd_Click(object sender, RoutedEventArgs e)
        {
            string arrival = cndArrivalDate.SelectedDate.ToString();
            string dob = cndDob.SelectedDate.ToString();
            if (String.IsNullOrEmpty(txtAnimalName.Text))
            {
                MessageBox.Show("Please enter the animal's name");
                return;
            }
            if (String.IsNullOrEmpty(txtAnimalBreed.Text))
            {
                MessageBox.Show("Please enter the animal's breed");
                return;
            }
            if (String.IsNullOrEmpty(cmbAnimalSpecies.Text))
            {
                MessageBox.Show("Please enter the animal's species");
                return;
            }
            if (String.IsNullOrEmpty(arrival))
            {
                MessageBox.Show("Please enter the animal's arrival date");
                return;
            }
            if (String.IsNullOrEmpty(dob))
            {
                cndDob.SelectedDate = DateTime.Parse("01/01/2000");
                return;
            }

            Animal newAnimal = new Animal();

            newAnimal.AnimalName = txtAnimalName.Text;
            newAnimal.AnimalSpeciesID = cmbAnimalSpecies.Text;
            newAnimal.AnimalBreed = txtAnimalBreed.Text;
            newAnimal.ArrivalDate = (DateTime)cndArrivalDate.SelectedDate;
            newAnimal.Dob = (DateTime)cndDob.SelectedDate;

            try
            {
                if (_animalManager.AddNewAnimal(newAnimal))
                {
                    WPFErrorHandler.SuccessMessage("Animal Successfully Added");

                    canViewAnimalList.Visibility = Visibility.Visible;
                    canAddAnimal.Visibility = Visibility.Hidden;
                    refreshActiveData();
                    chkActive.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                canViewAnimalList.Visibility = Visibility.Visible;
                canAddAnimal.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The method that cancels the add animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnCancelAnimalAdd_Click(object sender, RoutedEventArgs e)
        {
            canViewAnimalList.Visibility = Visibility.Visible;
            canAddAnimal.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/3/2020
        /// Approver: Jaeho Kim, 3/3/2020
        /// Approver: 
        /// 
        /// The method that will open a new canvas with the selected animal's information on it
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgActiveAnimals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ACE.Visibility = Visibility.Hidden;
            SearchBar_.Visibility = Visibility.Hidden;
            DG.Visibility = Visibility.Hidden;
            try
            {
                selectedAnimal = (Animal)dgActiveAnimals.SelectedItem;

                lblIndividualAnimalName.Content = selectedAnimal.AnimalName;
                lblIndividualAnimalID.Content = selectedAnimal.AnimalID;
                lblIndividualAnimalSpecies.Content = selectedAnimal.AnimalSpeciesID;
                lblIndividualAnimalBreed.Content = selectedAnimal.AnimalBreed;
                lblIndividualAnimalDob.Content = selectedAnimal.Dob;
                lblIndividualAnimalArrivalDate.Content = selectedAnimal.ArrivalDate;
                chkIndvidualActive.IsChecked = selectedAnimal.Active;
                chkIndvidualAdoptable.IsChecked = selectedAnimal.Adoptable;
                chkIndvidualCurrentlyHoused.IsChecked = selectedAnimal.CurrentlyHoused;

                canIndividualAnimal.Visibility = Visibility;
            }
            catch { }

        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/3/2020
        /// Approver: Jaeho Kim, 3/3/2020
        /// Approver: 
        /// 
        /// The method that will return to the view list of animals from the individual animal 
        /// detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnReturnViewIndividualAnimal_Click(object sender, RoutedEventArgs e)
        {
            ACE.Visibility = Visibility.Visible;
            
            DG.Visibility = Visibility.Visible;

            Scroll.ScrollToTop();
            SearchBar_.Visibility = Visibility.Visible;
            DG.Visibility = Visibility.Visible;
            SearchSymbolButton.Visibility = Visibility.Visible;
            canViewAnimalList.Visibility = Visibility.Visible;
            canIndividualAnimal.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/11/2020
        /// Approver: Austin Gee, 3/12/2020
        /// Approver: 
        /// 
        /// The method that will open a new canvas with the selected animal's information on it
        /// and can be edited.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnEditIndividualAnimal_Click(object sender, RoutedEventArgs e)
        {
            canEditAnimal.Visibility = Visibility.Visible;
            canIndividualAnimal.Visibility = Visibility.Hidden;

            Animal selectedAnimal = (Animal)dgActiveAnimals.SelectedItem;

            lblEditAnimalID.Content = selectedAnimal.AnimalID;
            txtEditAnimalName.Text = selectedAnimal.AnimalName;
            cmbEditAnimalSpecies.SelectedItem = selectedAnimal.AnimalSpeciesID;
            txtEditAnimalBreed.Text = selectedAnimal.AnimalBreed;
            cndEditDob.SelectedDate = selectedAnimal.Dob;
            cndEditDob.DisplayDate = selectedAnimal.Dob;
            cndEditArrivalDate.SelectedDate = selectedAnimal.ArrivalDate;
            cndEditArrivalDate.DisplayDate = selectedAnimal.ArrivalDate;
            chkEditActive.IsChecked = selectedAnimal.Active;
            chkEditAdoptable.IsChecked = selectedAnimal.Adoptable;
            chkEditCurrentlyHoused.IsChecked = selectedAnimal.CurrentlyHoused;
            cmbEditAnimalSpecies.ItemsSource = _animalManager.RetrieveAnimalSpecies();
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// Approver: 
        /// 
        /// The method that cancels the edit animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnCancelAnimalEdit_Click(object sender, RoutedEventArgs e)
        {
            canEditAnimal.Visibility = Visibility.Hidden;
            canIndividualAnimal.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// Approver: 
        /// 
        /// The method that saves the edits to the animal
        /// </summary>
        /// <remarks>
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSubmitAnimalEdit_Click(object sender, RoutedEventArgs e)
        {
            string arrival = cndEditArrivalDate.SelectedDate.ToString();
            string dob = cndEditDob.SelectedDate.ToString();
            if (String.IsNullOrEmpty(txtEditAnimalName.Text))
            {
                MessageBox.Show("Please enter the animal's name");
                return;
            }
            if (String.IsNullOrEmpty(txtEditAnimalBreed.Text))
            {
                MessageBox.Show("Please enter the animal's breed");
                return;
            }
            if (String.IsNullOrEmpty(cmbEditAnimalSpecies.Text))
            {
                MessageBox.Show("Please enter the animal's species");
                return;
            }
            if (String.IsNullOrEmpty(arrival))
            {
                MessageBox.Show("Please enter the animal's arrival date");
                return;
            }
            if (String.IsNullOrEmpty(dob))
            {
                cndDob.SelectedDate = DateTime.Parse("01/01/2000");
                return;
            }

            Animal newAnimal = new Animal();

            newAnimal.AnimalName = txtEditAnimalName.Text;
            newAnimal.AnimalSpeciesID = cmbEditAnimalSpecies.Text;
            newAnimal.AnimalBreed = txtEditAnimalBreed.Text;
            newAnimal.ArrivalDate = (DateTime)cndEditArrivalDate.SelectedDate;
            newAnimal.Dob = (DateTime)cndEditDob.SelectedDate;

            try
            {
                if (_animalManager.EditAnimal(selectedAnimal, newAnimal))
                {
                    WPFErrorHandler.SuccessMessage("Animal Successfully Updated");

                    canViewAnimalList.Visibility = Visibility.Visible;
                    canEditAnimal.Visibility = Visibility.Hidden;
                    refreshActiveData();
                    chkActive.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                canIndividualAnimal.Visibility = Visibility.Visible;
                canEditAnimal.Visibility = Visibility.Hidden;
                refreshActiveData();
                chkActive.IsChecked = false;
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/7/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Toggles the animal's Active state.
        /// detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkEditActive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caption = (bool)chkEditActive.IsChecked ? "Reactivate Animal" :
                    "Dectivate Animal";
                if (MessageBox.Show("Are you sure?", caption,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    chkEditActive.IsChecked = !(bool)chkEditActive.IsChecked;
                    return;
                }

                if (_animalManager.SetAnimalActiveState((bool)chkEditActive.IsChecked, (int)lblEditAnimalID.Content))
                {
                    MessageBox.Show("Record Edited Successfully.", "Result");
                }

                if ((bool)chkEditActive.IsChecked)
                {
                    refreshActiveData();
                }
                else
                {
                    refreshInactiveData();
                }
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.ActivateDeactivateErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/7/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Toggles the animal's Housed state.
        /// detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkEditCurrentlyHoused_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caption = (bool)chkEditCurrentlyHoused.IsChecked ? "Set Housed" :
                    "Set Non-Housed";
                if (MessageBox.Show("Are you sure?", caption,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    chkEditCurrentlyHoused.IsChecked = !(bool)chkEditCurrentlyHoused.IsChecked;
                    return;
                }

                if (_animalManager.SetAnimalHousedState((bool)chkEditCurrentlyHoused.IsChecked, (int)lblEditAnimalID.Content))
                {
                    MessageBox.Show("Record Edited Successfully.", "Result");
                }

                if ((bool)chkEditActive.IsChecked)
                {
                    refreshActiveData();
                }
                else
                {
                    refreshInactiveData();
                }
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.ActivateDeactivateErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/7/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Toggles the animal's Adoptable state.
        /// detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkEditAdoptable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caption = (bool)chkEditAdoptable.IsChecked ? "Set Adoptable" :
                    "Set Non-Adoptable";
                if (MessageBox.Show("Are you sure?", caption,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    chkEditAdoptable.IsChecked = !(bool)chkEditAdoptable.IsChecked;
                    return;
                }

                if (_animalManager.SetAnimalAdoptableState((bool)chkEditAdoptable.IsChecked, (int)lblEditAnimalID.Content))
                {
                    MessageBox.Show("Record Edited Successfully.", "Result");
                }

                if ((bool)chkEditActive.IsChecked)
                {
                    refreshActiveData();
                }
                else
                {
                    refreshInactiveData();
                }
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.ActivateDeactivateErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Text changed event for the searchbar
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public void SearchBar1_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            SearchBarTextInputManager();
        }
        int NumberOfResults = 0;
        List<AnimalNames> List_ = new List<AnimalNames>();
        bool mainList = true;

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Handles retrieving reccomendations as the user types into the searchbar
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<AnimalNames> SearchBarTextInputManager()
        {


            try
            {
                NoResults.Visibility = Visibility.Hidden;
                SearchBar_.Foreground = Brushes.Black;

                NumberOfResults = DG.Items.Count;

                AnimalNames names = new AnimalNames();

                DG.Visibility = Visibility.Visible;

                AnimalManager am = new AnimalManager();


                if (SearchBar_.Text == "")
                {
                    SearchSymbolButton.IsEnabled = false;

                    mainList = true;

                }
                else
                {
                    SearchSymbolButton.IsEnabled = true;

                }
                int one = 0;
                List_ = am.RetrieveNames();

                try
                {
                    if (mainList == true)
                    {
                        one = Int32.Parse(SearchBar_.Text);

                        DG.ItemsSource = (from c in List_
                                          where c.AnimalID == Int32.Parse(SearchBar_.Text) + 1000000
                                          select c).ToList();

                    }

                }
                catch
                {


                    if (mainList == true)
                    {


                        DG.ItemsSource = (from c in List_
                                          where c.AnimalName == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                          ||
                                          c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                          ||
                                          c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty).Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                          ||
                                           c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                           ||
                                           c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                           ||
                                           c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                           ||
                                           c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                           ||
                                           c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                           ||
                                           c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                           ||
                                           c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                           ||
                                             c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                             ||
                                               c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                               ||
                                                 c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                                 ||
                                                  c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                                  ||
                                                    c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[13].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                                    ||
                                                      c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[13].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[14].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                                      ||
                                                       c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[13].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[14].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[15].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                                       ||
                                                        c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[13].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[14].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[15].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[16].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                            ||
                                               c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[13].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[14].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[15].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[16].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[17].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                               ||
                                               c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[13].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[14].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[15].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[16].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[17].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[18].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                                ||
                                               c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[13].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[14].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[15].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[16].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[17].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[18].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[19].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                                ||
                                               c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[13].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[14].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[15].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[16].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[17].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[18].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[19].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[20].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty)
                                               ||
                                                c.AnimalName[0].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[1].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[2].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[3].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[4].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[5].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[6].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[7].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[8].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[9].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[10].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[11].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[12].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[13].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[14].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[15].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[16].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[17].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[18].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[19].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[20].ToString().ToLower().Replace(" ", String.Empty) + c.AnimalName[21].ToString().ToLower().Replace(" ", String.Empty) == SearchBar_.Text.ToLower().Replace(" ", String.Empty).Replace(" ", String.Empty)
                                          select c).ToList();


                        int NumberOfResults = DG.Items.Count;

                        AnimalNames NAC = (AnimalNames)DG.Items[0];

                        if (NumberOfResults <= 3 && SearchBar_.Text.Length >= 4 && ACE.IsChecked == true)
                        {
                            SearchSymbolButton.IsEnabled = true;

                            SearchBar_.Foreground = Brushes.LightGray;

                            SearchBar_.Text = NAC.AnimalName.TrimEnd().TrimStart();

                            SearchBar_.Select(SearchBar_.Text.Length + 1, 0);

                            SearchBar_.Focus();

                            SearchBar_.IsReadOnly = true;
                        }

                        if (NumberOfResults > 3 && SearchBar_.Text.Length != 4)
                        {
                            SearchBar_.IsReadOnly = false;
                        }







                    }

                }
            }
            catch (Exception ex)
            {



            }





            return List_;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// MouseEnter and MouseLeave events for the searchbar
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void SearchBar_Hover_Off(object sender, MouseEventArgs e)
        {

            DG.Visibility = Visibility.Hidden;

            if (SearchBar_.Text == "" && SearchBar_.IsFocused == false)
            {
                SearchBar_.Text = "Search...";
                SearchBar_.Foreground = Brushes.LightGray;
            }



        }
        private void SearchBar_Hover_ON(object sender, MouseEventArgs e)
        {
            DG.Visibility = Visibility.Visible;

            if (SearchBar_.Text == "Search...")
            {
                SearchBar_.Clear();
                SearchBar_.Foreground = Brushes.Black;
            }
        

        

        }




        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Allows the user to double click on a reccomendation 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void SearchResultList_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ACE.Visibility = Visibility.Hidden;
            if (dgActiveAnimals.Visibility == Visibility)
            {
                SearchBar_.Visibility = Visibility.Visible;
            }
            else
            {
                SearchBar_.Visibility = Visibility.Hidden;
            }
            try
            {
                NoResults.Visibility = Visibility.Hidden;

                NoResults.Visibility = Visibility.Hidden;
                SearchBar_.Visibility = Visibility.Hidden;
                DG.Visibility = Visibility.Hidden;

                object item = DG.SelectedItem;
                string ID = (DG.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                List<Animal> list_ = _animalManager.RetrieveAnimalByAnimalID(Int32.Parse(ID.ToString()));

                Animal NAC = (Animal)list_[0];

                lblIndividualAnimalName.Content = NAC.AnimalName.ToString();
                lblIndividualAnimalID.Content = NAC.AnimalID.ToString();
                lblIndividualAnimalSpecies.Content = NAC.AnimalSpeciesID.ToString();
                lblIndividualAnimalBreed.Content = NAC.AnimalBreed.ToString();
                lblIndividualAnimalDob.Content = NAC.Dob.ToString();
                lblIndividualAnimalArrivalDate.Content = NAC.ArrivalDate.ToString();


                chkIndvidualActive.IsChecked = NAC.Active;
                chkIndvidualAdoptable.IsChecked = NAC.Adoptable;
                chkIndvidualCurrentlyHoused.IsChecked = NAC.CurrentlyHoused;

                canIndividualAnimal.Visibility = Visibility;
            }
            catch { }
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Binds a button click for the search bar
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Space)
                {


                    SearchBar_.Foreground = Brushes.Black;

                    SearchBar_.Text = SearchBar_.Text + " ";

                    SearchBar_.Select(SearchBar_.Text.Length + 1, 0);

                    SearchBar_.Focus();

                    SearchBar_.IsReadOnly = false;

                }

                if (e.Key == Key.Back)
                {

                    if (SearchBar_.Foreground == Brushes.LightGray && SearchBar_.Text.Length > 2)
                    {

                        SearchBar_.Foreground = Brushes.Black;
                        SearchBar_.Clear();

                        SearchBar_.IsReadOnly = false;
                    }
                }
            }
            catch { }
        
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Button to allow the user to search for whatever is typed in the searchbar
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void SearchButton(object sender, RoutedEventArgs e)
        {
            
            NumberOfResults = DG.Items.Count;
            // SearchBar_.Select(0, 0);
            //SearchBar_.Clear();

            try
            {
                NoResults.Visibility = Visibility.Hidden;

                an = (AnimalNames)DG.Items[0];

                SearchBar_.Visibility = Visibility.Hidden;
                DG.Visibility = Visibility.Hidden;

                List<Animal> list_ = _animalManager.RetrieveAnimalByAnimalID(an.AnimalID);

                Animal NAC = (Animal)list_[0];

                lblIndividualAnimalName.Content = NAC.AnimalName.ToString();
                lblIndividualAnimalID.Content = NAC.AnimalID.ToString();
                lblIndividualAnimalSpecies.Content = NAC.AnimalSpeciesID.ToString();
                lblIndividualAnimalBreed.Content = NAC.AnimalBreed.ToString();
                lblIndividualAnimalDob.Content = NAC.Dob.ToString();
                lblIndividualAnimalArrivalDate.Content = NAC.ArrivalDate.ToString();


                chkIndvidualActive.IsChecked = NAC.Active;
                chkIndvidualAdoptable.IsChecked = NAC.Adoptable;
                chkIndvidualCurrentlyHoused.IsChecked = NAC.CurrentlyHoused;

                canIndividualAnimal.Visibility = Visibility;
                ACE.Visibility = Visibility.Hidden;
            }
            catch
            {
                SearchSymbolButton.IsEnabled = true;
                NoResults.Visibility = Visibility.Visible;

                NoResults.Content = "No results found for " + " ' " + SearchBar_.Text + " ' ";
            }





        }

       
    }
}
