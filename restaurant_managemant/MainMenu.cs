using Spectre.Console;

namespace restaurant_managemant;


public class MainMenu
{

    public static void MenuDisplay()
    {
        Console.Clear();
        var dataTable = new Table()
            .LeftAligned();
        AnsiConsole.Live(dataTable)
            .Cropping(VerticalOverflowCropping.Top)
            .Start(ctx =>
            {
                dataTable.AddColumn("Branches");
                dataTable.AddColumn("Orders");

                dataTable.AddRow("Branch 1", "Order 1");
            });
        
        var Options = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Menu Options")
                .PageSize(10)
                .AddChoices(new[] {
                    "Manage Branches", "manage Orders",
                }));
        
        AnsiConsole.WriteLine($"Open {Options} Menu!");
    }
}