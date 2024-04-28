namespace KnightsTour;

public partial class ScoreHistoryPage : ContentPage
{
    private readonly ScoreHistoryManager scoreHistoryManager = new ScoreHistoryManager();

    public ScoreHistoryPage()
    {
        InitializeComponent();

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var allScores = await scoreHistoryManager.LoadAllScores();
            scoreHistoryList.ItemsSource = allScores;
        }
        catch (Exception ex)
        {
            // Hata yakalama ve kullanıcıya bildirim
            await DisplayAlert("Hata", ex.Message, "Tamam");
        }
    }
}