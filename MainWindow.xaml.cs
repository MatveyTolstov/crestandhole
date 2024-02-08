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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Крестики
{
    public partial class MainWindow : Window
    {
        static Button[] button = new Button[9];
        string player = "O";
        string bot = "X";
        string[] data;
        int[,] combinations = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }
        private void StartGame()
        {
            restart.Content = "Заново";
            if (player == "0")
            {
                player = "X";
                bot = "0";
            }
            else
            {
                player = "0";
                bot = "X";
            }

            Win.Visibility = Visibility.Visible;

            data = new string[9];

            ClearButtons();
            EnableButtons();

            if (bot == "X")
            {
                BotMove();
            }
        }

        private void EndGame(string winner)
        {
            Win.Visibility = Visibility.Visible;
            Win.Text = $"Победитель: {winner}";
        }
        

        private void EnableButtons()
        {
            _1.IsEnabled = true;
            _2.IsEnabled = true;
            _3.IsEnabled = true;
            _4.IsEnabled = true;
            ___5.IsEnabled = true;
            _6.IsEnabled = true;
            _7.IsEnabled = true;
            _8.IsEnabled = true;
            _9.IsEnabled = true;
        }

        private void ClearButtons()
        {
            _1.Content = "";
            _2.Content = "";
            _3.Content = "";
            _3.Content = "";
            _4.Content = "";
            ___5.Content = "";
            _6.Content = "";
            _7.Content = "";
            _8.Content = "";
            _9.Content = "";


        }
        private string GetWinner()
        {
            for (int i = 0; i < combinations.GetLength(0); ++i)
            {
                string first = data[combinations[i, 0]];
                string second = data[combinations[i, 1]];
                string third = data[combinations[i, 2]];
                if (first == second && second == third)
                {
                    return first;
                }
            }
            bool nichya = true;
            foreach (string value in data)
            {
                if (value == null)
                {
                    nichya = false;
                    break;
                }
            }

            if (nichya)
            {
                return "Ничья";
            }

            return null;
        }
        private void BotMove()
        {
            Random random = new Random();
            List<int> empty = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == null)
                {
                    empty.Add(i);
                }
            }

            int number = random.Next(0, empty.Count);
            int cell = empty[number];
            data[cell] = bot;
            switch (cell)
            {
                case 0:
                    _1.Content = bot;
                    _1.IsEnabled = false;
                    break;
                case 1:
                    _2.Content = bot;
                    _2.IsEnabled = false;
                    break;
                case 2:
                    _3.Content = bot;
                    _3.IsEnabled = false;
                    break;
                case 3:
                    _4.Content = bot;
                    _4.IsEnabled = false;
                    break;
                case 5:
                    ___5.Content = bot;
                    ___5.IsEnabled = false;
                    break;
                case 6:
                    _6.Content = bot;
                    _6.IsEnabled = false;
                    break;
                case 7:
                    _7.Content = bot;
                    _7.IsEnabled = false;
                    break;
                case 8:
                    _8.Content = bot;
                    _8.IsEnabled = false;
                    break;
                case 9:
                    _9.Content = bot;
                    _9.IsEnabled = false;
                    break;
            }
            string winner = GetWinner();
            if (winner != null)
            {
                EndGame(winner);
            }
        }

        private void PlayerMove(int cell)
        {
            data[cell] = player;

            string winner = GetWinner();
            if (winner != null)
            {
                EndGame(winner);
            }
            else
            {
                BotMove();
            }
        }

        //Он в потоке, но скоро он сломается
        private void _1_Click(object sender, RoutedEventArgs e)
        {
            _1.IsEnabled = false;
            _1.Content = player;
            PlayerMove(0);
        }

        private void _2_Click(object sender, RoutedEventArgs e)
        {
            _2.IsEnabled = false;
            _2.Content = player;
            PlayerMove(1);
        }
        private void _3_Click(object sender, RoutedEventArgs e)
        {
            _3.IsEnabled = false;
            _3.Content = player;
            PlayerMove(2);
        }
        private void _4_Click(object sender, RoutedEventArgs e)
        {
            _4.IsEnabled = false;
            _4.Content = player;
            PlayerMove(3);
        }
        private void ___5_Click(object sender, RoutedEventArgs e)
        {
            ___5.IsEnabled = false;
            ___5.Content = player;
            PlayerMove(4);
        }
        private void _6_Click(object sender, RoutedEventArgs e)
        {
            _6.IsEnabled = false;
            _6.Content = player;
            PlayerMove(5);
        }
        private void _7_Click(object sender, RoutedEventArgs e)
        {
            _7.IsEnabled = false;
            _7.Content = player;
            PlayerMove(6);
        }
        private void _8_Click(object sender, RoutedEventArgs e)
        {
            _8.IsEnabled = false;
            _8.Content = player;
            PlayerMove(7);
        }
        private void _9_Click(object sender, RoutedEventArgs e)
        {
            _9.IsEnabled = false;
            _9.Content = player;
            PlayerMove(8);
        }
    }
}
