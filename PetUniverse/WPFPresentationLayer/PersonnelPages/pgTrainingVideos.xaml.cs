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
using PresentationUtilityCode;

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Interaction logic for frameTrainingVideos.xaml
    /// </summary>
    public partial class frameTrainingVideos : Page
    {
        private TrainingVideo _trainingVideo;
        private bool _editMode = false;
        bool _insertMode = false;
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
            populateVideoList();
            dgVideoList.Columns.RemoveAt(0);
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
            dgVideoList.ItemsSource = _videoManager.RetrieveTrainingVideosByActive((bool)chkVideosActive.IsChecked);
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY: Jordan Lindo
        /// 
        /// Event handler for the Add button
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Chase Schulte
        /// UPDATE DATE: 03/03/2020
        /// CHANGE: Added boolean insert mode and edit mode
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddVideo_Click(object sender, RoutedEventArgs e)
        {
            _trainingVideo = null;
            _editMode = true;
            _insertMode = true;
            showPrompt();
            txtVideoID.IsReadOnly = false;
            txtRunTimeM.Text = "";
            txtRunTimeS.Text = "";
            txtVideoDesc.Text = "";
            txtVideoID.Text = "";
            chkVideoActive.IsChecked = true;
            chkVideoActive.IsEnabled = false;
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY: Jordan Lindo
        /// 
        /// Helper method for showing the Add/Edit form on the page
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Chase Schulte
        /// UPDATE DATE: 03/01/2020
        /// CHANGE: Added edit mode if/else, show checkbox for sorting by active, hide checkbox for deactivating/activating videos
        /// 
        /// </remarks>

        private void showPrompt()
        {
            canViewVideos.Visibility = Visibility.Hidden;

            canAdd.Visibility = Visibility.Visible;
            if (_editMode == true)
            {
                txtVideoID.IsReadOnly = false;
                txtRunTimeM.IsReadOnly = false;
                txtRunTimeS.IsReadOnly = false;
                txtVideoDesc.IsReadOnly = false;
                chkVideoActive.IsEnabled = true;
            }
            else if (_editMode == false)
            {
                txtVideoID.IsReadOnly = true;
                txtRunTimeM.IsReadOnly = true;
                txtRunTimeS.IsReadOnly = true;
                txtVideoDesc.IsReadOnly = true;
                chkVideoActive.IsEnabled = false;
            }
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY: Jordan Lindo
        /// 
        /// Event handler for the Save button
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Chase Schulte
        /// UPDATE DATE: 03/01/2020
        /// CHANGE: Added update mode functionality
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
            if (_insertMode == true)
            {
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
            if (_insertMode == false)
            {
                try
                {
                    bool result = _videoManager.EditTrainingVideo(_trainingVideo, newVideo);
                    if (result)
                    {
                        MessageBox.Show("Video Modified.");
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
        }

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY: Jordan Lindo
        /// 
        /// Helper method to hide the Add/Edit form on the page
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Chase Schulte
        /// UPDATE DATE: 03/03/2020
        /// CHANGE: Added Hide for Actie for datagrid checkbox and Edit button for  
        /// 
        /// </remarks>
        private void hidePrompt()
        {
            canAdd.Visibility = Visibility.Hidden;
            canViewVideos.Visibility = Visibility.Visible;

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
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Edit a specific video
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/06/2020
        /// Update: Added visibility not visible for datagrid
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditVideo_Click(object sender, RoutedEventArgs e)
        {
            if (dgVideoList.SelectedItem != null)
            {
                _editMode = true;
                _insertMode = false;
                _trainingVideo = (TrainingVideo)dgVideoList.SelectedItem;
                showPrompt();
                txtVideoID.IsReadOnly = true;
                txtRunTimeM.Text = _trainingVideo.RunTimeMinutes.ToString();
                txtRunTimeS.Text = _trainingVideo.RunTimeSeconds.ToString();
                txtVideoDesc.Text = _trainingVideo.Description.ToString();
                txtVideoID.Text = _trainingVideo.TrainingVideoID.ToString();
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// View a specific video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnViewVideo_Click(object sender, RoutedEventArgs e)
        {
            if (dgVideoList.SelectedItem != null)
            {
                _editMode = false;
                _insertMode = false;
                _trainingVideo = (TrainingVideo)dgVideoList.SelectedItem;
                showPrompt();
                txtRunTimeM.Text = _trainingVideo.RunTimeMinutes.ToString();
                txtRunTimeS.Text = _trainingVideo.RunTimeSeconds.ToString();
                txtVideoDesc.Text = _trainingVideo.Description.ToString();
                txtVideoID.Text = _trainingVideo.TrainingVideoID.ToString();
                chkVideoActive.IsChecked = _trainingVideo.Active;
                btnSaveVideo.Visibility = Visibility.Hidden;
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Select a video");
            }

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Activate/Deactivate a video
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkVideoActive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(bool)chkVideoActive.IsChecked)
                {
                    _videoManager.DeactivateTrainingVideo(_trainingVideo);
                    populateVideoList();

                }
                else if ((bool)chkVideoActive.IsChecked)
                {
                    _videoManager.ActivateTrainingVideo(_trainingVideo);
                    populateVideoList();
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.ToString());
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Sort by active/inactive videos
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkVideosActive_Click(object sender, RoutedEventArgs e)
        {
            populateVideoList();


            if (chkVideoActive.IsChecked == true)
            {
                lblActiveVideos.Content = "Inactive";
            }
            else
            {
                lblActiveVideos.Content = "Active";
            }

        }
    }
}
