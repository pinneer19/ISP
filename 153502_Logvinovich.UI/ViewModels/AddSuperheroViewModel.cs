using _153502_Logvinovich.Application.Abstractions;
using _153502_Logvinovich.Application.Services;
using _153502_Logvinovich.Domain.Abstractions;
using _153502_Logvinovich.Domain.Entities;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.UI.ViewModels
{

    [QueryProperty(nameof(Superhero), nameof(Superhero))]
    public partial class AddSuperheroViewModel : ObservableObject
    {
        
        private readonly IUnitOfWork _unit;
        public AddSuperheroViewModel(IUnitOfWork unit)
        {
            _unit = unit;
		}
        public static event Action EditorProcessHandler;
        [ObservableProperty]
        Superhero superhero;
        
        [RelayCommand]
        private async void SaveSuperhero() => await SuperheroSaveProcess();


        private async Task SuperheroSaveProcess()
        {

            //await _superheroService.AddAsync(superhero);
            Superhero.Id = (await _unit.SuperheroRepository.ListAllAsync()).Count + 1;
            Superhero.Skills = new();
            await _unit.SuperheroRepository.AddAsync(Superhero);
            
            await _unit.SaveAllAsync();          
            MainThread.BeginInvokeOnMainThread(() =>
            {
                EditorProcessHandler?.Invoke();
            });
            await Shell.Current.GoToAsync("..");
        }
    }
}
