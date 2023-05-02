using _153502_Logvinovich.UI.ViewModels;

namespace _153502_Logvinovich.UI.Pages;

public partial class AddSuperhero : ContentPage
{
    private readonly AddSuperheroViewModel _viewModel;
    public AddSuperhero(AddSuperheroViewModel viewmodel)
	{
		InitializeComponent();
		_viewModel = viewmodel;
		BindingContext = viewmodel;
		
	}
}