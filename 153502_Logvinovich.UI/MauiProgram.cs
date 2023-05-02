using _153502_Logvinovich.Application.Abstractions;
using _153502_Logvinovich.Application.Services;
using _153502_Logvinovich.Domain.Abstractions;
using _153502_Logvinovich.Domain.Entities;
using _153502_Logvinovich.Persistence.Data;
using _153502_Logvinovich.Persistence.Repository;
using _153502_Logvinovich.UI.Pages;
using _153502_Logvinovich.UI.ValueConventers;
using _153502_Logvinovich.UI.ViewModels;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace _153502_Logvinovich.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
          
            string settingsStream = "_153502_Logvinovich.UI.appsettings.json";
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            AddDbContext(builder);
            SetupServices(builder.Services);
            SeedData(builder.Services);

            return builder.Build();
        }

        private static void SetupServices(IServiceCollection services)
        {

            // Services
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            services.AddSingleton<ISuperheroService, SuperheroService>();
            services.AddSingleton<ISkillService, SuperheroSkillsService>();
            


            // Entities
            services.AddSingleton<Superheroes>();
            

            // ViewModels
            services.AddSingleton<SuperheroesViewModel>();
            services.AddTransient<SkillDetailsViewModel>();
            services.AddTransient<AddSuperheroViewModel>();
            services.AddTransient<EditSkillViewModel>();

            // Pages
            services.AddTransient<SkillDetails>();
            services.AddTransient<AddSuperhero>();
            services.AddTransient<EditSkillPage>();
        }

        private static void AddDbContext(MauiAppBuilder builder)
        {
            var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
            string dataDirectory = string.Empty;

        #if ANDROID
            dataDirectory = FileSystem.AppDataDirectory + "/";
        #endif
            connStr = string.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

            builder.Services.AddSingleton((s) => new AppDbContext(options));
        }

        public async static void SeedData(IServiceCollection services)
        {
            using var provider = services.BuildServiceProvider();
            var unitOfWork = provider.GetService<IUnitOfWork>();

            
            await unitOfWork.RemoveDatbaseAsync();
            await unitOfWork.CreateDatabaseAsync();
            
            // Add superheroes
            
            IReadOnlyList<Superhero> superheroes = new List<Superhero>()
            {
                new Superhero(){ Name="Spider-man", Age = 17, Power = 500, Id = 1 },
                new Superhero(){ Name="Hulk", Age = 36, Power = 1000, Id = 2 }
            };
            foreach (var superhero in superheroes)
                await unitOfWork.SuperheroRepository.AddAsync(superhero);
            await unitOfWork.SaveAllAsync();
            
            // Add skills
            
            Random rand = new Random();
            int k = 1;
            foreach (var superhero in superheroes)
                for (int j = 0; j < 10; j++)
                    await unitOfWork.SuperheroSkillsRepository.AddAsync(new SuperheroSkills()
                    {
                        Name = $"Skill {k++}",
                        Damage = rand.Next(5000),
                        Description = $"Skill description {k}",
                        Id = k,
                        SuperheroId = superhero.Id,
                        Superhero = superhero,
                        UpgradeLevel = rand.Next(100)
                    }); ;
            await unitOfWork.SaveAllAsync();
        }
    }
}
    