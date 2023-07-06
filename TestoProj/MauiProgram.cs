using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
#if IOS

using Foundation;
using UIKit;
#endif
using CommunityToolkit.Maui.Converters;

namespace TestoProj;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiCommunityToolkit()
            .UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
#if IOS

            //This is needed to work around this Maui bug
            //https://github.com/dotnet/maui/issues/12020
            Microsoft.Maui.Handlers.ImageHandler.Mapper.AppendToMapping("iOSImageFix", (handler, view) =>
            {
                if (view.Source is StreamImageSource streamImageSource)
                {
                    try
                    {
                        byte[]? array = new ByteArrayToImageSourceConverter().ConvertBackTo(streamImageSource);
                        if (array != null)
                        {
                            NSData? data = NSData.FromArray(array);
                            if (data != null)
                            {
                                handler.PlatformView.Image = UIImage.LoadFromData(data);
                            }
                        }
                    }
                    catch { }
                }
            });
#endif

        return builder.Build();
	}
}

