using System.Windows;
using System.Windows.Media;

namespace Enarmad_Bandit
{
    /// <summary>
    /// Interaction logic for Gameboard.xaml
    /// </summary>
    public partial class Gameboard : Window
    {
        //local variables
        int balance;
        double credit;

        //instances
        Person player = new Person();
        Wallet wallet = new Wallet();
        GameBoardSetup[,] GameBoardValues = new GameBoardSetup[3, 3];

        public Gameboard()
        {
            FillElementArray();
            InitializeComponent();
        }
        //Put in money to bank
        private void btnBankIn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCashIn.Text, out balance))
            {
                wallet.CashIn(balance);
                txtBank.Text = wallet.Balance.ToString("0.00");
                txtCashIn.Text = "";
            }
        }
        //start spin
        private void btnSpin_Click(object sender, RoutedEventArgs e)
        {
            int winAmount = 0;
            double winning = 0;
            if (!double.TryParse(txtCredit.Text, out credit))
                MessageBox.Show("Använd inte bokstäver");
            else if (credit > wallet.Balance)
                MessageBox.Show("Du har inte tillräckligt med pengar.");
            else
            {
                bo00.Background = Brushes.ForestGreen;
                bo10.Background = Brushes.ForestGreen;
                bo20.Background = Brushes.ForestGreen;
                bo01.Background = Brushes.ForestGreen;
                bo11.Background = Brushes.ForestGreen;
                bo21.Background = Brushes.ForestGreen;
                bo02.Background = Brushes.ForestGreen;
                bo12.Background = Brushes.ForestGreen;
                bo22.Background = Brushes.ForestGreen;

                wallet.BetValue(credit);
                txtBank.Text = (wallet.Balance).ToString("0.00");

                //change image - first row
                GameBoardSetup.ChangeSlotImage(sq00, GameBoardSetup.SetSlotCard(GameBoardSetup.GetSlotFigure(), GameBoardValues[0, 0]));
                GameBoardSetup.ChangeSlotImage(sq10, GameBoardSetup.SetSlotCard(GameBoardSetup.GetSlotFigure(), GameBoardValues[1, 0]));
                GameBoardSetup.ChangeSlotImage(sq20, GameBoardSetup.SetSlotCard(GameBoardSetup.GetSlotFigure(), GameBoardValues[2, 0]));
                //change image - second row
                GameBoardSetup.ChangeSlotImage(sq01, GameBoardSetup.SetSlotCard(GameBoardSetup.GetSlotFigure(), GameBoardValues[0, 1]));
                GameBoardSetup.ChangeSlotImage(sq11, GameBoardSetup.SetSlotCard(GameBoardSetup.GetSlotFigure(), GameBoardValues[1, 1]));
                GameBoardSetup.ChangeSlotImage(sq21, GameBoardSetup.SetSlotCard(GameBoardSetup.GetSlotFigure(), GameBoardValues[2, 1]));
                //change image - third row
                GameBoardSetup.ChangeSlotImage(sq02, GameBoardSetup.SetSlotCard(GameBoardSetup.GetSlotFigure(), GameBoardValues[0, 2]));
                GameBoardSetup.ChangeSlotImage(sq12, GameBoardSetup.SetSlotCard(GameBoardSetup.GetSlotFigure(), GameBoardValues[1, 2]));
                GameBoardSetup.ChangeSlotImage(sq22, GameBoardSetup.SetSlotCard(GameBoardSetup.GetSlotFigure(), GameBoardValues[2, 2]));

                //Check for winning results
                if (GameBoardValues[0, 0].SlotType == GameBoardValues[1, 0].SlotType && GameBoardValues[1, 0].SlotType == GameBoardValues[2, 0].SlotType)
                {
                    winning += GameBoardSetup.CalculateWin(GameBoardValues[1, 0].WinValue, credit);
                    bo00.Background = Brushes.Red;
                    bo10.Background = Brushes.Red;
                    bo20.Background = Brushes.Red;
                    winAmount++;
                }
                if (GameBoardValues[0, 1].SlotType == GameBoardValues[1, 1].SlotType && GameBoardValues[1, 1].SlotType == GameBoardValues[2, 1].SlotType)
                {
                    winning += GameBoardSetup.CalculateWin(GameBoardValues[1, 1].WinValue, credit);
                    bo01.Background = Brushes.Red;
                    bo11.Background = Brushes.Red;
                    bo21.Background = Brushes.Red;
                    winAmount++;
                }
                if (GameBoardValues[0, 2].SlotType == GameBoardValues[1, 2].SlotType && GameBoardValues[1, 2].SlotType == GameBoardValues[2, 2].SlotType)
                {
                    winning += GameBoardSetup.CalculateWin(GameBoardValues[1, 2].WinValue, credit);
                    bo02.Background = Brushes.Red;
                    bo12.Background = Brushes.Red;
                    bo22.Background = Brushes.Red;
                    winAmount++;
                }
                if (GameBoardValues[0, 0].SlotType == GameBoardValues[0, 1].SlotType && GameBoardValues[0, 1].SlotType == GameBoardValues[0, 2].SlotType)
                {
                    winning += GameBoardSetup.CalculateWin(GameBoardValues[0, 1].WinValue, credit);
                    bo00.Background = Brushes.Red;
                    bo01.Background = Brushes.Red;
                    bo02.Background = Brushes.Red;
                    winAmount++;
                }
                if (GameBoardValues[1, 0].SlotType == GameBoardValues[1, 1].SlotType && GameBoardValues[1, 1].SlotType == GameBoardValues[1, 2].SlotType)
                {
                    winning += GameBoardSetup.CalculateWin(GameBoardValues[1, 1].WinValue, credit);
                    bo10.Background = Brushes.Red;
                    bo11.Background = Brushes.Red;
                    bo12.Background = Brushes.Red;
                    winAmount++;
                }
                if (GameBoardValues[2, 0].SlotType == GameBoardValues[2, 1].SlotType && GameBoardValues[2, 1].SlotType == GameBoardValues[2, 2].SlotType)
                {
                    winning += GameBoardSetup.CalculateWin(GameBoardValues[2, 1].WinValue, credit);
                    bo20.Background = Brushes.Red;
                    bo21.Background = Brushes.Red;
                    bo22.Background = Brushes.Red;
                    winAmount++;
                }
                if (GameBoardValues[0, 0].SlotType == GameBoardValues[1, 1].SlotType && GameBoardValues[1, 1].SlotType == GameBoardValues[2, 2].SlotType)
                {
                    winning += GameBoardSetup.CalculateWin(GameBoardValues[1, 1].WinValue, credit);
                    bo00.Background = Brushes.Red;
                    bo11.Background = Brushes.Red;
                    bo22.Background = Brushes.Red;
                    winAmount++;
                }
                if (GameBoardValues[0, 2].SlotType == GameBoardValues[1, 1].SlotType && GameBoardValues[1, 1].SlotType == GameBoardValues[2, 0].SlotType)
                {
                    winning += GameBoardSetup.CalculateWin(GameBoardValues[1, 1].WinValue, credit);
                    bo02.Background = Brushes.Red;
                    bo11.Background = Brushes.Red;
                    bo20.Background = Brushes.Red;
                    winAmount++;
                }
                wallet.AddWinnings(winning);
                txtWinning.Text = winning.ToString("0.00") + "  |  " + winAmount + " wins!";
                txtBank.Text = (wallet.Balance).ToString("0.00");
            }
        }
        //Cashes out and leaves the gameboard
        private void btnCashOut_Click(object sender, RoutedEventArgs e)
        {
            wallet.CashOut();
            txtBank.Text = "0";
            new MainWindow().Show();
            this.Close();
        }

        private void FillElementArray()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoardValues[i, j] = new GameBoardSetup();
                }
            }
        }

    }
}
