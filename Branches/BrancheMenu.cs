using Spectre.Console; 

namespace Branches;

public class BranchMenu
{
    
     enum MenuDisplayEnum
    {
        AddBranch,
        UpdateBranch,
    }
    public static void MenuDisplay()
    {
       
        var Options = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Menu Options")
                .PageSize(10)
                .Mode(SelectionMode.Leaf)
                .AddChoices(new[] {
                    MenuDisplayEnum.AddBranch.ToString(),MenuDisplayEnum.UpdateBranch.ToString()
                }));
        
        
        
    }
}