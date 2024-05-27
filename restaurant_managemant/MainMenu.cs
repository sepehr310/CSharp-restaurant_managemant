using Spectre.Console;
using Branches;
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
                .Mode(SelectionMode.Leaf)
                .AddChoices(new[] {
                    "Manage Branches", "manage Orders",
                }));
        
        //TODO: add switch case

        if (Options=="Manage Branches")
        {
            BranchMenu.MenuDisplay();
        }
    }
}