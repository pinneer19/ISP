using CommunityToolkit.Maui.Core;

namespace _153502_Logvinovich.UI
{

    // simple using Application creates compilation issue
    public partial class App : Microsoft.Maui.Controls.Application
    {      
        public App()
        {
            InitializeComponent();
            
            MainPage = new AppShell();
            
        }
    }
}