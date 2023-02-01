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

namespace BMI_indexWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BMIszamol_Click(object sender, RoutedEventArgs e)
        {
            var gender = "egyse";

            if (FerfiRB.IsChecked == true)
            {
                gender = "ferfi";
            }
            else if(NoRB.IsChecked == true)
            {
                gender = "no";
            }

            //EredmenyBox.Text = gender;

            double testsuly=0, magassag=0;

            if (TestSuly.Text == "" || TestMagassag.Text == "")
            {
                MessageBox.Show("Kérem töltse ki a mezőket!");
            }
            else
            {
                testsuly = Convert.ToDouble(TestSuly.Text);
                magassag = Convert.ToDouble(TestMagassag.Text);
            }
            
            double eredmeny=0;
            double normalisTestsuly = 0;


            //  Férfiak esetén(magasság cm-ben - 100)x0,9
            //  Nők esetén(magasság cm-ben - 100)x0,85

            

            switch (gender)
            {
                case "ferfi":
                    eredmeny = testsuly / Math.Pow(magassag/100, 2);
                    normalisTestsuly = Math.Round((magassag - 100) *0.90);
                    break;
                case "no":
                    eredmeny = testsuly / Math.Pow(magassag/100, 2);
                    normalisTestsuly = Math.Round((magassag - 100) *0.85);
                    break;
                default:
                    MessageBox.Show("Kérem válassza ki a nemét!");
                    break;
            }

            //  16 alatt kóros soványság
            //  16 - 17 mérsékelt soványság
            //  17 - 18,5 enyhe soványság
            //  18,5 - 25 normális testsúly
            //  25 - 30 túlsúly
            //  30 - 35 elhízás
            //  35 - 40 túlzott elhízás
            //  40 fölött extrém elhízás

            string ertekeles="";

            if(eredmeny < 16)
            {
                ertekeles = "Kóros soványság";
            }
            else if(eredmeny>=16 && eredmeny<=17)
            {
                ertekeles = "Mérsékelt soványság";
            }
            else if(eredmeny >= 17 && eredmeny <= 18.5)
            {
                ertekeles = "Enyhe soványság";
            }
            else if(eredmeny >= 18.5 && eredmeny <= 25)
            {
                ertekeles = "Normális testsúly";
            }
            else if (eredmeny >= 25 && eredmeny <= 30)
            {
                ertekeles = "Túlsúly";
            }
            else if (eredmeny >= 30 && eredmeny <= 35)
            {
                ertekeles = "Elhízás";
            }
            else if (eredmeny >= 35)
            {
                ertekeles = "Túlzott elhízás";
            }
            else if (eredmeny >= 40 && eredmeny <= 40)
            {
                ertekeles = "Extrém elhízás";
            }

            if (ertekeles != "")
            {
                ertekelesEredmeny.Text = ertekeles;
            }

            if (eredmeny != 0)
            {
                if (TestSuly.Text != "" || TestMagassag.Text != "")
                {
                    eredmeny = Math.Round(eredmeny, 2);
                    EredmenyBox.Text = $"BMI index: {eredmeny} kg/m^2\n{ertekeles}\nNormállis testsúly: {normalisTestsuly} kg";
                    sulyEredmeny.Text = Math.Round(eredmeny,2).ToString();
                }
            }



        }
    }
}
