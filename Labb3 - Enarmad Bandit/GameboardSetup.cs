using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Enarmad_Bandit
{
    public class GameBoardSetup
    {
        double winValue;
        string slotType;

        static Random randomValue = new Random();

        public GameBoardSetup()
        {

        }

        public double WinValue { get => winValue; }
        public string SlotType { get => slotType; }

        public static int GetSlotFigure()
        {
            int number = randomValue.Next(1, 101);
            return number;
        }
        // Set the new cards upon a new spin
        public static string SetSlotCard(int value, GameBoardSetup element)
        {
            if (value > 0 && value < 3)
            {
                element.winValue = 500;
                element.slotType = "Diamond";
                return "C:/Users/MiniTomato/Source/Repos/Enarmad-Bandit/Enarmad Bandit/Diamond.jpg";
            }
            if (value > 2 && value < 11)
            {
                element.winValue = 20;
                element.slotType = "King";
                return "C:/Users/MiniTomato/Source/Repos/Enarmad-Bandit/Enarmad Bandit/King.jpg";
            }
            if (value > 10 && value < 26)
            {
                element.winValue = 8;
                element.slotType = "Queen";
                return "C:/Users/MiniTomato/Source/Repos/Enarmad-Bandit/Enarmad Bandit/Queen.jpg";
            }
            if (value > 25 && value < 46)
            {
                element.winValue = 5;
                element.slotType = "Jack";
                return "C:/Users/MiniTomato/Source/Repos/Enarmad-Bandit/Enarmad Bandit/Jack.jpg";
            }
            if (value > 45 && value < 71)
            {
                element.winValue = 2;
                element.slotType = "Ten";
                return "C:/Users/MiniTomato/Source/Repos/Enarmad-Bandit/Enarmad Bandit/Ten.jpg";
            }
            if (value > 70 && value < 101)
            {
                element.winValue = 1.5;
                element.slotType = "Nine";
                return "Enarmad Bandit/Nine.jpg";
            }
            return "error wrong value to set slotcard";
        }
        //Change the Image to the set card
        public static void ChangeSlotImage(Image SlotElement, string path)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(path, UriKind.Absolute);
            src.EndInit();
            SlotElement.Source = src;
        }

        public static double CalculateWin(double winValue, double credit)
        {
            double win;
            win = credit * (winValue);
            return win;
        }
    }
}
