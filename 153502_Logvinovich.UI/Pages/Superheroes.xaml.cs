using _153502_Logvinovich.Application.Services;
using _153502_Logvinovich.Domain.Abstractions;
using _153502_Logvinovich.Persistence.Repository;
using _153502_Logvinovich.UI.ViewModels;

namespace _153502_Logvinovich.UI.Pages;

public partial class Superheroes : ContentPage
{
    private readonly SuperheroesViewModel _viewModel;
    public Superheroes(SuperheroesViewModel viewModel)
	{
        
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
        

    }
}