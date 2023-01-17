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

namespace SuperBowlGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public static int RomanToDecimal(string szam)
        //{
        //    var arab = 0;
        //    for (int i = 0; i < szam.Length; i++)
        //    {
        //        if (i > 0 && Romai(szam[i]) > Romai(szam[i - 1]))
        //        {
        //            arab += Romai(szam[i]) - Romai(szam[i - 1]) * 2;
        //        }
        //        else
        //        {
        //            arab += Romai(szam[i]);
        //        }
        //    }
        //    return arab;
        //}

        public static string RomanToDecimal(string elem)
        {
            switch (elem)
            {
                case "I": return "1";
                case "II": return "2";
                case "III": return "3";
                case "IV": return "4";
                case "V": return "5";
                case "VI": return "6";
                case "VII": return "7";
                case "VIII": return "8";
                case "IX": return "9";
                case "X": return "10";
                default: return "Hiba!";
            }
        }

        public static string DecimalToRoman(string elem)
        {
            switch (elem)
            {
                case "1": return "I";
                case "2": return "II";
                case "3": return "III";
                case "4": return "IV";
                case "5": return "V";
                case "6": return "VI";
                case "7": return "VII";
                case "8": return "VIII";
                case "9": return "IX";
                case "10": return "X";
                default: return "Hiba!";
            }

        }




        public bool ModeToDecimal= true;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void valtas_Click(object sender, RoutedEventArgs e)
        {

            if (ModeToDecimal)
            {
                DecimalBox.Text=Convert.ToString(RomanToDecimal(RomanBox.Text.ToUpper()));
            }
            else
            {
                RomanBox.Text = DecimalToRoman(DecimalBox.Text);
            }

        }

        private void mode_Click(object sender, RoutedEventArgs e)
        {
            RomanBox.Text = "";
            DecimalBox.Text = "";

            if (ModeToDecimal)
            {
                DecimalBox.IsEnabled = true;
                mode.Content = "<---";
                ModeToDecimal=false;
                RomanBox.IsEnabled = false;
            }
            else
            {
                RomanBox.IsEnabled = true;
                mode.Content = "--->";
                ModeToDecimal = true;
                DecimalBox.IsEnabled = false;
            }
        }
    }
}
