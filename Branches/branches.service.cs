//using Newtonsoft.Json;
namespace Branches;

public class BranchesService
{
    private List<BranchesSchema> branches = new List<BranchesSchema>();
    public void create_Branch(BranchesSchema branch)
    {

        branches.Add(branch);

    
        
    }
    
    public void findAll()
    {
        foreach (var variable in branches)
        {
            Console.WriteLine(variable.branchName);
        }
    }

}