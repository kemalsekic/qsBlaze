using QStack.DataAccess.Azure;
using QStack.DataAccess.Interfaces;
using QStack.DataAccess.Models;

namespace QStack.DataAccess.Data
{
    public class PeopleData : IPeopleData
    {
        private readonly ISqlDataAccess _db;

        public PeopleData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.People";

            return _db.LoadData<PersonModel, dynamic>(sql, new { });
        }

        //public Task GetPerson(PersonModel person, int Id)
        //{
        //    string sql = "select * from dbo.People where Id = @Id";

        //    return _db.LoadPerson(sql, new { });
        //}

        public Task InsertPerson(PersonModel person)
        {
            string sql = @"insert into dbo.People (FirstName, LastName, UserName, EmailAddress)
                            values (@FirstName, @LastName, @UserName, @EmailAddress);";

            return _db.SaveData(sql, person);
        }

        public Task InsertPersonwithOId(PersonModel person)
        {
            string sql = @"insert into dbo.People (FirstName, LastName, UserName, EmailAddress, UUId)
                            values (@FirstName, @LastName, @UserName, @EmailAddress, @UUId);";

            return _db.SaveData(sql, person);
        }

        public Task DeletePerson(PersonModel person)
        {
            string sql = @"delete from dbo.People where Id = @Id";

            return _db.SaveData(sql, person);
        }

        public Task EditPerson(PersonModel person)
        {
            string sql = @"UPDATE dbo.People 
                            SET FirstName = @FirstName,
                                LastName = @LastName,
                                UserName = @UserName,
                                EmailAddress = @EmailAddress,
                                Color = @Color,
                                AssignedPoints = @AssignedPoints
                            WHERE Id = @Id";

            return _db.SaveData(sql, person);
        }

        public Task EditPersonWithUUId(PersonModel person)
        {
            string sql = @"UPDATE dbo.People 
                            SET FirstName = @FirstName,
                                LastName = @LastName,
                                UserName = @UserName,
                                EmailAddress = @EmailAddress,
                                Color = @Color,
                                AssignedPoints = @AssignedPoints
                            WHERE UUId = @UUId";

            return _db.SaveData(sql, person);
        }

        public Task EditPersonPhoneNumber(PersonModel person)
        {
            string sql = @"UPDATE dbo.People 
                            SET Color = @Color
                            WHERE PhoneNumber = @PhoneNumber";

            return _db.SaveData(sql, person);
        }
    }
}
