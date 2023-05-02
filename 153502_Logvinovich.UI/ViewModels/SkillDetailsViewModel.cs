using _153502_Logvinovich.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _153502_Logvinovich.UI.ViewModels
{
    [QueryProperty(nameof(Skill), nameof(Skill))]
    public partial class SkillDetailsViewModel: ObservableObject
    {
        
        [ObservableProperty]
        SuperheroSkills skill;

        [RelayCommand]
        async void Edit() => await UpdateSkill();
        private async Task UpdateSkill()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "EditSkill", new Tuple<SuperheroSkills, bool>(Skill, true) }
            };
            await Shell.Current.GoToAsync(nameof(Pages.EditSkillPage), parameters);
        }

    }
}

