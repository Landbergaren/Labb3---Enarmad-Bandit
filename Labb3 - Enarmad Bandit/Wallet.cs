using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Enarmad_Bandit
{
    public class Wallet
    {
        public Wallet()
        {
            balance = 0;
            credit = 0;
        }

        //Fields
        double balance;
        double credit;

        public double Balance { get => balance; }
        public double Credit { get => credit; }

        //Behaviours
        public void AddWinnings(double winning)
        {
            balance = balance + winning;
        }


        public void BetValue(double amount)
        {
            balance = balance - amount;
        }

        public void CashIn(int moneyIn)
        {
            balance = moneyIn + balance;
        }

        public void CashOut()
        {
            MessageBox.Show("You have cashed out " + balance.ToString("0.00"));
            balance = 0;
        }
    }
}
