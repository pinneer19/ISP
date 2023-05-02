using _153502_Logvinovich.Domain.Abstractions;
using _153502_Logvinovich.Domain.Entities;
using _153502_Logvinovich.UI.Pages;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.UI.ViewModels
{
    [QueryProperty(nameof(EditSkill), nameof(EditSkill))]
    public partial class EditSkillViewModel: ObservableObject
    {

        private readonly IUnitOfWork _unit;
        public EditSkillViewModel(IUnitOfWork unit)
        {
            _unit = unit;
            

        }
        public static event Action EditorProcessHandler;


        [ObservableProperty]
        ObservableCollection<Superhero> superheroes;
        
        public async void GetSuperheroesAsync()
        {
            var superheroes = await _unit.SuperheroRepository.ListAllAsync();
            
            if (Superheroes != null) Superheroes.Clear();
            else Superheroes = new();
            foreach (var superhero in superheroes)
                Superheroes.Add(superhero);           
        }


        [ObservableProperty]
        Tuple<SuperheroSkills, bool> editSkill;



        [RelayCommand]
        async void DeleteSuperheroSkills() => await DeleteSkill();
        async Task DeleteSkill()
        {

            await _unit.SuperheroSkillsRepository.DeleteAsync(editSkill.Item1);
            await _unit.SaveAllAsync();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                EditorProcessHandler?.Invoke();
            });
            await Shell.Current.GoToAsync("..");
            await Shell.Current.GoToAsync("..");

        }

        [RelayCommand]
        async void UpdateSuperheroSkills() => await UpdateSkills();
        async Task UpdateSkills()
        {

            editSkill.Item1.SuperheroId = editSkill.Item1.Superhero.Id;
                       
            if (editSkill.Item2)
            {
                await _unit.SuperheroSkillsRepository.UpdateAsync(editSkill.Item1);
            }
            else
            {
                await _unit.SuperheroSkillsRepository.AddAsync(editSkill.Item1);
            }

            await _unit.SaveAllAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                EditorProcessHandler?.Invoke();
            });
            await Shell.Current.GoToAsync("..");
            await Shell.Current.GoToAsync("..");

        }


        [RelayCommand]
        async void ChangeImage() => await ChangeImageProcess();
        async Task ChangeImageProcess()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select image",
                FileTypes = FilePickerFileType.Images
            });
            if (result == null)
                return;


            var stream = await result.OpenReadAsync();
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, $"skill_{editSkill.Item1.Id}.png");
            using FileStream localFileStream = File.OpenWrite(filePath);
            await stream.CopyToAsync(localFileStream);
        }


    }
}
