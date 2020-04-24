using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace WPFPresentationLayer.AMPages
{

    public partial class NewAnimals : Page
    {
        public NewAnimals()
        {
            InitializeComponent();

            Storyboard spinStoryboard = Resources["SlideBack"] as Storyboard;


            Categories.Visibility = Visibility.Hidden;

            CancelPrint_.Visibility = Visibility.Hidden;

            PrintOptions.Visibility = Visibility.Hidden;

            PrintPreview.Visibility = Visibility.Hidden;

            _animalManager = new AnimalManager();

            cmbAnimalSpecies.ItemsSource = _animalManager.RetrieveAnimalSpecies();

            NewAnimalChecklist.Visibility = Visibility.Hidden;

            _animalManager = new AnimalManager();

            _ChecklistManager = new NewAnimalChecklistManager();

            _MHManager = new AnimalMedicalHistoryManager();

            NumberOfActiveAnimals = _ChecklistManager.RetrieveNumberOfAnimals();

        }

        private IAnimalManager _animalManager;

        private INewAnimalChecklistManager _ChecklistManager;

        private IAnimalMedicalHistoryManager _MHManager;

        public int NumberOfActiveAnimals { get; set; }


        private void refreshActiveData()
        {
            an = _animalManager.RetrieveAnimalsByActive();


            dgActiveAnimals.ItemsSource = (from c in an
                                           where c.ArrivalDate >= DateTime.Today.AddDays(-30)
                                           select c).ToList().OrderByDescending(c => c.ArrivalDate);

            dgActiveAnimals.Columns[0].IsReadOnly = true;

            dgActiveAnimals.Columns[2].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[3].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[4].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[5].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[6].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[7].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[8].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[9].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[10].Visibility = Visibility.Hidden;

            dgActiveAnimals.Columns[1].IsReadOnly = true;
            dgActiveAnimals.Columns[2].IsReadOnly = true;
            dgActiveAnimals.Columns[3].IsReadOnly = true;
            dgActiveAnimals.Columns[4].IsReadOnly = true;
            dgActiveAnimals.Columns[8].IsReadOnly = true;

        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Finish and save your update
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void CompleteUpdateButton(object sender, RoutedEventArgs e)
        {
            PrintButton_.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            CompUpdate.Visibility = Visibility.Hidden;
            Vaccinations_.Visibility = Visibility.Visible;

            MRVDate.Visibility = Visibility.Visible;

            SN.Visibility = Visibility.Visible;

            ImportantNotes.Visibility = Visibility.Visible;

            MRVDatePicker.Visibility = Visibility.Hidden;

            NewVacc.Visibility = Visibility.Hidden;

            NewSN.Visibility = Visibility.Hidden;

            MedicalHistory New_ =
               new MedicalHistory()
               {
                   AnimalID = Int32.Parse(AnimalIDNumber.Content.ToString()),

                   Spayed_Neutered = NewSN.IsChecked,


               };

            MedicalHistory Old_ =
              new MedicalHistory()
              {
                  Vaccinations = Vaccinations_.ToString(),
                  Spayed_Neutered = SN.IsChecked,
                  MostRecentVaccinationDate = DateTime.Parse(MRVDate.Content.ToString()),
                  AdditionalNotes = ImportantNotes.ToString()

              };

            List<NewAnimalChecklist> List = _ChecklistManager.RetrieveNewAnimalChecklistByAnimalID(Int32.Parse(AnimalIDNumber.Content.ToString()));



            NewAnimalChecklist NAC = (NewAnimalChecklist)List[0];

            ImportantNotes.Content = NewAdditonalNotes.Text;

            if (NewVacc.Text != "")
            {
                New_.Vaccinations = NewVacc.Text;
                Vaccinations_.Content = NewVacc.Text;
            }
            else
            {
                Vaccinations_.Content = NAC.Vaccinations.ToString();
                New_.Vaccinations = Vaccinations_.Content.ToString();
            }

            if (NewAdditonalNotes.Text != "" || NewAdditonalNotes.Text != null)
            {
                New_.AdditionalNotes = NewAdditonalNotes.Text;
                ImportantNotes.Content = NewAdditonalNotes.Text;
            }

            if (NewAdditonalNotes.Text == "" || NewAdditonalNotes.Text == null)
            {
                ImportantNotes.Content = NAC.AdditionalNotes.ToString();
                New_.AdditionalNotes = ImportantNotes.Content.ToString();
            }

            if (MRVDatePicker.SelectedDate == null)
            {
                MRVDate.Content = DateTime.Today;
                New_.MostRecentVaccinationDate = DateTime.Today;
            }
            else
            {
                MRVDate.Content = MRVDatePicker.SelectedDate.ToString();
                New_.MostRecentVaccinationDate = MRVDatePicker.SelectedDate;
            }

            SN.IsChecked = New_.Spayed_Neutered = NewSN.IsChecked;
            ImportantNotes.Visibility = Visibility.Visible;


            _MHManager.UpdateAnimalMedicalHistory(Old_, New_);



            NewAnimalChecklist.Visibility = Visibility.Visible;

            SelectAnimalMessage.Visibility = Visibility.Hidden;

            PrintPreview.Visibility = Visibility.Hidden;
            PrintPreview.Visibility = Visibility.Visible;

            NewAdditonalNotes.Visibility = Visibility.Hidden;


        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Handles retrieving the names of the most recent animals
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refreshActiveData();
        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Selects an animal name and opens the new animal checklist
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DataGridRow_Selected_1(object sender, RoutedEventArgs e)
        {
            Categories.Visibility = Visibility.Hidden;

            NewAnimalChecklist.Visibility = Visibility.Visible;

            SelectAnimalMessage.Visibility = Visibility.Hidden;
            List<NewAnimalChecklist> List = null;

            NewAnimalChecklistManager _ChecklistManager = new NewAnimalChecklistManager();


            Animal ID = (Animal)dgActiveAnimals.Items[0];


            try
            {

                List = _ChecklistManager.RetrieveNewAnimalChecklistByAnimalID(Int32.Parse(ID.ToString()));


            }
            catch (FormatException ex)
            {
            }

            if (dgActiveAnimals.Visibility == Visibility.Visible)
            {

                try
                {
                    try
                    {
                        object item = dgActiveAnimals.SelectedItem;
                        string ID_ = (dgActiveAnimals.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                        List = _ChecklistManager.RetrieveNewAnimalChecklistByAnimalID(Int32.Parse(ID_));

                        NewAnimalChecklist NAC = (NewAnimalChecklist)List[0];
                        PrintPreview.Visibility = Visibility.Visible;

                        Date_.Content = DateTime.Today.ToString();

                        AnimalName.Content = NAC.AnimalName.ToString();

                        AnimalIDNumber.Content = NAC.AnimalID.ToString();

                        DateArrived.Content = NAC.ArrivalDate.ToString();

                        Species.Content = NAC.AnimalSpeciesID.ToString();

                        DOB.Content = NAC.DOB.ToString();

                        Breed.Content = NAC.AnimalBreed.ToString();

                        Vaccinations_.Content = NAC.Vaccinations.ToString();

                        MRVDate.Content = NAC.MostRecentVaccinationDate.ToString();

                        RTBA.IsChecked = NAC.Adoptable;

                        CS.IsChecked = NAC.CurrentlyHoused;

                        SN.IsChecked = NAC.Spayed_Neutered;

                        Warning.Content = NAC.TempermantWarning.ToString();

                        ImportantNotes.Content = NAC.AdditionalNotes.ToString();
                    }
                    catch
                    {

                    }

                }
                catch (FormatException ex)
                {


                }


            }


            return;
        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Handles changing the selection on the datagrid
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgActiveAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrintButton_.Visibility = Visibility.Visible;
            SelectAnimalMessage.Visibility = Visibility.Hidden;
            List<NewAnimalChecklist> List = null;

            NewAnimalChecklistManager _ChecklistManager = new NewAnimalChecklistManager();

            if (dgActiveAnimals.Visibility == Visibility.Visible)
            {

                try
                {
                    try
                    {
                        object item = dgActiveAnimals.SelectedItem;
                        string ID = (dgActiveAnimals.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                        List = _ChecklistManager.RetrieveNewAnimalChecklistByAnimalID(Int32.Parse(ID));

                        NewAnimalChecklist NAC = (NewAnimalChecklist)List[0];
                        PrintPreview.Visibility = Visibility.Visible;

                        Date_.Content = DateTime.Today.ToString();

                        AnimalName.Content = NAC.AnimalName.ToString();

                        AnimalIDNumber.Content = NAC.AnimalID.ToString();

                        DateArrived.Content = NAC.ArrivalDate.ToString();

                        Species.Content = NAC.AnimalSpeciesID.ToString();

                        DOB.Content = NAC.DOB.ToString();



                        Breed.Content = NAC.AnimalBreed.ToString();

                        Vaccinations_.Content = NAC.Vaccinations.ToString();

                        MRVDate.Content = NAC.MostRecentVaccinationDate.ToString();

                        RTBA.IsChecked = NAC.Adoptable;

                        CS.IsChecked = NAC.CurrentlyHoused;

                        SN.IsChecked = NAC.Spayed_Neutered;


                        Warning.Content = NAC.TempermantWarning.ToString();

                        ImportantNotes.Content = NAC.AdditionalNotes.ToString();
                    }
                    catch
                    {

                    }

                }
                catch (FormatException ex)
                {


                }
            }



            return;
        }



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Begin setting up document to print
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void PrintButton(object sender, RoutedEventArgs e)
        {
            DP_Name.Visibility = Visibility = Visibility;



            CancelPrint_.Visibility = Visibility.Hidden;

            PrintOptions.Visibility = Visibility.Hidden;

            PrintButton_.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;

            SelectAnimalMessage.Visibility = Visibility.Hidden;
            List<NewAnimalChecklist> List = null;

            NewAnimalChecklistManager _ChecklistManager = new NewAnimalChecklistManager();

            try
            {
                try
                {
                    object item = dgActiveAnimals.SelectedItem;
                    string ID = (dgActiveAnimals.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    List = _ChecklistManager.RetrieveNewAnimalChecklistByAnimalID(Int32.Parse(ID));

                    NewAnimalChecklist NAC = (NewAnimalChecklist)List[0];
                    PrintPreview.Visibility = Visibility.Visible;

                    Date_.Content = DateTime.Today.ToString();

                    AnimalName.Content = NAC.AnimalName.ToString();

                    DP_Name.Text = "Printing  " + NAC.AnimalName.ToString() + "'s records";

                    AnimalIDNumber.Content = NAC.AnimalID.ToString();

                    DP_AID.Text = "AnimalID: " + NAC.AnimalID.ToString();

                    PetUniverseUser _user = new PetUniverseUser();

                    DateArrived.Content = NAC.ArrivalDate.ToString();

                    Species.Content = NAC.AnimalSpeciesID.ToString();

                    DOB.Content = NAC.DOB.ToString();

                    Breed.Content = NAC.AnimalBreed.ToString();

                    Vaccinations_.Content = NAC.Vaccinations.ToString();

                    MRVDate.Content = NAC.MostRecentVaccinationDate.ToString();

                    Fixed.Visibility = Visibility.Visible;

                    CurrentlySheltered.Visibility = Visibility.Visible;

                    Adoptable.Visibility = Visibility.Visible;

                    RTBA.Visibility = Visibility.Hidden;

                    CS.Visibility = Visibility.Hidden;

                    SN.Visibility = Visibility.Hidden;

                    if (NAC.Spayed_Neutered == true)
                    {
                        Fixed.Content = "Yes";

                    }
                    else
                    {
                        Fixed.Content = "No";
                    }

                    if (NAC.CurrentlyHoused == true)
                    {
                        CurrentlySheltered.Content = "Yes";

                    }
                    else
                    {
                        CurrentlySheltered.Content = "No";
                    }

                    if (NAC.Adoptable == true)
                    {
                        Adoptable.Content = "Yes";

                    }
                    else
                    {
                        Adoptable.Content = "No";
                    }

                    Warning.Content = NAC.TempermantWarning.ToString();

                    ImportantNotes.Content = NAC.AdditionalNotes.ToString();
                }
                catch { }

            }
            catch (FormatException ex)
            {


            }

            return;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Begin updating 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void UpdateButton(object sender, RoutedEventArgs e)
        {

            PrintButton_.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            CompUpdate.Visibility = Visibility.Visible;
            Vaccinations_.Visibility = Visibility.Hidden;

            MRVDate.Visibility = Visibility.Hidden;

            SN.Visibility = Visibility.Hidden;

            ImportantNotes.Visibility = Visibility.Hidden;

            NewAdditonalNotes.Visibility = Visibility.Visible;

            NewVacc.Visibility = Visibility.Visible;

            NewSN.Visibility = Visibility.Visible;

            NewAdditonalNotes.Clear();

            NewVacc.Clear();

            MRVDatePicker.SelectedDate = null;

            MRVDatePicker.Visibility = Visibility.Visible;

            NewSN.IsChecked = SN.IsChecked;



        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Cancel printing
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void CancelPrint(object sender, RoutedEventArgs e)
        {
            PrintOptions.Visibility = Visibility.Hidden;

            PrintButton_.Visibility = Visibility.Visible;

            CancelPrint_.Visibility = Visibility.Hidden;


            Update.Visibility = Visibility.Visible;


            try
            {
                if (Fixed.Content.Equals("Yes"))
                {
                    SN.IsChecked = true;
                    Fixed.Visibility = Visibility.Hidden;
                    SN.Visibility = Visibility.Visible;
                }
                else
                {
                    SN.IsChecked = false;
                    Fixed.Visibility = Visibility.Hidden;
                    SN.Visibility = Visibility.Visible;
                }

                if (CurrentlySheltered.Content.Equals("Yes"))
                {
                    CS.IsChecked = true;
                    CurrentlySheltered.Visibility = Visibility.Hidden;
                    CS.Visibility = Visibility.Visible;
                }
                else
                {
                    CS.IsChecked = false;
                    CurrentlySheltered.Visibility = Visibility.Hidden;
                    CS.Visibility = Visibility.Visible;
                }

                if (Adoptable.Content.Equals("Yes"))
                {
                    RTBA.IsChecked = true;
                    Adoptable.Visibility = Visibility.Hidden;
                    RTBA.Visibility = Visibility.Visible;
                }
                else
                {
                    RTBA.IsChecked = false;
                    Adoptable.Visibility = Visibility.Hidden;
                    RTBA.Visibility = Visibility.Visible;
                }
            }
            catch
            {

            }

        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Handles what happens after a storyboard is complete
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void Story_Completed(object sender, EventArgs e)
        {
            CancelPrint_.Visibility = Visibility.Visible;

            PrintOptions.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Displays the options for printing
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ShowPrintOptionsButton(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.PrintDialog dialog = new System.Windows.Forms.PrintDialog();

            dialog.Document = this.GetPrintDocument();
            dialog.AllowSomePages = true;
            dialog.AllowCurrentPage = true;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dialog.Document.Print();
            }
        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Method to handle default options for printing
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public System.Drawing.Printing.PrintDocument GetPrintDocument()
        {
            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument.DefaultPageSettings.Landscape = false; // Set orientation here

            printDocument.PrinterSettings.MaximumPage = 1;// set maximum page count here
            bool isCalculatedrange = false;
            int printedpagescount = 0;
            int startPage = 0;
            int printPageCount = 0;


            printDocument.PrintPage += (s, args) =>
            {
                try
                {
                    if (printDocument.PrinterSettings.ToPage > 0 && !isCalculatedrange)
                    {
                        startPage = printDocument.PrinterSettings.FromPage - 1;
                        printPageCount = (printDocument.PrinterSettings.ToPage - printDocument.PrinterSettings.FromPage) + 1 > printPageCount ? printPageCount : (printDocument.PrinterSettings.ToPage - printDocument.PrinterSettings.FromPage) + 1;
                        isCalculatedrange = true;
                    }

                    args.Graphics.DrawImage(GetImageFromUIElement(grd_Page, 96, 96),
                        new System.Drawing.Rectangle(printDocument.PrinterSettings.DefaultPageSettings.Margins.Left, printDocument.PrinterSettings.DefaultPageSettings.Margins.Top, (int)grd_Page.ActualWidth, (int)grd_Page.ActualHeight));
                    startPage++;
                    printedpagescount++;
                    args.HasMorePages = startPage < printPageCount;

                    if (isCalculatedrange)
                    {
                        args.HasMorePages = (printPageCount != printedpagescount);
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "\n StackTrace: \n" + e.StackTrace);
                }
            };

            printDocument.EndPrint += (s, args) =>
            {
                MessageBox.Show("Printer not found");
            };

            return printDocument;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Figures out what to print
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public static System.Drawing.Image GetImageFromUIElement(Grid source, int dpix, int dpiy)
        {
            int width = (int)source.ActualWidth;
            int height = (int)source.ActualHeight;

            if (width == 0)
                width = (int)source.Width;
            if (height == 0)
                height = (int)source.Height;

            int dpiwidth = (int)((width * dpix) / 96);
            int dpiheight = (int)((height * dpiy) / 96);

            RenderTargetBitmap bitmap = new RenderTargetBitmap(dpiwidth, dpiheight, dpix, dpiy, PixelFormats.Pbgra32);
            bitmap.Render(source);

            var encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                source.Clip = null;
                bitmap.Freeze();
                bitmap.Clear();
                return System.Drawing.Image.FromStream(stream);
            }
        }
        List<Animal> an = new List<Animal>();

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Button to display a list of date filters
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void Filter(object sender, RoutedEventArgs e)
        {
            if (Categories.Visibility == Visibility.Visible)
            {
                Categories.Visibility = Visibility.Hidden;
            }
            else
            {

                Categories.Visibility = Visibility.Visible;
            }

            List<string> cat = new List<string>();
            cat.Add("One Month");

            cat.Add("Two Months");

            cat.Add("Three Months");

            cat.Add("Four Months");

            cat.Add("One Year");

            Categories.ItemsSource = cat;

            an = _animalManager.RetrieveAnimalsByActive();

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Double click event for filtering by arrival date
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DateFilterList_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            int Num = 0;

            string ID = (Categories.SelectedItem).ToString();
            if (ID == "One Month")
            {
                Num = 30;
            }

            if (ID == "Two Months")
            {
                Num = 60;
            }

            if (ID == "Three Months")
            {
                Num = 90;
            }

            if (ID == "Four Months")
            {
                Num = 120;

            }

            if (ID == "One Year")
            {
                Num = 365;

            }

            an = _animalManager.RetrieveAnimalsByActive();


            dgActiveAnimals.ItemsSource = (from c in an
                                           where c.ArrivalDate >= DateTime.Today.AddDays(-Num)

                                           select c).ToList().OrderByDescending(c => c.ArrivalDate);


            dgActiveAnimals.Columns[0].IsReadOnly = true;

            dgActiveAnimals.Columns[2].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[3].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[4].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[5].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[6].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[7].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[8].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[9].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[10].Visibility = Visibility.Hidden;

            dgActiveAnimals.Columns[1].IsReadOnly = true;
            dgActiveAnimals.Columns[2].IsReadOnly = true;
            dgActiveAnimals.Columns[3].IsReadOnly = true;
            dgActiveAnimals.Columns[4].IsReadOnly = true;
            dgActiveAnimals.Columns[8].IsReadOnly = true;


        }


    }


}

