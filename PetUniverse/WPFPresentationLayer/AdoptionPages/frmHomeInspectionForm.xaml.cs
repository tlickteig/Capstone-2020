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

namespace WPFPresentationLayer.AdoptionPages
{
    /// <summary>
    /// Created: 2/5/2020
    /// Approver: Austin Gee, 2/7/2020
    /// Approver:
    /// 
    /// Interaction logic for frmHomeInspectionForm.xaml
    /// window.
    /// and roles and will control what the user can see and do
    /// ID.
    /// </summary>
    public partial class frmHomeInspectionForm : Page
    {
        private IHomeInspectorManager _homeInspectorManager;

        /// <summary>
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This This constructor method for frmHomeInspectorAdoptionApplication
        /// window.
        /// and roles and will control what the user can see and do
        /// ID.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" CustomerID"></param>
        /// <returns>Customer Name</returns>
        public frmHomeInspectionForm()
        {
            InitializeComponent();
            _homeInspectorManager = new HomeInspectorManager();
        }
        /// <summary>
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This constructor is passed a HomeInspectorManager 
        /// and homeInspectorManager.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" HomeInspectorManager"></param>
        /// <param name=" homeInspectorManager"></param>
        /// <returns></returns>
        public frmHomeInspectionForm(HomeInspectorManager homeInspectorManager)
        {

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This method is called when the window first loads.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        /// <returns></returns>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            populatedgAdoptionApplicationsList();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This method fills in data for frmHomeInspectorAdoptionApplication
        /// Data Gird.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        private void populatedgAdoptionApplicationsList()
        {
            dgAdoptionApplicationsList.ItemsSource = _homeInspectorManager.SelectAdoptionApplicationByStatus();
            dgAdoptionApplicationsList.Columns[0].Header = "Adoption Application ID";
            dgAdoptionApplicationsList.Columns[1].Header = "Custome Name";
            dgAdoptionApplicationsList.Columns[2].Header = "Animal Name";
            dgAdoptionApplicationsList.Columns[3].Header = "Status";
            dgAdoptionApplicationsList.Columns[4].Header = "Recieved Date and Time";
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy
        /// 
        /// This is an event on btnOpen is clicked.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        /// <returns></returns>   
        private void BtnOpenRecord_Click(object sender, RoutedEventArgs e)
        {
            AdoptionApplication adoptionApplication = new AdoptionApplication();
            adoptionApplication = (AdoptionApplication)dgAdoptionApplicationsList.SelectedItem;

            var selectedItem = (AdoptionApplication)dgAdoptionApplicationsList.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Please select an Adoption Appliction to open the Customer Details.");
            }
            else
            {
                this.NavigationService?.Navigate(new CustomerDetail
                    (adoptionApplication.CustomerEmail));
                populatedgAdoptionApplicationsList();
            }
        }
    }
}


