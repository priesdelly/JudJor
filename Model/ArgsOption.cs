using CommandLine;

namespace JudJor.Model;

public class ArgsOption
{
    [Option("hidden", Required = false, HelpText = "Run the application minimized to the system tray.")]
    public bool Hidden { get; set; }

    [Option("debug", Required = false, HelpText = "Run the application with debug mode.")]
    public bool Debug { get; set; }
}