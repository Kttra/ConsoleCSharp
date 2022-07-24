using CliWrap;
using CliWrap.Buffered; //Allows us to capture input and output more easily

var dockerresults = await Cli.Wrap("git").WithArguments("--version").ExecuteBufferedAsync();
Console.WriteLine(dockerresults.StandardOutput); //Output data produced by underlying process

var powershell = await Cli.Wrap("powershell").WithWorkingDirectory(@"C:\").
    WithArguments(new[] { "echo hello", "world" }).ExecuteBufferedAsync();
Console.WriteLine(powershell.StandardOutput); //Output data produced by underlying process

var powershell2 = await Cli.Wrap("powershell").WithWorkingDirectory(@"C:\").
    WithArguments("echo hello world; Get-Random").ExecuteBufferedAsync();
Console.WriteLine(powershell2.StandardOutput); //Output data produced by underlying process

/*  Example output:
    git version 2.35.1.windows.2

    hello
    world

    hello
    world
    213197604
*/