# Change Desktop Wallpaper

A C# console application that changes the Windows desktop wallpaper using the **Win32 API** through **P/Invoke**.

## Technologies

- C#
- .NET
- Win32 API
- P/Invoke

## Windows API Used

This project uses:

```csharp
SystemParametersInfo()
```

from:

```text
user32.dll
```

to update the Windows desktop wallpaper.

## Features

- Accepts the wallpaper image path from the user
- Validates that the image file exists
- Changes the desktop wallpaper automatically
- Displays success or error messages

## How It Works

1. The user enters the full path of an image file.
2. The application checks whether the file exists.
3. The `SystemParametersInfo` Windows API function is called.
4. The desktop wallpaper is updated.

## Screenshots
### Original Wallpaper

<img src="Images/OriginalWallpaper.png" width="30%" alt="Original Wallpaper">

### Console Application

<img src="Images/ConsoleApp.png" width="30%" alt="Console Application">

### New Wallpaper

<img src="Images/NewWallpaper.png" width="30%" alt="New Wallpaper">

---

## ✍️ Author
Hazem Ahmad Hazem  
- GitHub: https://github.com/HazemAhmadHaz
- LinkedIn: https://www.linkedin.com/in/hazem-ahmad-haz
- Email: HazemAhmad01234@gmail.com
