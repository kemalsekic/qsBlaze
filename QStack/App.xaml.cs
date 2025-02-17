using QStack.Shared.States;

namespace QStack
{
    public partial class App : Application
    {
        public App(PlayersState playersState)
        {
            InitializeComponent();

            MainPage = new MainPage(playersState);
        }
    }
}
