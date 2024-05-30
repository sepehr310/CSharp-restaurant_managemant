//using Newtonsoft.Json;

using DataManagement;

namespace Branches;

public class BranchesService
{
    public void create_Branch(BranchesSchema branch)
    {
     List<BranchesSchema> branches = new List<BranchesSchema>();

     branches.Add(branch);

     DataManagementService.save_data(branches,"branches.json");


    }
    
    public void findAll()
    {
        List<BranchesSchema> branches = DataManagementService.get_data<List<BranchesSchema>>("branches.json");
        foreach (var variable in branches)
        {
            Console.WriteLine(variable.branchName);
            
        }
    }

}