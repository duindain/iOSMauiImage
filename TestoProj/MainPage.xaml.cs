#if IOS

using Foundation;
using UIKit;
#endif
#if IOS || ANDROID || MACCATALYST
using Microsoft.Maui.Graphics.Platform;
#elif WINDOWS
using Microsoft.Maui.Graphics.Win2D;
#endif
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;
using Microsoft.Maui.Graphics;

namespace TestoProj;

public partial class MainPage : ContentPage
{
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
        System.Diagnostics.Debug.WriteLine("Loading downloaded image");
    }

    /// <summary>
    /// Test fix from Ms
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Clicked(object sender, EventArgs e)
    {
        var types = GetType().Assembly.GetManifestResourceNames().ToList();
        var imageBytes = ImageDataFromResource("icon_small_40_3x.png");
        testImage.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
#if IOS
          if( Handler?.PlatformView is UIImageView imageView )
          {
            NSData? data = NSData.FromArray(imageBytes);
            if( data != null )
            {
              imageView.Image = UIImage.LoadFromData( data );
            }
          }
#endif
        System.Diagnostics.Debug.WriteLine("Loading manifest image");

    }

    public byte[] ImageDataFromResource(string r)
    {
        var assembly = GetType().GetTypeInfo().Assembly;
        byte[] buffer = null;

        using (System.IO.Stream s = assembly.GetManifestResourceStream(r))
        {
            if (s != null)
            {
                long length = s.Length;
                buffer = new byte[length];
                s.Read(buffer, 0, (int)length);
            }
        }

        return buffer;
    }
}


