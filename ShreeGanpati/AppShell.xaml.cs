using ShreeGanpati.Pages;

namespace ShreeGanpati
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private readonly static Type[] _routablePageTypes =
            [
                typeof(SigninPage),
                typeof(SignupPage),
                typeof(MyOrdersPage),
                typeof(OrderDetailsPage),
                typeof(DetailsPage),

            ];
        private static void RegisterRoutes()
        {
            foreach (var pageType in _routablePageTypes)
            {
                Routing.RegisterRoute(pageType.Name, pageType);
            }
        }

        private async void Flyoutfooter_Tapped(object sender, TappedEventArgs e)
        {
            await Launcher.OpenAsync("https://designsbypriyansh.great-site.net/?i=1");
        }

        private async void SignOutMenuItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.DisplayAlert("Alert", "Signout menu item clicked", "ok");
        }
    }
}
