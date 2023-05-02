using _153502_Logvinovich.UI.ViewModels;

namespace _153502_Logvinovich.UI.Pages;

public partial class EditSkillPage : ContentPage
{

	private readonly EditSkillViewModel viewModel;

	public EditSkillPage(EditSkillViewModel _viewmodel)
	{
		InitializeComponent();
		viewModel = _viewmodel;
		BindingContext = viewModel;
		
        if (viewModel.Superheroes == null) viewModel.GetSuperheroesAsync();
    }

}