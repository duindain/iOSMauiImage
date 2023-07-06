# iOSMauiImage
iOS Maui Image changed at runtime issue

Reproduction of this issue https://github.com/dotnet/maui/issues/12020
With workaround added for handler in MauiProgram

Image doesnt render when clicking on button
However rotating the screen will make the image appear as detailed in the issue

When i test this in the iOS simulator 
1. Click Switch to fetch the image async
2. Nothing will change
3. Rotate the screen and the image will appear

Changing from VerticalStackLayout to Grid
1. Click Switch to fetch the image async
2. Nothing will change
3. Rotate the screen and the image will not appear which is different from what @Mattleibow reported

This is running 
17.5.4 build 8 VS for Mac
.Net 7.0.1

| Grid after rotating simulator  | VirtualStack after rotating simulator |
| ------------- | ------------- |
| ![Simulator Screenshot - iPad Pro (12 9-inch) (6th generation) - 2023-07-06 at 16 28 05](https://github.com/duindain/iOSMauiImage/assets/4401594/884e0cac-799f-4ea3-93f3-2cf9749d1708=250x)  | ![Simulator Screenshot - iPad Pro (12 9-inch) (6th generation) - 2023-07-06 at 16 27 20](https://github.com/duindain/iOSMauiImage/assets/4401594/e73beda5-ba2f-43e3-908f-9047e00049b4=250x)  |

You can see from the screenshots that there are other issues there the Vertical stack is a transparent background showing dark mode, the Grid seems to have a white background for some reason and takes up the entire screen and shows the image and button in very different places 
