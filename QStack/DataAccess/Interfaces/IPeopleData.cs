using QStack.DataAccess.Models;

namespace QStack.DataAccess.Interfaces
{
    public interface IPeopleData
    {
        Task<List<PersonModel>> GetPeople();
        //Task GetPerson(PersonModel person, int Id);
        Task InsertPerson(PersonModel person);
        Task DeletePerson(PersonModel person);
        Task EditPerson(PersonModel person);
        Task EditPersonPhoneNumber(PersonModel person);
        Task EditPersonWithUUId(PersonModel person);
        Task InsertPersonwithOId(PersonModel person);
    }
}

