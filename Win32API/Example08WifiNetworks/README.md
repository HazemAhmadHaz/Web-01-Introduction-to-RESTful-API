# Wifi Networks

A C# console application that lists saved Wi-Fi network profiles using the Win32 WLAN API through P/Invoke.

## Technologies

- C#
- .NET
- Win32 API
- P/Invoke

## Windows API Used

This project uses `WlanOpenHandle()`, `WlanEnumInterfaces()`, `WlanCloseHandle()`, and `WlanFreeMemory()` from `Wlanapi.dll` to enumerate wireless interfaces and retrieve saved network profile names.

## Features

- Opens a handle to the WLAN service
- Enumerates available wireless interfaces
- Displays saved Wi-Fi network (SSID) names

## Preview

<p align="center">
  <img src="Images/WifiNetwork.png" width="45%" />
</p>

## Author

Hazem Ahmad Hazem

- GitHub: https://github.com/HazemAhmadHaz
- LinkedIn: https://www.linkedin.com/in/hazem-ahmad-haz
- Email: HazemAhmad01234@gmail.com