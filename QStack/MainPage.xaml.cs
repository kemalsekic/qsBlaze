using QStack.Shared.States;

namespace QStack
{
    public partial class MainPage : ContentPage
    {
        private readonly PlayersState _playersState;
        //private string _accessToken = string.Empty;
        //bool _isLoggedIn = false;

        //public bool IsLoggedIn
        //{
        //    get => _isLoggedIn;
        //    set
        //    {
        //        if (value == _isLoggedIn) return;
        //        _isLoggedIn = value;
        //        OnPropertyChanged(nameof(IsLoggedIn));
        //    }
        //}

        public MainPage(PlayersState playersState)
        {
            //BindingContext = this;
            InitializeComponent();
            //_ = Login();
            _playersState = playersState;
            BindingContext = _playersState;
        }

        //private async Task Login()
        //{
        //    try
        //    {
        //        var result = await PCAWrapper.AcquireTokenInteractiveAsync(PCAWrapper?.Scopes).ConfigureAwait(false);
        //        IsLoggedIn = true;
        //    }
        //    catch (MsalUiRequiredException)
        //    {
        //        var result = await PCAWrapper.AcquireTokenInteractiveAsync(PCAWrapper?.Scopes).ConfigureAwait(false);
        //    }
        //}

        private void PlayerAdded(object sender, EventArgs e)
        {
            _playersState.PlayerCount++;
        }
    }
}
