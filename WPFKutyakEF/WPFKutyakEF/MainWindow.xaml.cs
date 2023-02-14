using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WPFKutyakEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KutyakDB kutyaModel;



        public MainWindow()
        {
            InitializeComponent();
            kutyaModel = new KutyakDB();
            kutyaModel.Kutyafajtak.Load();
            kutyaModel.Kutyanevek.Load();
            kutyaModel.Kutyak.Load();

            DataContext = kutyaModel;

        }


        private void DbUpdate()
        {
            var muvelet = kutyaModel.SaveChanges();
            if (muvelet > 0)
            {
                MessageBox.Show("Adatbázis frissítve");
            }
            else
            {
                MessageBox.Show("Nem történt változás");
            }
        }


        private void buttonNevModosit_Click(object sender, RoutedEventArgs e)
        {
            DbUpdate();
        }

        private void buttonFajtaNevModosit_Click(object sender, RoutedEventArgs e)
        {
            DbUpdate();
        }

        private void buttonRendelesiAdatModosit_Click(object sender, RoutedEventArgs e)
        {
            DbUpdate();
        }
    }
}
