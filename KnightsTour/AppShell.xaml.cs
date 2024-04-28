namespace KnightsTour
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(HowToPlayPage), typeof(HowToPlayPage));
            Routing.RegisterRoute(nameof(ScoreHistoryPage), typeof(ScoreHistoryPage));
        }
    }
}
