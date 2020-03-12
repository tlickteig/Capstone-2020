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
            Animal selectedAnimal = (Animal)dgActiveAnimals.SelectedItem;
            
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
            Animal selectedAnimal = (Animal)dgActiveAnimals.SelectedItem;
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
    }
}
