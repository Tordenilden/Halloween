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
    public class SuperHeroRepo: ISuperHeroRepo
    {
        /*
        int tal;
        Dbcontext noget;
        string s;
        ISuperHeroRepo noget2;*/
        Dbcontext context; // database
        public SuperHeroRepo(Dbcontext temp)
        {
            context = temp;
        }

        public SuperHero Create(SuperHero hero)
        {
            context.SuperHero.Add(hero);
            context.SaveChanges();
            return hero;
        }

        // Jeg finder ud af Torsdag at det er svært at teste på det her....
        public void Delete(int id)
        {
            SuperHero hero = GetById(id);
            if(hero != null)
            {
                context.SuperHero.Remove(hero);
                context.SaveChanges();
            }
        }

        // This is the complete Example
        public async Task<List<SuperHero>> GetAll()
        {
            return await context.SuperHero.ToListAsync();
        }

        public SuperHero GetById(int id)
        {
            return context.SuperHero.FirstOrDefault(x => x.Id == id);
        }

        public SuperHero Update(SuperHero hero)
        {
            throw new NotImplementedException();
        }
    }
}
