using QStack.Shared.States;

namespace QStack.Components.Pages
{
    public partial class HomeTab : ContentPage
    {
        private readonly PlayersState? _playersState;

        public HomeTab()
        {
            InitializeComponent();
            _playersState = PlayersState.Instance;
            BindingContext = _playersState;
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            // Access shared state
            var sharedValue = PlayersState.Instance.PlayerCount;
            System.Diagnostics.Debug.WriteLine("sharedValue: ", sharedValue.ToString());

            // Update shared state
            _playersState.PlayerCount++;
            System.Diagnostics.Debug.WriteLine("_playersState.PlayerCount: ", _playersState.PlayerCount);

        }
    }
}