using Spectre.Console;
using Branches;
using Orders;

namespace restaurant_managemant;


public class MainMenu
{

    public static void MenuDisplay()
    {
        bool menuLoop = true;

        while (menuLoop)
        {
            Console.Clear();
            var branchService = new BranchesService();
            List<BranchesSchema> branches = branchService.FindAll();
            var dataTable = new Table()
                .Centered();
            
            AnsiConsole.Live(dataTable)
                .Cropping(VerticalOverflowCropping.Top)
                .Start(ctx =>
                {
                    dataTable.AddColumn("Branches");
                    dataTable.AddColumn("Capacity");
                    dataTable.AddColumn("TotalOrdes");
                    dataTable.AddColumn("Total Price");


                    double? totalPrice = 0.0;
                    foreach (var branch in branches)
                    {
                        double? price = branch.orders.Sum(item => item.totalPrice);
                        dataTable.AddRow($"{branch.branchName}",$"{branch.activeOrders}/{branch.capacity}",$"{branch.orders.Count()}",$"${price}");
                        totalPrice += price;

                    }
                    dataTable.AddRow($"-",$"-","-",$"total: ${totalPrice}");
                });
        
            var Options = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Menu Options")
                    .PageSize(10)
                    .Mode(SelectionMode.Leaf)
                    .AddChoices(new[] {
                        "Manage Restaurant Branches", "manage Orders","Exit"
                    }));
        
            //TODO: add switch case

            if (Options=="Manage Restaurant Branches")
            {
                BranchMenu.MenuDisplay();
            }else if (Options == "manage Orders")
            {
                OrdersMenu.MenuDisplay();
            }
            else if (Options == "Exit")
            {
                menuLoop = false;
                
            }
        }
    }
}