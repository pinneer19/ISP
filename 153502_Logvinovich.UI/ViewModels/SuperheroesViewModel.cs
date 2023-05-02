using _153502_Logvinovich.Application.Abstractions;
using _153502_Logvinovich.Application.Services;
using _153502_Logvinovich.Domain.Entities;
using _153502_Logvinovich.Persistence.Repository;
using _153502_Logvinovich.UI.Pages;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.UI.ViewModels
{
    public partial class SuperheroesViewModel: ObservableObject
    {
        private readonly ISuperheroService _superheroService;
        private readonly ISkillService _superheroSkillsService;

        
        
        public SuperheroesViewModel(ISuperheroService superheroService, ISkillService skillsService)
        {
          
            _superheroService = superheroService;
            _superheroSkillsService = skillsService;
            AddSuperheroViewModel.EditorProcessHandler += async () =>
            {
                await GetSuperheroes();
            };
            EditSkillViewModel.EditorProcessHandler += async () =>
            {
                await GetSkills();
            };
        }

        public ObservableCollection<Superhero> Superheroes { get; set; } = new();
        public ObservableCollection<SuperheroSkills> Skills { get; set; } = new();

        [ObservableProperty]
        Superhero selectedSuperhero;
        
        [RelayCommand]
        async void UpdateGroupList() => await GetSuperheroes();
        
        [RelayCommand]
        async void UpdateMembersList() => await GetSkills();

        [RelayCommand]
        async void EditSkill() => await EditSkillPage();
        private async Task EditSkillPage()
        {
            if(SelectedSuperhero == null) { await App.Current.MainPage.DisplayAlert("Alert", "Choose superhero to add skill!", "OK"); return; }
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "EditSkill", new Tuple<SuperheroSkills, bool>(new SuperheroSkills { SuperheroId = SelectedSuperhero.Id, Superhero = SelectedSuperhero }, false) }
            };
            await Shell.Current.GoToAsync(nameof(Pages.EditSkillPage), parameters);
        }

        [RelayCommand]
        async void AddSuperhero() => await AddSuperheroPage();
        private async Task AddSuperheroPage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Superhero", new Superhero()}
            };
            await Shell.Current.GoToAsync(nameof(Pages.AddSuperhero), parameters);
        }

        [RelayCommand]
        async void ShowDetails(SuperheroSkills skill) => await GotoDetailsPage(skill);
        private async Task GotoDetailsPage(SuperheroSkills skill)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Skill", skill }
            };
            await Shell.Current.GoToAsync(nameof(SkillDetails), parameters);
        }

        public async Task GetSuperheroes()
        {
            
            var superheroes = await _superheroService.GetAllSuperheroesAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Superheroes.Clear();
                foreach (var superhero in superheroes)
                    Superheroes.Add(superhero);
            });
        }
        public async Task GetSkills()
        {
            if(selectedSuperhero == null)
            {
                return;
            }
            var skills = await _superheroSkillsService.GetAllSkillsAsync(skill => selectedSuperhero.Id == skill.SuperheroId);
            
            await MainThread.InvokeOnMainThreadAsync(() =>
            {             
                Skills.Clear();
                foreach (var skill in skills)
                    Skills.Add(skill);
            });
        }
    }
}
