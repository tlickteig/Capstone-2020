
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/13/2020
    /// Approver: Chuck Baxter, 2/13/2020
    /// 
    /// Main window partial class
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public partial class AnimalManagementInventory : Page
    {
        private IMedicationManager _medicationManager;



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// No argument constructor for main window
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalManagementInventory()
        {
            InitializeComponent();

            StatusCanvas.Visibility = Visibility.Hidden;

            CompleteOrder.Visibility = Visibility.Hidden;

            ItemID_.Text = "";

            ItemName_.Text = "";


            Warning.Visibility = Visibility.Hidden;
            Warning2.Visibility = Visibility.Hidden;

            QuantityAlertManager();

            CreateOrder.Visibility = Visibility.Hidden;

            Med.Visibility = Visibility.Visible;

            MedList.Visibility = Visibility.Visible;

            MedList.Width = Double.NaN;

            MedList.Height = Double.NaN;

            OS.Visibility = Visibility.Hidden;
            ID.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            Number.Visibility = Visibility.Hidden;

            ItemID_.Visibility = Visibility.Hidden;

            ItemName_.Visibility = Visibility.Hidden;

            //Quantity_.Visibility = Visibility.Hidden;

            OS.Visibility = Visibility.Hidden;

            four.Visibility = Visibility.Hidden;



            //Quantity_form.Visibility = Visibility.Hidden;
            Quantity_input.Visibility = Visibility.Hidden;
            four.Visibility = Visibility.Hidden;

            ShowMedicationInventory();

            _medicationManager = new MedicationManager();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/3/2020
        /// Approver: Carl Davis, 3/6/2020s 
        /// Approver: 
        /// 
        /// Method to handle quantity alerts
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void QuantityAlertManager()
        {
            MedicationManager medicationManager = new MedicationManager();

            int num = medicationManager.RetrieveMedicationByLowQauntity().Count();

            int empty = medicationManager.RetrieveMedicationByEmptyQauntity().Count();

            Medication medication = new Medication();






            if (num == 1)
            {
                Warning2.Content = "! Pet universe is currently running low on " + num + " medication";
                Warning2.Foreground = new SolidColorBrush(Colors.DarkOrange);
                Warning2.Visibility = Visibility.Visible;
            }
            else
                 if (num > 1)
            {
                Warning2.Content = "! Pet universe is currently running low on " + num + " medications";
                Warning2.Foreground = new SolidColorBrush(Colors.DarkOrange);
                Warning2.Visibility = Visibility.Visible;
            }
            else
            {
                Warning2.Visibility = Visibility.Hidden;
            }

            if (empty == 1)
            {
                Warning.Content = "! Pet universe is currently out of " + empty + " medication";
                Warning.Foreground = new SolidColorBrush(Colors.Red);
                Warning.Visibility = Visibility.Visible;
            }
            else
                 if (empty > 1)
            {
                Warning.Content = "! Pet universe is currently out of " + empty + " medications";
                Warning.Foreground = new SolidColorBrush(Colors.Red);
                Warning.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }







        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Displays the medication inventory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public void ShowMedicationInventory()
        {

            _medicationManager = new MedicationManager();

            List<Medication> productList = _medicationManager.RetrieveMedicationInventory();

            MedList.ItemsSource = productList;



        }



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Order more medications
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public void OrderMedications()
        {


            NewAnimalChecklistManager _ChecklistManager = new NewAnimalChecklistManager();


            object item = MedList.SelectedItem;

            string itemID = (MedList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            DateTime OrderDate = DateTime.Today;

            int UserID = 1;



            ItemID_.Text = itemID.ToString();

            //Quantity_.Text = Int32.Parse(Quantity_input.Text).ToString();

            OutgoingOrders order = new OutgoingOrders()
            {
                ItemID = 1,
                OrderDate = OrderDate,
                ItemQuantity = Int32.Parse(Quantity_input.Text),
                UserID = UserID,
                ItemCategoryID = "Medication"

            };

            _medicationManager.CreateMedicationOrder(order);



        }

        private void View_AutoGeneratedColumns(object sender, EventArgs e)
        {
            MedList.Columns[0].Header = "ItemID";
            MedList.Columns[1].Header = "ItemName";
            MedList.Columns[2].Header = "ItemQuantity";



        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Button to begin making an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            CreateOrder.Visibility = Visibility.Visible;
            //OS.Visibility = Visibility.Visible;
            //ID.Visibility = Visibility.Visible;
            //Name.Visibility = Visibility.Visible;
            //Number.Visibility = Visibility.Visible;

            //Quantity_form.Visibility = Visibility.Visible;
            //Quantity_input.Visibility = Visibility.Visible;



            //ItemID_.Visibility = Visibility.Visible;

            //ItemName_.Visibility = Visibility.Visible;

            //Quantity_.Visibility = Visibility.Visible;

            //OS.Visibility = Visibility.Visible;


            //NewAnimalChecklistManager _ChecklistManager = new NewAnimalChecklistManager();


            //object item = MedList.SelectedItem;
            //string ItemID = (MedList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            //string ItemName = (MedList.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;



            //ItemID_.Text = ItemID;

            //ItemName_.Text = ItemName;



        }



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Button to finalize an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void FinalizeOrderButton(object sender, RoutedEventArgs e)
        {

            Order.Visibility = Visibility.Hidden;

            CompleteOrder.Visibility = Visibility.Visible;

            object item = MedList.SelectedItem;
            string ItemID = (MedList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            string ItemName = (MedList.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;



            ID_.Content = ItemID;

            Name_.Content = ItemName;

            Num_.Content = Quantity_input.Text;

        }




        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/23/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Text change event for quantity input box
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void QC(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (Int32.Parse(Quantity_input.Text) >= 1)
                {
                    //Quantity_.Text = Int32.Parse(Quantity_input.Text).ToString();
                    Error.Visibility = Visibility.Hidden;
                    four.Visibility = Visibility.Visible;
                }
                else
                {
                    Error.Visibility = Visibility.Visible;
                    four.Visibility = Visibility.Hidden;
                    Error.Content = "Please order atleast 1 item";
                    //Quantity_.Text = "";

                }
            }
            catch (FormatException ex)
            {
                Error.Visibility = Visibility.Visible;
                four.Visibility = Visibility.Hidden;
                Error.Content = "Please enter a valid quantity";
                //Quantity_.Text = "";
            }
        }

        private void CreateOrderButton(object sender, RoutedEventArgs e)
        {
            Order.Visibility = Visibility.Visible;
            CreateOrder.Visibility = Visibility.Hidden;
            OS.Visibility = Visibility.Visible;
            ID.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            Number.Visibility = Visibility.Visible;

            //Quantity_form.Visibility = Visibility.Visible;
            Quantity_input.Visibility = Visibility.Visible;



            ItemID_.Visibility = Visibility.Visible;

            ItemName_.Visibility = Visibility.Visible;

            //Quantity_.Visibility = Visibility.Visible;

            OS.Visibility = Visibility.Visible;


            NewAnimalChecklistManager _ChecklistManager = new NewAnimalChecklistManager();


            object item = MedList.SelectedItem;
            string ItemID = (MedList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            string ItemName = (MedList.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;



            ItemID_.Text = ItemID;

            ItemName_.Text = ItemName;



        }

        private void MedList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateOrder.Visibility = Visibility.Visible;

        }

        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {


        }

        private void Finish(object sender, RoutedEventArgs e)
        {
            CompleteOrder.Visibility = Visibility.Hidden;

            StatusCanvas.Visibility = Visibility.Visible;


            try
            {
                OrderMedications();

                Status.Content = "Your Order has been Placed!";


            }
            catch (Exception ex)
            {
                Status.Content = "Something went wrong when placing your order :(";

            }


        }

        private void StatusMouseEnter(object sender, MouseEventArgs e)
        {
            StatusCanvas.Visibility = Visibility.Visible;
        }
        private void StatusMouseLeave(object sender, MouseEventArgs e)
        {
            StatusCanvas.Visibility = Visibility.Hidden;
        }
    }
}
