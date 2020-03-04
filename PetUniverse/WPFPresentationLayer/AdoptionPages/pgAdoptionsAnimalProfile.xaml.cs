using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
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

namespace WPFPresentationLayer.AdoptionsPages
{
    /// <summary>
    /// Interaction logic for pgAdoptionsAnimalProfile.xaml
    /// </summary>
    public partial class pgAdoptionsAnimalProfile : Page
    {
        public pgAdoptionsAnimalProfile()
        {
            InitializeComponent();
            _animalManager = new AnimalManager();
            Animal _animal = new Animal();
        }

        private IAnimalManager _animalManager;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refreshData();
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// Approver: 
        /// 
        /// Method to refresh the data grid
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void refreshData()
        {
            try
            {
                dgAnimalProfiles.ItemsSource = _animalManager.RetrieveAllAnimalProfiles();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: 
        /// Approver: 
        /// Method to take a user to the canvas to update the profile
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        private void DgAnimals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            canUpdateAnimal.Visibility = Visibility.Visible;
            BtnSubmitAnimalUpdate.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Method for the user to cancel the update and take them back to the original data grid
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        private void BtnCancelUpdate_Click(object sender, RoutedEventArgs e)
        {
            canUpdateAnimal.Visibility = Visibility.Hidden;
            refreshData();
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver:  Austin Gee
        /// Approver: 
        /// 
        /// Method to clear display and clear inputs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ClearDisplay()
        {
            txtAnimalProfileDescription.Text = "";
            txtImageLocation.Text = "";
            canViewAnimalProfileList.Visibility = Visibility.Visible;
            canUpdateAnimal.Visibility = Visibility.Hidden;
            dgAnimalProfiles.Visibility = Visibility.Visible;
            refreshData();
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// Approver: 
        /// 
        /// Method to validate that there is a description and a photo path and sends that data to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSubmitAnimalUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAnimalProfileDescription.Text))
            {
                MessageBox.Show("Please enter the animal's profile description");
                return;
            }
            if (String.IsNullOrEmpty(txtImageLocation.Text))
            {
                MessageBox.Show("Please enter the location of an image");
                return;
            }
            object selectedItem = dgAnimalProfiles.SelectedItem;
            string ID = (dgAnimalProfiles.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
            try
            {
                int animalID = Int32.Parse(ID);
                string imageLocation = txtImageLocation.Text;
                string profileDescription = txtAnimalProfileDescription.Text;
                _animalManager.UpdatePetProfile(animalID, profileDescription, imageLocation);
                WPFErrorHandler.SuccessMessage("Animal Successfully Updated");
                ClearDisplay();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                ClearDisplay();
            }

        }
    }
}
