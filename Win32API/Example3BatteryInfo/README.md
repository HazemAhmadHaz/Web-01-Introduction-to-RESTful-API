# Battery Info

A C# console application that retrieves the current battery status using the Win32 API through P/Invoke.

* (|) to combine two separate bits into one number:

        0000 0001  (Read)
      | 0000 0010  (Write)
      = 0000 0011  (= 3, both bits set)


* AND (&) — same technique as the battery example — to test one bit at a time:

        0000 0011   (userPermissions)
      & 0000 0100   (Execute mask)
      = 0000 0000   (= 0 → doesn't have Execute)

## Technologies

- C#
- .NET
- Win32 API
- P/Invoke

## Windows API Used

This project uses `GetSystemPowerStatus()` from `kernel32.dll` to retrieve battery and power status information.

## Features

- Displays battery charge percentage
- Shows whether the device is plugged in or on battery
- Displays power status details in the console

## Preview
### Battry Info

<img src="Images/BattryInfo.png" width="30%" alt="Battry Info">

## Author

Hazem Ahmad Hazem

- GitHub: https://github.com/HazemAhmadHaz
- LinkedIn: https://www.linkedin.com/in/hazem-ahmad-haz
- Email: HazemAhmad01234@gmail.com
