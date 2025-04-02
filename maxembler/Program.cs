using maxembler.Models.StateMachines;
using maxembler.Models.StateMachines.Abstract;
using maxembler.Models.StateMachines.Routes;
using maxembler.Views;

namespace maxembler;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        //Application.Run(new MainForm());

        Console.WriteLine();
        
        Application.Run(new MainForm());
    }
}