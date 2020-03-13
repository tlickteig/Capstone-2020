using System;
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
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualBasic;
using PresentationUtilityCode;

namespace WPFPresentationLayer.AMPages
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/22/2020
    /// Approver: Steven Cardona
    /// Approver:
    /// 
    /// 
    /// Interaction logic for KennelControls.xaml
    /// </summary>
    public partial class KennelControls : Page
    {
        private IAnimalKennelManager _kennelManager;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Constructor for this page.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public KennelControls()
        {
            InitializeComponent();
            _kennelManager = new AnimalKennelManager();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Switch to the subpage to add records.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLocationRecord_Click(object sender, RoutedEventArgs e)
        {
            canAddRecord.Visibility = Visibility.Visible;

            txtAnimalID.IsEnabled = true;
            txtDateIn.IsEnabled = true;
            txtDateOut.IsEnabled = true;
            txtKennelInfo.IsEnabled = true;
            txtUserID.IsEnabled = true;
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Return to previous page.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelKennelAdd_Click(object sender, RoutedEventArgs e)
        {
            canViewKennelList.Visibility = Visibility.Visible;
            canAddRecord.Visibility = Visibility.Hidden;

            txtAnimalID.Text = "";
            txtDateIn.Text = "";
            txtDateOut.Text = "";
            txtKennelID.Text = "";
            txtKennelInfo.Text = "";
            txtUserID.Text = "";

            lblTitle.Content = "Register New Kennel Record";
            RefreshData();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Add animal kennel location record to the database 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitKennelAdd_Click(object sender, RoutedEventArgs e)
        {
            int userID;
            int animalID;

            if (String.IsNullOrEmpty(txtAnimalID.Text))
            {
                MessageBox.Show("Please enter the animal's ID");
                return;
            }
            if (String.IsNullOrEmpty(txtUserID.Text))
            {
                MessageBox.Show("Please enter the User's ID");
                return;
            }
            if (!int.TryParse(txtAnimalID.Text, out animalID))
            {
                MessageBox.Show("ID fields may not contain anything but an integer number");
                return;
            }
            else if (!int.TryParse(txtUserID.Text, out userID))
            {
                MessageBox.Show("ID fields may not contain anything but an integer number");
                return;
            }
            else
            {

                AnimalKennel kennel = new AnimalKennel()
                {
                    AnimalID = animalID,
                    UserID = userID,
                    AnimalKennelInfo = txtKennelInfo.Text,
                    AnimalKennelDateIn = DateTime.Now
                };

                try
                {
                    _kennelManager.AddKennelRecord(kennel);
                    WPFErrorHandler.SuccessMessage("Kennel Record Successfully Added");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// triggers the datagrid to refresh
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAllKennels_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Refreshes the datagrid
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshData()
        {
            try
            {
                dgAllKennels.ItemsSource = _kennelManager.GetAllAnimalKennels();
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/13/2020
        /// Approver:  Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Selects a single kennel record for viewing.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAllKennels_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AnimalKennel selectedKennel = (AnimalKennel)dgAllKennels.SelectedItem;

            txtAnimalID.Text = selectedKennel.AnimalID.ToString();
            txtKennelID.Text = selectedKennel.AnimalKennelID.ToString();
            txtUserID.Text = selectedKennel.UserID.ToString();
            txtKennelInfo.Text = selectedKennel.AnimalKennelInfo.ToString();
            txtDateIn.Text = selectedKennel.AnimalKennelDateIn.ToString();
            txtDateOut.Text = selectedKennel.AnimalKennelDateOut.ToString();

            lblTitle.Content = "View Kennel Record Details";

            canAddRecord.Visibility = Visibility.Visible;
        }
    }
}
