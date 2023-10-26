using Halloween.Repo.DTO;
using Halloween.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halloween.Repo.Repositories
{
    public class TeamRepo : ITeamRepo
    {
        #region Init

        Dbcontext context;
        public TeamRepo(Dbcontext c)
        {
            context = c;    
        }
        #endregion Init
        #region POST

        public async Task<Team> CreateWithHero(Team hero)
        {
            context.Team.Add(hero);
            await context.SaveChangesAsync();
            return hero;
        }

        // det antages JSON tager højde for at sætte en liste = []
        public async Task<Team> CreateWithoutHero(Team hero)
        {
            Team team = new Team()
            {
                Id = 0,
                Name = hero.Name,
                Members = null
            };
            context.Team.Add(team);
            await context.SaveChangesAsync();
            return hero;
        }
        # endregion POST

        #region GET

        public async Task<List<Team>> GetAllWithHero()
        {
            return await context.Team.Include(teamObj => teamObj.Members).ToListAsync();
        }

        public async Task<List<Team>> GetAllWithoutHero()
        {
            return await context.Team.ToListAsync();
        }

        public Team GetById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion GET
        public Team Update(Team hero)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

//#region POST
//# endregion POST
