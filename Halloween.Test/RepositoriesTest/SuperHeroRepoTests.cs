using Halloween.Repo.DTO;
using Halloween.Repo.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Halloween.Test.RepositoriesTest
{
    /// <summary>
    /// We want to take the DB offline, so we can focus on Repo Layer
    /// To do that we use InMemoryDB
    /// The way we does that is 
    /// "copy DbContext and Options"
    /// 
    /// </summary>
    public class SuperHeroRepoTests
    {
        public Dbcontext context { get; set; }
        public DbContextOptions<Dbcontext> options;
        public int tal; // tal = 0;
        private SuperHeroRepo heroRepo;
        // params later....
        public SuperHeroRepoTests()
        {
            options = new DbContextOptionsBuilder<Dbcontext>()
                
                .UseInMemoryDatabase("Torsdag").Options;
            // we init our "DB"
            context = new Dbcontext(options);
            SuperHero hero1 = new SuperHero()
            {
                Id = 1,
                Name = "Superman",
                Place = "Earth",
                RealName = "Clarkie the boy",
                DebutYear = DateTime.Now
            };
            SuperHero hero2 = new SuperHero()
            {
                Id = 2,
                Name = "Batman",
                Place = "Gotham",
                RealName = "Bruce the Dark",
                DebutYear = DateTime.Now
            };
            SuperHero hero3 = new SuperHero()
            {
                Id = 33,
                Name = "Patrick",
                Place = "Universe",
                RealName = "The Unknown",
                DebutYear = DateTime.Now
            };
            context.SuperHero.Add(hero1);
            context.SuperHero.Add(hero2);
            context.SuperHero.Add(hero3);
            context.SaveChanges();

            
        }

        [Fact]
        public async void GetAllShouldReturnListOfHeroes_WhenHeroesExists()
        {
            //Arrange  - create objects / variables / something
            //SuperHeroRepo hero = new SuperHeroRepo(); this is for this method only
            heroRepo = new SuperHeroRepo(context);


            //Act - actions (Handlinger)
            // Invoke GetALl....
            var result = await heroRepo.GetAll();

            //Assert - Testing if our result is what we want it to be
            Assert.NotNull(result);
            Assert.IsType<List<SuperHero>>(result);
            Assert.Equal(3, result.Count);
            //Assert.Null(result);
        }

        //[Fact]


        //Arrange

        //Act

        //Assert
    }
}
