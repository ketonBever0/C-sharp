using Microsoft.EntityFrameworkCore;
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
using WpfMagyarVarosok.Models;

namespace WpfMagyarVarosok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //magyar_telepulesekContext telepulesekContext;
        ContextAdapter contextAdapter;
        public MainWindow()
        {
            InitializeComponent();
            contextAdapter = new ContextAdapter();
            contextAdapter.context.SaveChanges();

            //telepulesekContext = new magyar_telepulesekContext();
            //telepulesekContext.Telepulesek.Load();
            //telepulesekContext.Jogallas.Load();
            //telepulesekContext.Megyek.Load();

            //datagridJogallas.ItemsSource = telepulesekContext.Jogallas.Local.ToObservableCollection();
            //datagridTelepulesek.ItemsSource = telepulesekContext.Telepulesek.Local.ToObservableCollection();
            //datagridMegyek.ItemsSource = telepulesekContext.Megyek.Local.ToObservableCollection();



            DataContext = contextAdapter;
        }

        private void DbUpdate()
        {
            var process = contextAdapter.context.SaveChanges();
            if (process > 0)
            {
                MessageBox.Show("Adatok mentve!");
            }
            else
            {
                MessageBox.Show("Nincs változás!");
            }
        }

        private void DbUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            DbUpdate();
        }
    }
}
