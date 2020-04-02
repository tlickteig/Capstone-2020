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
using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Creator: Tener karar
    /// Created: 2020/02/7
    /// Approver: Brandyn T. Coverdill
    ///
    /// The main presentaion layer for  item class
    /// Contains all methods for performing basic item functions
    /// </summary>

    public partial class viewItems : Page
    {
        private IManageBackstockRecords StockManger;
        private Item item;
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this constrctor method mainwindow class 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        public viewItems()
        {
            InitializeComponent();
            StockManger = new ManageBackstockRecords();
            item = new Item();
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this event for main window class 
        /// desplay the item in the screen item  
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        private void btnViewItem_Click(object sender, RoutedEventArgs e)
        {
            item = (Item)DGViewDatat.SelectedItem;
            List<int> locations = null;
            try
            {
                locations = StockManger.getItemLocations(item.ItemID);
                txtItemID.Text = item.ItemID.ToString();
                txtItemName.Text = item.ItemName;
                txtItemLocation.Text = locations[0].ToString();
                txtNewItemLocation.Text = "";
                txtItemDescription.Text = item.Description;
                txtItemCount.Text = locations.Count.ToString();

            }
            catch (Exception)
            {

                locations = new List<int>();
            }
            canViewItems.Visibility = Visibility.Hidden;
            canEditItemsLocation.Visibility = Visibility.Visible;
            //new ViewEditUpdateItem(item).ShowDialog();

        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this event for main window class 
        /// desplay the item in the screen item  
        /// </summary>
        ///
        /// <remarks>
        /// Updater Matt Deaton
        /// Updated: 2020-03-07 
        /// Update: Removed Column 3 to insure the Shelter Threshold didn't show up in Data Grid
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGViewDatat.ItemsSource = StockManger.getPetsInBackRoom();
            DGViewDatat.Columns.RemoveAt(3);
          
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver:  Steven Cardona
        /// 
        /// this method creating a list to holde item list
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = StockManger.EditItemLocation(Convert.ToInt32(txtItemID.Text),
                 Convert.ToInt32(txtItemLocation.Text), Convert.ToInt32(txtNewItemLocation.Text));
                
                    lblItemAdd.Content = " the item updated";
                    txtItemLocation.Text = txtNewItemLocation.Text;
                    txtNewItemLocation.Text = "";
                

            }
            catch (Exception)
            {

                lblItemAdd.Content = " we dont  have location  like That  ";
            }
           
            
        }



        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver:  Brandyn T. Coverdill
        /// 
        /// this method  for show update loction and Hiding item view
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            canViewItems.Visibility = Visibility.Visible;
            canEditItemsLocation.Visibility = Visibility.Hidden;
        }
    }
}
