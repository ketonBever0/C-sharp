using Microsoft.Win32;
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


namespace WpfAutok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AutoDataContext autoDataContext;
        public MainWindow()
        {
            InitializeComponent();


        }


        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";


            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    autoDataContext = new AutoDataContext(openFileDialog.FileName);
                    DataContext = autoDataContext;
                    datagridAutok.ItemsSource = autoDataContext.Autok;

                    filenameBlock.Text = openFileDialog.SafeFileName;
                    filenameBlock.ToolTip = openFileDialog.FileName;

                    minPrice.Text = "";
                    maxPrice.Text = "";

                    minPrice.IsEnabled = true;
                    maxPrice.IsEnabled = true;

                    revertButton.IsEnabled = false;
                    searchButton.IsEnabled = true;
                    unloadFileButton.IsEnabled = true;

                    datagridAutok.IsEnabled = true;
                    //MessageBox.Show("Sikeres fájlbetöltés!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var min = 0;
            var max = autoDataContext.Autok.Max(x => x.Ar);

            try
            {
                if (minPrice.Text != "") min = Convert.ToInt32(minPrice.Text);
                if (maxPrice.Text != "") max = Convert.ToInt32(maxPrice.Text);

                if (min > max) { MessageBox.Show("Alsóhatár nem lehet nagyobb, mint a felső!"); return; }

            }
            catch
            {
                MessageBox.Show("Egész számot adjon meg!");
                return;
            }


            var filtered = autoDataContext.Autok.FindAll(x => x.Ar >= min && x.Ar <= max);

            if (filtered.Count > 0)
            {
                datagridAutok.ItemsSource = filtered;
                searchButton.IsEnabled = true;
                revertButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Nincs a keresésnek megfelelő adat");
            }


        }

        private void RevertButton_Click(object sender, RoutedEventArgs e)
        {
            datagridAutok.ItemsSource = autoDataContext.Autok;

            minPrice.Text = "";
            maxPrice.Text = "";

            revertButton.IsEnabled = false;
        }

        private void UnloadFileButton_Click(object sender, RoutedEventArgs e)
        {

            datagridAutok.ItemsSource = null;
            datagridAutok.IsEnabled = false;

            filenameBlock.Text = "(nincs)";
            filenameBlock.ToolTip = null;

            minPrice.Text = "";
            maxPrice.Text = "";

            minPrice.IsEnabled = false;
            maxPrice.IsEnabled = false;
            searchButton.IsEnabled = false;
            revertButton.IsEnabled = false;
            unloadFileButton.IsEnabled = false;


        }
    }
}
