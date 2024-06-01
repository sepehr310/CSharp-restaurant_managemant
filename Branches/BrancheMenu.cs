using Spectre.Console; 

namespace Branches;

public class BranchMenu
{
    
     enum MenuDisplayEnum
    {
        AddRestaurantBranch,
        UpdateRestaurantBranch,
        ListRestaurantBranchOrders,
        Back,
    }
     
    public static void MenuDisplay()
    {
        bool manuLoop = true;

        while (manuLoop)
        {

            Console.Clear();
            AnsiConsole.Clear();
            var branchesService = new BranchesService();

            List<BranchesSchema> list = branchesService.FindAll();
            var dataTable = new Table().Centered();

            dataTable.Title = new TableTitle("List Branches");
            dataTable.AddColumn("id");
            dataTable.AddColumn("Name");
            dataTable.AddColumn("Capacity");

            foreach (var variable in list)
            {
                dataTable.AddRow($"{variable.id}",$"{variable.branchName}",$"{variable.capacity}");
            }
            AnsiConsole.Write(dataTable);

            var Options = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Menu Options")
                    .PageSize(10)
                    .Mode(SelectionMode.Leaf)
                    .AddChoices(new[] {
                        MenuDisplayEnum.AddRestaurantBranch.ToString(),MenuDisplayEnum.UpdateRestaurantBranch.ToString(),MenuDisplayEnum.ListRestaurantBranchOrders.ToString(),MenuDisplayEnum.Back.ToString()
                    }));


            if (Options == MenuDisplayEnum.AddRestaurantBranch.ToString())
            {
                Console.WriteLine("Enter BranchName: ");
                string branchName = Console.ReadLine();

                Console.WriteLine("Enter capacity: ");
                int capacity = Convert.ToInt32(Console.ReadLine());

                branchesService.create_Branch(new BranchesSchema()
                {
                    branchName = branchName,
                    capacity = capacity
                });
            }else if (Options == MenuDisplayEnum.UpdateRestaurantBranch.ToString())
            {
                Console.Write("Enter ID: ");
                BranchesSchema find = branchesService.FindById(Convert.ToInt32(Console.ReadLine()));
                Console.Clear();
                Console.WriteLine($"update Name? ({find.branchName})");
                find.branchName = Console.ReadLine() ;
                
                Console.WriteLine($"update Capacity? ({find.capacity})");
                find.capacity = Convert.ToInt32(Console.ReadLine());
                
                branchesService.UpdateById(find);

            }else if (Options==MenuDisplayEnum.ListRestaurantBranchOrders.ToString())
            {
                Console.Write("Enter ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                var branch = branchesService.FindAll().Where(item => item.id == id).First();
                
                Table ordersTable = new Table().Centered();

                ordersTable.AddColumn("id");
                ordersTable.AddColumn("Status");
                ordersTable.AddColumn("Date End");
                ordersTable.AddColumn("Price");

                foreach (var i in branch.orders)
                {
                    ordersTable.AddRow($"{i.id}", $"{i.status}", $"{i.finishTime}", $"{i.totalPrice}");
                }
                AnsiConsole.Write(ordersTable);

                
                Console.WriteLine("press any key to back...");
                Console.ReadKey(true);
                Console.Clear();

            }
            else if (Options== MenuDisplayEnum.Back.ToString())
            {
                manuLoop = false;
            }
        
        }


    }
}