using Halloween.Repo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halloween.Repo.Interfaces
{
    public interface ITeamRepo
    {
        //CRUD
        Task<List<Team>> GetAllWithoutHero();
        Task<List<Team>> GetAllWithHero();
        Team GetById(int id);
        //SuperHero GetByName(string name);
        Task<Team> CreateWithoutHero(Team hero);
        Task<Team> CreateWithHero(Team hero);
        Team Update(Team hero);
        void Delete(int id);
    }
}
