using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
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
    /// Creator: Ben Hanna
    /// Created: 2/22/2020
    /// Approver: Steven Cardona 
    /// Approver: 
    /// 
    /// Interaction logic for HandlingControls.xaml
    /// </summary>
    public partial class HandlingControls : Page
    {
        private AnimalHandlingNotes notes;
        private IAnimalHandlingManager _handlingManager;

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
        public HandlingControls()
        {
            InitializeComponent();
            notes = new AnimalHandlingNotes();
            _handlingManager = new AnimalHandlingManager();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Double click handling notes datagrid to select a set of handling notes records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgHandlingNotesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            notes = (AnimalHandlingNotes)dgHandlingNotesList.SelectedItem;

            txtHandlingNotesID.Text = notes.HandlingNotesID.ToString();
            txtAnimalID.Text = notes.AnimalID.ToString();
            txtUserID.Text = notes.UserID.ToString();
            txtHandlingNotes.Text = notes.HandlingNotes;
            txtTemperment.Text = notes.TemperamentWarning;
            dpHandlingUpdateDate.SelectedDate = notes.UpdateDate;
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Search for handling notes by the animal's primary key
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchForHandling_Click(object sender, RoutedEventArgs e)
        {
            int animalID;
            if (!int.TryParse(txtSearchForHandling.Text, out animalID))
            {
                MessageBox.Show("ID fields may not contain anything but an integer number");
                return;
            }
            else
            {
                dgHandlingNotesList.ItemsSource = _handlingManager.GetAllHandlingNotesByAnimalID(animalID);
            }


        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Populates the grid on page load
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgHandlingNotesList.IsReadOnly = true;
        }
    }
}
