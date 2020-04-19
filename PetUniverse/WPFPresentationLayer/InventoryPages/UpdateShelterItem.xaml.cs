using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Interaction logic for UpdateShelterItem.xaml
    /// </summary>
    public partial class UpdateShelterItem : Page
    {
        private Item _shelterItem = null;
        private IItemManager _itemManager;
        private IItemCategoryManager _itemCategoryManager;

        public UpdateShelterItem(IItemManager itemManager)
        {
            InitializeComponent();
            _itemManager = itemManager;
            _itemCategoryManager = new ItemCategoryManager();
        }

        public UpdateShelterItem(Item shelterItem, IItemManager itemManager)
        {
            InitializeComponent();
            _shelterItem = shelterItem;
            _itemManager = itemManager;
            _itemCategoryManager = new ItemCategoryManager();
        }

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03- 17
        /// CHECKED BY:
        /// 
        /// Method to Load the selected items information.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            txtItemName.Text = _shelterItem.ItemName.ToString();
            txtItemQty.Text = _shelterItem.ItemQuantity.ToString();
            txtShelterThreshold.Text = _shelterItem.ShelterThreshold.ToString();
            txtItemDesc.Text = _shelterItem.Description.ToString();
            cboBxCategory.SelectedItem = _shelterItem.ItemCategoryID.ToString();
            txtItemName.Focus();
            txtItemName.SelectAll();
        }// End Grid_Loaded()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03- 17
        /// CHECKED BY:
        /// 
        /// Method to Cancel the update of a Shelter Item.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ShelterInventory());
        }// End btnCancel_Click()

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: 
        /// Approver:  
        ///
        /// Populates the ComboBox with values.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void cboBxCategory_Loaded(object sender, RoutedEventArgs e)
        {
            List<ItemCategory> list = new List<ItemCategory>();
            list = _itemCategoryManager.listItemCategories();
            foreach (var item in list)
            {
                cboBxCategory.Items.Add(item.ItemCategoryID);
            }
        }// End cboBxCategory_Loaded()

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtItemName.Text == "")
            {
                MessageBox.Show("You must enter an Item Name.");
                txtItemName.Focus();
                return;
            }
            if (txtItemQty.Text == "")
            {
                MessageBox.Show("You must enter an Item Quantity.");
                txtItemQty.Focus();
                return;
            }
            if (txtItemDesc.Text == "")
            {
                MessageBox.Show("You must enter an Item Description.");
                txtItemDesc.Focus();
                return;
            }

            Item shelterItem = new Item()
            {
                ItemName = txtItemName.Text.ToString(),
                ItemQuantity = Convert.ToInt32(txtItemQty.Text),
                ShelterThreshold = Convert.ToInt32(txtShelterThreshold.Text),
                ItemCategoryID = cboBxCategory.Text,
                Description = txtItemDesc.Text,
                ShelterItem = (bool)chkShelterItem.IsChecked
            };

            try
            {
                if (_itemManager.EditShelterItem(_shelterItem, shelterItem))
                {
                    MessageBox.Show("You updated " + txtItemName.Text);
                    this.NavigationService?.Navigate(new ShelterInventory());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }// End btnSaveUpdate_Click()

        private void txtItemQty_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void txtShelterThreshold_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void txtItemDesc_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }// End class UpdateShelterItem

}// End namespace WPFPresentationLayer.InventoryPages
