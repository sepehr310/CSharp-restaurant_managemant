using Spectre.Console; 

namespace Branches;

public class BranchMenu
{
    
     enum MenuDisplayEnum
    {
        AddBranch,
        UpdateBranch,
        Back,
    }
     
    public static void MenuDisplay()
    {
        bool manuLoop = true;

        while (manuLoop)
        {

            Console.Clear();
            AnsiConsole.Clear();
            var branch = new BranchesService();

            List<BranchesSchema> list = branch.FindAll();
            var dataTable = new Table().Centered();

            dataTable.Title = new TableTitle("List Branches");
            dataTable.AddColumn("id");
            dataTable.AddColumn("Name");
            dataTable.AddColumn("Capacity");

            foreach (var variable in list)
            {
                dataTable.AddRow($"{variable.id}",$"{variable.branchName}",$"{variable.capacity}");
                AnsiConsole.Write(dataTable);
            }
            var Options = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Menu Options")
                    .PageSize(10)
                    .Mode(SelectionMode.Leaf)
                    .AddChoices(new[] {
                        MenuDisplayEnum.AddBranch.ToString(),MenuDisplayEnum.UpdateBranch.ToString(),MenuDisplayEnum.Back.ToString()
                    }));


            if (Options == MenuDisplayEnum.AddBranch.ToString())
            {
                Console.WriteLine("Enter BranchName: ");
                string branchName = Console.ReadLine();

                Console.WriteLine("Enter capacity: ");
                int capacity = Convert.ToInt32(Console.ReadLine());

                branch.create_Branch(new BranchesSchema()
                {
                    branchName = branchName,
                    capacity = capacity
                });
            }else if (Options == MenuDisplayEnum.UpdateBranch.ToString())
            {
                Console.Write("Enter ID: ");
                BranchesSchema find = branch.FindById(Convert.ToInt32(Console.ReadLine()));
                Console.Clear();
                Console.WriteLine($"update Name? ({find.branchName})");
                find.branchName = Console.ReadLine() ;
                
                Console.WriteLine($"update Capacity? ({find.capacity})");
                find.capacity = Convert.ToInt32(Console.ReadLine());
                
                branch.UpdateById(find);

            }
            else if (Options== MenuDisplayEnum.Back.ToString())
            {
                manuLoop = false;
            }
        
        }


    }
}