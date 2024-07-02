using JPillajoT5.Utils;
using JPillajoT5.Views;

namespace JPillajoT5
{
    public partial class App : Application
    {
        public partial class App : Application
        {
            public static PersonRepository personRepo { get; set; }
            public App(PersonRepository person)
            {
                InitializeComponent();

                MainPage = new vHome();
                personRepo = person;

            }
        }
    }
