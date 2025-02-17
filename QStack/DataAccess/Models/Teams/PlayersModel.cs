namespace QStack.DataAccess
{
    public class PlayersModel
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public string UUId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> TeamsList { get; set; }
        public List<string> SportsList { get; set; }
        public int Price { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int SkillLevel { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
