using System;
namespace Applicatian
{
    class Program
    {
        //public delegate void sentdelegate(string name);
        class CreditCard
        {
            public delegate bool sentdelegate(int a);
            public event sentdelegate Giveback;
            public int usemax,use,data;
            public CreditCard()
            {
                data = 1;
                usemax = 10000;
                use = 9999;
            }
            public void Give()
            {
                if (!(use > usemax))
                {
                    if (this.data==30)
                    {
                        if(Giveback(this.use))
                        {
                            this.take();
                        }
                        else this.not_take();
                    }
                }
            }
            public void take()
            {
                this.use = 0;
                Console.WriteLine("您的信用卡还账成功");
            }
            public void not_take()
            {
                Console.WriteLine("您的信用卡还账未成功");
            }
    }
        class Deposit_card
        {
            public int money=9000;
            public bool giveback(int a)
            {
                if(money > a)
                {
                    this.money = this.money - a;
                    return true;
                }
                else return false;
            }
        }
        static void Main()
        {
            CreditCard creditCard = new CreditCard();
            Deposit_card depositCard = new Deposit_card();
            creditCard.Giveback+=depositCard.giveback;
            for(int i=0;i<=31;i++)
            {
                creditCard.data = i;
                creditCard.Give();
            }
        }
    }
}