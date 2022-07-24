# Consoles in C#
Using console commands in C# (Command Line Prompt, PowerShell, Scripts). This program was created because fancy GUI's and UI's are not always neccessary to make. Sometimes just having a simple light-weight console window will suffice and starting off programming for console is a great way to learn.

**System.Diagnostics**
-------------------------
One commonly used namespace that can be used to call console commands is the System.Diagnostics namespace. We can run a command normally in the console or silently using this namespace.

#### Example of running a command:
```cs
string cmdCommand = "/C ver"; //Commands must start with "/C" or "/c"
System.Diagnostics.Process.Start("CMD.exe", cmdCommand);
```

#### Example of running a command silently in the background:
```cs
var proc1 = new ProcessStartInfo();
string aCommand = "/C ver"; //Command to run on cmd
proc1.UseShellExecute = true;
proc1.WorkingDirectory = @"C:\Windows\System32";
proc1.FileName = @"C:\Windows\System32\cmd.exe";
proc1.Verb = "runas"; //behave as if the process has been started from Explorer with the "Run as Administrator" menu command
proc1.Arguments = "/c " + aCommand; //"/c" tells the prompt to run and terminate afterwards
proc1.WindowStyle = ProcessWindowStyle.Hidden;
Process.Start(proc1);
```

## CLI Wrap
A popular nuget package used to create applications using command line is the [cliwrap package](https://github.com/Tyrrrz/CliWrap).

```cs
using CliWrap;
using CliWrap.Buffered; //Allows us to capture input and output more easily

var dockerresults = await Cli.Wrap("git").WithArguments("--version").ExecuteBufferedAsync();
Console.WriteLine(dockerresults.StandardOutput); //Output data produced by underlying process

var powershell = await Cli.Wrap("powershell").WithWorkingDirectory(@"C:\").
    WithArguments(new[] { "echo hello", "world" }).ExecuteBufferedAsync();
Console.WriteLine(powershell.StandardOutput);

var powershell2 = await Cli.Wrap("powershell").WithWorkingDirectory(@"C:\").
    WithArguments("echo hello world; Get-Random").ExecuteBufferedAsync();
Console.WriteLine(powershell2.StandardOutput);

/*  Example output:
    git version 2.35.1.windows.2

    hello
    world

    hello
    world
    213197604
*/
```

**Related Projects**
----------
[Console Properties](https://github.com/Kttra/ConsoleProperties) - C++ project that focuses on console use just like this repo.

[File Name Grabber](https://github.com/Kttra/FileNameGrabber) - C++ program that uses console commands to read the file name's in a directory and copies the output into the system's clipboard.

[Shutdown Scheduler](https://github.com/Kttra/ShutdownScheduler) - C# program that schedules a shutdown for windows devices. The program runs the requested command through a hidden console.

[Time Adder](https://github.com/Kttra/TimeAdder) - C++ program that receives time inputs from the user and adds up the time.
