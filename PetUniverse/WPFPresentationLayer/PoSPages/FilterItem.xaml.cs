using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Rasha Mohammed
    /// Created: 4/1/2020
    /// Approver: Ethan Holmes
    /// 
    /// This class has interaction logic for the PetUniverseHome window
    /// 
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    /// </summary>
    public partial class FilterItem : Page
    {
        private IPictureManager _pictureManager;
        private Picture _picture = null;

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/1/2020
        /// Approver: Ethan Holmes
        /// 
        /// This is the default constructor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public FilterItem()
        {
            InitializeComponent();
            _pictureManager = new PictureManager();

        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        ///  
        /// This method shows the list of picture when the window loads
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgPictureList_Loaded(object sender, RoutedEventArgs e)
        {
            List<Picture> pictures = _pictureManager.RetrieveAllPictures();
            BitmapImage bitmap = new BitmapImage();
            Image image;

            List<Image> ListPictures = new List<Image>();
            foreach (var picture in pictures)
            {
                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(AppContext.BaseDirectory + @"\images\" + picture.ImagePath);
                bitmap.EndInit();
                image = new Image();
                image.Source = bitmap;

                //image.Height = 200;

                ListPictures.Add(image);
            }

            listImage.ItemsSource = ListPictures;

        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        ///  
        /// This method shows the picture on other page more clear with Double Click.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Image filterimage = (Image)listImage.SelectedItem;

            image.Source = filterimage.Source;

            ViewPicture.Visibility = Visibility.Hidden;

            gdshowImage.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        ///  
        /// This method for buttoun will take you back to the first page.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            gdshowImage.Visibility = Visibility.Hidden;

            ViewPicture.Visibility = Visibility.Visible;


        }
    }
}
