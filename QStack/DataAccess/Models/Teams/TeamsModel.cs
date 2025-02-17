namespace QStack.DataAccess
{
    public class TeamsModel
    {
        public int TeamId { get; set; }
        public string PlayerId { get; set; }
        public string TeamName { get; set; }
        public List<string> TeamsList { get; set; }
        public List<string> PlayersList { get; set; }
        public List<string> SportsList { get; set; }
        public string TeamOwner { get; set; }
        public string TeamCaptain { get; set; }
    }
}
