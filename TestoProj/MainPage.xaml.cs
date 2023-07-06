namespace TestoProj;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void downloadImage_Clicked(object sender, EventArgs e)
    {
        testImage.Source = new UriImageSource
        {
            Uri = new Uri("https://raw.githubusercontent.com/dotnet/maui/3c37d850317e80c19df3c5e754dbce12fb818c6c/Assets/icon.png"),
            CachingEnabled = false
        };
    }
}


