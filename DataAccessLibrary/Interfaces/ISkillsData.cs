using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface ISkillsData
    {
        Task DeleteSkill(SkillsModel skill);
        Task EditSkill(SkillsModel skill);
        Task<List<SkillsModel>> GetSkills();
        Task InsertSkill(SkillsModel skill);
    }
}