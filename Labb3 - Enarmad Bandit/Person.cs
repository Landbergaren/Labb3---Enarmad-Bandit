namespace Enarmad_Bandit
{
    public class Person
    {
        string name;
        string country;
        string securitynumber;
        string tele;

        public string Name { get => name; }
        public string Country { get => country; }
        public string Securitynumber { get => securitynumber; }
        public string Tele { get => tele; }

        public Person()
        {
            name = MainWindow.Name1;
            country = MainWindow.Country;
            securitynumber = MainWindow.Securitynr;
            tele = MainWindow.Tele;
        }
    }
}