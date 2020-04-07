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
using PresentationUtilityCode;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver: Cash Carlson
    /// 
    /// Interaction logic for pgPromotion.xaml
    /// </summary>
    public partial class pgPromotion : Page
    {
        Frame _frame;
        IPromotionManager _promotionManager = new PromotionManager();
        List<Promotion> _promotions;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Default constructor
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public pgPromotion()
        {
            InitializeComponent();
            try
            {
                _promotions = _promotionManager.GetAllPromotions();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Failed to load promotions.", ex.GetType().ToString());
            }
            dgPromotions.ItemsSource = _promotions;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Constructor that takes a frame for navigation purposes.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="frame">Frame used for navigation.</param>
        public pgPromotion(Frame frame)
        {
            _frame = frame;
            InitializeComponent();
            try
            {
                _promotions = _promotionManager.GetAllPromotions();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Failed to load promotions.", ex.GetType().ToString());
            }
            dgPromotions.ItemsSource = _promotions;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Navigates to the "add" version of the View/Add/Edit page
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPromotion_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new pgAddEditViewPromotion(_promotionManager, _frame));
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: 
        /// 
        /// Handles column formating.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgPromotions_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string columnHeader = e.Column.Header.ToString();
            if (e.PropertyType == typeof(DateTime))
            {
                DataGridTextColumn col = e.Column as DataGridTextColumn;
                if (col != null)
                {
                    col.Binding.StringFormat = "MM/dd/yyyy";
                }
            }
            if (columnHeader.Equals("PromotionID"))
            {
                e.Column.Header = "Promotion ID";
            }
            else if (columnHeader.Equals("PromotionTypeID"))
            {
                e.Column.Header = "Discount Type";
            }
            else if (columnHeader.Equals("StartDate"))
            {
                e.Column.Header = "Start Date";
            }
            else if (columnHeader.Equals("EndDate"))
            {
                e.Column.Header = "End Date";
            }
            else if (columnHeader.Equals("Description"))
            {
                DataGridTextColumn col = e.Column as DataGridTextColumn;
                col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: 
        /// 
        /// Allows for the viewing of promotion details.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void dgPromotions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgPromotions.SelectedItem != null)
            {
                _frame.Navigate(new pgAddEditViewPromotion(_promotionManager, _frame, (Promotion)dgPromotions.SelectedItem));
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: 
        /// 
        /// Opens the window to edit a promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void btnEditPromotion_Click(object sender, RoutedEventArgs e)
        {
            if (dgPromotions.SelectedItem != null)
            {
                _frame.Navigate(new pgAddEditViewPromotion(_promotionManager, _frame, (Promotion)dgPromotions.SelectedItem, editMode: true));
            }
        }
    }
}
