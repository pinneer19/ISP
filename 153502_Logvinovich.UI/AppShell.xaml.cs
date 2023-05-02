using _153502_Logvinovich.UI.Pages;

namespace _153502_Logvinovich.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SkillDetails), typeof(SkillDetails));
            Routing.RegisterRoute(nameof(AddSuperhero), typeof(AddSuperhero));
            Routing.RegisterRoute(nameof(EditSkillPage), typeof(EditSkillPage));
        }
    }
}