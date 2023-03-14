using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Aknakereso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameItem[,] gameItems;
        int sor;
        int oszlop;
        bool isBomb;
        BombPos bombaHelyek;

        public MainWindow()
        {
            InitializeComponent();

            sor = 20;
            oszlop = 20;
            gameItems = new GameItem[sor, oszlop];

            for (int i = 0; i < gameItems.GetLength(0); i++)
            {
                for (int j = 0; j < gameItems.GetLength(1); j++)
                {
                    gameItems[i, j] = new GameItem(11, 10);
                }
            }
            isBomb = false;
            CreateGrid(sor, oszlop);

            Aknarako(sor, oszlop, alapGrid);

        }

        public void CreateGrid(int sor, int oszlop)
        {
            Grid mineGrid = new Grid();

            for (int i = 0; i < sor; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                mineGrid.RowDefinitions.Add(rowdef);
            }

            for (int i = 0; i < sor; i++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                mineGrid.ColumnDefinitions.Add(coldef);
            }

            for (int i = 0; i < sor; i++)
            {
                for (int j = 0; j < oszlop; j++)
                {
                    mineGrid.Children.Add(gameItems[i, j].GetUpLayer());
                    Grid.SetRow(gameItems[i, j].GetUpLayer(), i);
                    Grid.SetColumn(gameItems[i, j].GetUpLayer(), j);
                    gameItems[i, j].GetUpLayer().MouseRightButtonDown += FlagClick;
                    gameItems[i, j].GetUpLayer().MouseLeftButtonDown += ItemClick;
                }

            }
            alapGrid.Children.Add(mineGrid);
        }

        public void Aknarako(int sor, int oszlop, Grid alapGrid)
        {
            var aknaSzam = (sor * oszlop) / 10;

            bombaHelyek = new BombPos(20, 20, aknaSzam);

            foreach (Grid mineGrid in alapGrid.Children)
            {
                foreach (Label item in mineGrid.Children)
                {
                    var s = Grid.GetRow(item);
                    var o = Grid.GetColumn(item);

                    if (bombaHelyek.bombak.Any(x => x.sor == s && x.oszlop == 0))
                    {
                        gameItems[s, o].SetDownLayer(0);
                    }
                }
            }

        }

        private bool IsMine(Label aktItem)
        {
            StackPanel aktPanel = (StackPanel)aktItem.Content;

            FontAwesome.WPF.FontAwesome element = (FontAwesome.WPF.FontAwesome)aktPanel.Children[0];


            if (element.Icon == FontAwesome.WPF.FontAwesomeIcon.Bomb)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidPos(int sor, int oszlop)
        {
            if ((sor >= 0 && sor <= gameItems.GetLength(0) - 1) && (oszlop >= 0 && oszlop <= gameItems.GetLength(1) - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int BombNumber(int sor, int oszlop)
        {
            int bombnum = 0;

            if (ValidPos(sor - 1, oszlop - 1))
            {
                if (IsMine(gameItems[sor - 1, oszlop - 1].GetDownLayer()))
                {
                    bombnum += 1;
                }
            }

            if (ValidPos(sor - 1, oszlop))
            {
                if (IsMine(gameItems[sor - 1, oszlop].GetDownLayer()))
                {
                    bombnum += 1;
                }
            }

            if (ValidPos(sor - 1, oszlop + 1))
            {
                if (IsMine(gameItems[sor - 1, oszlop + 1].GetDownLayer()))
                {
                    bombnum += 1;
                }
            }

            if (ValidPos(sor, oszlop + 1))
            {
                if (IsMine(gameItems[sor, oszlop + 1].GetDownLayer()))
                {
                    bombnum += 1;
                }
            }

            if (ValidPos(sor + 1, oszlop + 1))
            {
                if (IsMine(gameItems[sor + 1, oszlop + 1].GetDownLayer()))
                {
                    bombnum += 1;
                }
            }

            if (ValidPos(sor + 1, oszlop))
            {
                if (IsMine(gameItems[sor + 1, oszlop].GetDownLayer()))
                {
                    bombnum += 1;
                }
            }

            if (ValidPos(sor + 1, oszlop - 1))
            {
                if (IsMine(gameItems[sor + 1, oszlop - 1].GetDownLayer()))
                {
                    bombnum += 1;
                }
            }

            if (ValidPos(sor, oszlop - 1))
            {
                if (IsMine(gameItems[sor, oszlop - 1].GetDownLayer()))
                {
                    bombnum += 1;
                }
            }

            return bombnum;

        }

        public void Szamozas(Grid alapGrid)
        {
            foreach (Grid mineGrid in alapGrid.Children)
            {
                foreach (Label item in mineGrid.Children)
                {
                    var s = Grid.GetRow(item);
                    var o = Grid.GetColumn(item);


                    if (IsMine(gameItems[s, o].GetDownLayer()))
                    {
                        Debug.WriteLine("Bomba!");

                    }
                    else if (BombNumber(s, o) > 0)
                    {
                        gameItems[s, o].SetDownLayer(BombNumber(s, o));
                        Debug.WriteLine($"Bombnum: {BombNumber(s, o)}");
                    }


                }
            }
        }

        public void FlagClick(object sender, RoutedEventArgs e)
        {

            UIElement actGameItem = (UIElement)sender;
            var sora = Grid.GetRow(actGameItem);
            var oszlopa = Grid.GetColumn(actGameItem);

            Label actGameLabel = (Label)sender;


            if (gameItems[sora, oszlopa].Covered)
            {
                if (gameItems[sora, oszlopa].Flagged)
                {
                    gameItems[sora, oszlopa].ChangeUpIcon(10);
                    gameItems[sora, oszlopa].Flagged = !gameItems[sora, oszlopa].Flagged;
                    actGameLabel.Content = gameItems[sora, oszlopa].GetUpLayer().Content;

                }
                else
                {
                    gameItems[sora, oszlopa].ChangeUpIcon(9);
                    gameItems[sora, oszlopa].Flagged = !gameItems[sora, oszlopa].Flagged;
                    actGameLabel.Content = gameItems[sora, oszlopa].GetUpLayer().Content;
                }
            }

        }

        public void UnCover(Grid alapGrid)
        {
            foreach (Grid mineGrid in alapGrid.Children)
            {
                foreach (Label item in mineGrid.Children)
                {
                    var s = Grid.GetRow(item);
                    var o = Grid.GetColumn(item);


                    item.Content = gameItems[s, o].GetDownLayer().Content;
                }
            }
        }

        public void GridFresh(Grid alapGrid)
        {
            foreach (Grid mineGrid in alapGrid.Children)
            {
                foreach (Label item in mineGrid.Children)
                {
                    var s = Grid.GetRow(item);
                    var o = Grid.GetColumn(item);

                    if (!gameItems[s, o].Covered)
                    {
                        item.Content = gameItems[s, o].GetDownLayer().Content;
                    }
                }
            }
        }

        private bool IsNull(Label curItem)
        {
            StackPanel curPanel = (StackPanel)curItem.Content;

            FontAwesome.WPF.FontAwesome element = (FontAwesome.WPF.FontAwesome)curPanel.Children[0];


            if (element.Icon == FontAwesome.WPF.FontAwesomeIcon.Square)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UnCover(int sor, int oszlop, int cnt = 0)
        {

            cnt++;

            gameItems[sor, oszlop].Covered = false;

            Label item = gameItems[sor, oszlop].GetDownLayer();


            for (int i = Math.Max(sor - 1, 0); i <= Math.Min(sor + 1, gameItems.GetLength(0) - 1); i++)
            {
                for (int j = Math.Max(oszlop - 1, 0); j <= Math.Min(oszlop + 1, gameItems.GetLength(1) - 1); j++)
                {

                    if (IsNull(item) && cnt <= 50 && gameItems[i, j].Covered)
                    {
                        gameItems[i, j].Covered = false;
                        UnCover(i, j, cnt);
                    }
                }
            }


        }

        public void ItemClick(object sender, RoutedEventArgs e)
        {

            UIElement actGameItem = (UIElement)sender;
            var sora = Grid.GetRow(actGameItem);
            var oszlopa = Grid.GetColumn(actGameItem);

            Label actGameLabel = (Label)sender;

            actGameLabel.Content = gameItems[sora, oszlopa].GetDownLayer().Content;
            gameItems[sora, oszlopa].Covered = false;


            if (IsMine(actGameLabel))
            {
                UnCover(alapGrid);
            }
            if (IsNull(actGameLabel))
            {
                UnCover(sora, oszlopa);
                GridFresh(alapGrid);
            }


        }


    }
}
