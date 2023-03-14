using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FontAwesome.WPF;

namespace Aknakereso
{
    class GameItem
    {

        public FontAwesome.WPF.FontAwesome[] elemek;

        public Label UpLayer;
        public Label DownLayer;

        public bool Covered;

        public bool Flagged;

        public void SetUpLayer(int elem)
        {
            StackPanel pn = new StackPanel();

            pn.Children.Add(elemek[elem]);
            UpLayer.MinHeight = 40;
            UpLayer.Margin = new Thickness(1);
            UpLayer.VerticalAlignment = VerticalAlignment.Center;
            UpLayer.HorizontalAlignment = HorizontalAlignment.Center;
            UpLayer.Background = Brushes.AliceBlue;
            UpLayer.Content = pn;

        }

        public void SetDownLayer(int elem)
        {
            StackPanel pn = new StackPanel();

            pn.Children.Add(elemek[elem]);
            DownLayer.MinHeight = 40;
            DownLayer.Margin = new Thickness(1);
            DownLayer.VerticalAlignment = VerticalAlignment.Center;
            DownLayer.HorizontalAlignment = HorizontalAlignment.Center;
            DownLayer.Background = Brushes.AliceBlue;
            DownLayer.Content = pn;

        }

        public Label GetUpLayer()
        {
            return UpLayer;
        }

        public Label GetDownLayer()
        {
            return DownLayer;
        }

        public GameItem(int up, int down)
        {
            UpLayer = new Label();
            DownLayer = new Label();

            elemek = new FontAwesome.WPF.FontAwesome[12];
            for (var i = 0; i < elemek.Length; i++)
            {
                elemek[i] = new FontAwesome.WPF.FontAwesome();
            }

            elemek[0].Icon = FontAwesomeIcon.Bomb;
            elemek[0].FontSize = 20;
            elemek[1].Text = "1";
            elemek[1].FontSize = 20;
            elemek[2].Text = "2";
            elemek[2].FontSize = 20;
            elemek[3].Text = "3";
            elemek[3].FontSize = 20;
            elemek[4].Text = "4";
            elemek[4].FontSize = 20;
            elemek[5].Text = "5";
            elemek[5].FontSize = 20;
            elemek[6].Text = "6";
            elemek[6].FontSize = 20;
            elemek[7].Text = "7";
            elemek[7].FontSize = 20;
            elemek[8].Text = "7";
            elemek[8].FontSize = 20;
            elemek[9].Icon = FontAwesomeIcon.Flag;
            elemek[9].FontSize = 20;
            elemek[10].Icon = FontAwesomeIcon.Square;
            elemek[10].FontSize = 20;
            elemek[10].Foreground = Brushes.Beige;
            elemek[11].Icon = FontAwesomeIcon.SquareOutline;
            elemek[11].FontSize = 20;

            SetUpLayer(up);
            SetDownLayer(down);
            Covered = true;
            Flagged = false;


        }

        public void ChangeUpIcon(int elem)
        {
            StackPanel pn = (StackPanel)UpLayer.Content;
            FontAwesome.WPF.FontAwesome actIcon = (FontAwesome.WPF.FontAwesome)pn.Children[0];
            actIcon.Icon = elemek[elem].Icon;

        }



    }
}
