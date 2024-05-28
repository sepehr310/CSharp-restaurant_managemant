using Spectre.Console; 

namespace Branches;

public class BranchMenu
{
    
     enum MenuDisplayEnum
    {
        AddBranch,
        ListBranches,
        Back,
    }
     
    public static void MenuDisplay()
    {
        bool manuLoop = true;

        while (manuLoop)
        {
            var Options = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Menu Options")
                    .PageSize(10)
                    .Mode(SelectionMode.Leaf)
                    .AddChoices(new[] {
                        MenuDisplayEnum.AddBranch.ToString(),MenuDisplayEnum.ListBranches.ToString(),MenuDisplayEnum.Back.ToString()
                    }));

            var branch = new BranchesService();

            if (Options== MenuDisplayEnum.AddBranch.ToString())
            {
                Console.WriteLine("Enter BranchName: ");
                string branchName = Console.ReadLine();
            
                Console.WriteLine("Enter capacity: ");
                int capacity = Convert.ToInt32(Console.ReadLine());
            
                branch.create_Branch(new BranchesSchema()
                {
                    branchName = branchName,
                    capasity = capacity
                });
            }
            else if (Options == MenuDisplayEnum.ListBranches.ToString())
            {
                branch.findAll();
            }else if (Options== MenuDisplayEnum.Back.ToString())
            {
                manuLoop = false;
            }
        
        }


    }
}