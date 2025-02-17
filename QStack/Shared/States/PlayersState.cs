using System.ComponentModel;

namespace QStack.Shared.States
{
    public class PlayersState : INotifyPropertyChanged
    {
        private static readonly Lazy<PlayersState> lazy = new Lazy<PlayersState>(() => new PlayersState());

        public static PlayersState Instance => lazy.Value;

        private int _playercounter;
        private string? _activeUser;

        public int PlayerCount
        {
            get => _playercounter;
            set
            {
                _playercounter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerCount)));

            }
        }

        public string ActiveUser
        {
            get => _activeUser;
            set
            {
                _activeUser = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveUser)));

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    //public interface IAppStateService
    //{
    //    public int PlayerCount { get; }
    //}

    //public class AppStateService : IAppStateService, INotifyPropertyChanged
    //{
    //    private int _playercounter;

    //    public int PlayerCount => PlayersState.Instance.PlayerCount;
    //    public int PlayerCountChange
    //    {
    //        get => _playercounter;
    //        set
    //        {
    //            _playercounter = value;
    //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerCount)));

    //        }
    //    }

    //    public event PropertyChangedEventHandler? PropertyChanged;
    //}
}
