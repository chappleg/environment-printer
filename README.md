# Environment Printer

Print all environment variables for a given process running on Windows.

## Building

``` powershell
dotnet publish -c Release
```

(Executable can be found at `.\bin\Release\net5.0\win-x64\publish\EnvironmentPrinter.exe`)

## Running

Print all environment vairables for a process:

``` powershell
EnvironmentPrinter.exe <process>
```

Print a specific environment vairable:

``` powershell
EnvironmentPrinter.exe <process> -v <variable-name>
```

If there are multiple processes with the same name specify a number:

``` powershell
EnvironmentPrinter.exe <process> -n 1
```