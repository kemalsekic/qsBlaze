namespace QStack.DataAccess.Models.Push
{
    public class PushModel
    {
        public int? PushId { get; set; }
        public int PushNumber { get; set; }
        public int PersonID { get; set; }
        public string? ActiveUserOID { get; set; }
        public string? GameTime { get; set; }
        public string? Team { get; set; }
        public List<PersonModel>? PlayerInvitees { get; set; }
        public string? GameLocation { get; set; }
        public DateTime GameDate { get; set; }
        public DateTime PushDate { get; set; }
        public int? JoinedPlayers { get; set; }
        public int? DeniedPlayers { get; set; }
        public int? UndecidedPlayers { get; set; }
        public int SessionId { get; set; }
        public string? UserName { get; set; }
        public string? Host { get; set; }
        public string? Invitation { get; set; }
    }
}
