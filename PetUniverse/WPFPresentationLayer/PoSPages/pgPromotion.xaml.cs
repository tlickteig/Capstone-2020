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

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Interaction logic for pgPromotion.xaml
    /// </summary>
    public partial class pgPromotion : Page
    {
        Frame _frame;
        IPromotionManager _promotionManager = new PromotionManager();

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Default constructor
        /// </summary>
        public pgPromotion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Constroctor that takes a frame for navigation purposes.
        /// </summary>
        /// <param name="frame"></param>
        public pgPromotion(Frame frame)
        {
            _frame = frame;
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Navigates to the "add" version of the View/Add/Edit page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPromotion_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new pgAddEditViewPromotion(_promotionManager, _frame));
        }
    }
}
