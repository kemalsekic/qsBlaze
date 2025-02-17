using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IPeopleData
    {
        Task<List<PersonModel>> GetPeople();
        //Task GetPerson(PersonModel person, int Id);
        Task InsertPerson(PersonModel person);
        Task DeletePerson(PersonModel person);
        Task EditPerson(PersonModel person);
        Task EditPersonPhoneNumber(PersonModel person);
    }
}