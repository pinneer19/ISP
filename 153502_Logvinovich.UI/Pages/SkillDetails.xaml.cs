using _153502_Logvinovich.UI.ViewModels;

namespace _153502_Logvinovich.UI.Pages;

public partial class SkillDetails : ContentPage
{
	private readonly SkillDetailsViewModel viewModel;
	public SkillDetails(SkillDetailsViewModel viewmodel)
	{
		InitializeComponent();
        viewModel = viewmodel;
        BindingContext = viewModel;
		
    }

}