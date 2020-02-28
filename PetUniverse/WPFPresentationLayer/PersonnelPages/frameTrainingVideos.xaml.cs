using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;
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

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Interaction logic for frameTrainingVideos.xaml
    /// </summary>
    public partial class frameTrainingVideos : Page
    {
        private ITrainingVideoManager _videoManager = new TrainingVideoManager();

        public frameTrainingVideos()
        {
            InitializeComponent();
        }

        

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY:
        /// 
        /// This method is called when the view training videos tab is selected in the PM canvas
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabTrainingVideos_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgVideoList.ItemsSource == null)
                {
                    populateVideoList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY:
        /// 
        /// Helper method to populate the data grid
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        private void populateVideoList()
        {
            dgVideoList.ItemsSource = _videoManager.RetrieveTrainingVideosByEmployee();
            dgVideoList.Columns.RemoveAt(0);
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY:
        /// 
        /// Event handler for the Add button
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddVideo_Click(object sender, RoutedEventArgs e)
        {
            showPrompt();
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY:
        /// 
        /// Helper method for showing the Add/Edit form on the page
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>

        private void showPrompt()
        {
            btnAddVideo.Visibility = Visibility.Hidden;
            btnEditVideo.Visibility = Visibility.Hidden;
            btnViewVideo.Visibility = Visibility.Hidden;
            btnSaveVideo.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;

            lblVideoID.Visibility = Visibility.Visible;
            lblRunTimeM.Visibility = Visibility.Visible;
            lblRunTimeS.Visibility = Visibility.Visible;
            lblVideoDesc.Visibility = Visibility.Visible;
            txtVideoID.Visibility = Visibility.Visible;
            txtRunTimeM.Visibility = Visibility.Visible;
            txtRunTimeS.Visibility = Visibility.Visible;
            txtVideoDesc.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY:
        /// 
        /// Event handler for the Save button
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveVideo_Click(object sender, RoutedEventArgs e)
        {
            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = txtVideoID.Text;
            newVideo.RunTimeMinutes = Convert.ToInt32(txtRunTimeM.Text);
            newVideo.RunTimeSeconds = Convert.ToInt32(txtRunTimeS.Text);
            newVideo.Description = txtVideoDesc.Text;

            try
            {
                bool result = _videoManager.InsertTrainingVideo(newVideo);
                if (result)
                {
                    MessageBox.Show("Video Added.");
                    hidePrompt();
                    populateVideoList();
                }
                else
                {
                    MessageBox.Show("Video Not Added.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Video failed to save." + ex.Message);
            }
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY:
        /// 
        /// Helper method to hide the Add/Edit form on the page
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        private void hidePrompt()
        {
            btnAddVideo.Visibility = Visibility.Visible;
            btnEditVideo.Visibility = Visibility.Visible;
            btnViewVideo.Visibility = Visibility.Visible;
            btnSaveVideo.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;

            lblVideoID.Visibility = Visibility.Hidden;
            lblRunTimeM.Visibility = Visibility.Hidden;
            lblRunTimeS.Visibility = Visibility.Hidden;
            lblVideoDesc.Visibility = Visibility.Hidden;
            txtVideoID.Visibility = Visibility.Hidden;
            txtRunTimeM.Visibility = Visibility.Hidden;
            txtRunTimeS.Visibility = Visibility.Hidden;
            txtVideoDesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY:
        /// 
        /// Event handler for the Cancel button
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            hidePrompt();
        }

        private void DgVideoList_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgVideoList.ItemsSource == null)
                {
                    populateVideoList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
