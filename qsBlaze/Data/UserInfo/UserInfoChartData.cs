namespace qsBlaze.Data.UserInfo
{
    public class UserInfoChartData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Color { get; set; }
        public int AssignedPoints { get; set; }
        public int CarryOverPoints { get; set; }
        public List <UserInfoChartData> GetUserInfos()
        {
            var userInfos = new List<UserInfoChartData>();

            userInfos.Add(new UserInfoChartData { Id = 1, UserName = "Kemo", Color = "Green", AssignedPoints = 9, CarryOverPoints = 1 });
            userInfos.Add(new UserInfoChartData { Id = 2, UserName = "were", Color = "Red", AssignedPoints = 5, CarryOverPoints = 0 });
            userInfos.Add(new UserInfoChartData { Id = 3, UserName = "rere", Color = "Green", AssignedPoints = 5, CarryOverPoints = 0 });
            userInfos.Add(new UserInfoChartData { Id = 4, UserName = "cbny", Color = "Yellow", AssignedPoints = 3, CarryOverPoints = 0 });
            userInfos.Add(new UserInfoChartData { Id = 5, UserName = "wyy", Color = "Yellow", AssignedPoints = 7, CarryOverPoints = 2 });

            return userInfos;
        }
    }
}
