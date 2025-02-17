using DataAccessLibrary.Models;
using DataAccessLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data
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

        public Task EditPersonPhoneNumber(PersonModel person)
        {
            string sql = @"UPDATE dbo.People 
                            SET Color = @Color
                            WHERE PhoneNumber = @PhoneNumber";

            return _db.SaveData(sql, person);
        }
    }
}
