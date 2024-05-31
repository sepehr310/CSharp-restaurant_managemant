//using Newtonsoft.Json;

using DataManagement;

namespace Branches;

public class BranchesService
{
    public void create_Branch(BranchesSchema branch)
    {
     List<BranchesSchema> branches = DataManagementService.get_data<List<BranchesSchema>>("branches.json");

     branch.id = branches.OrderBy(list=>list.id).ToList().Last().id +1;
      
     branches.Add(branch);

     DataManagementService.save_data(branches,"branches.json");

    }
    
    public List<BranchesSchema> FindAll()
    {
        List<BranchesSchema> branches = DataManagementService.get_data<List<BranchesSchema>>("branches.json");
        return branches;
    }

    public void UpdateById(BranchesSchema branch)
    {
        List<BranchesSchema> branches = DataManagementService.get_data<List<BranchesSchema>>("branches.json");
        BranchesSchema findBranch = branches.Find(branch => branch.id == branch.id);

        if (findBranch != null)
        {
            findBranch.branchName = branch.branchName;
            findBranch.capacity = branch.capacity;
            DataManagementService.save_data(branches,"branches.json");
            
            Console.WriteLine("Updated Successfully");
        }
        else
        {
            Console.WriteLine("NotFound");
        }
        
    }

    public BranchesSchema FindById(int id)
    {
        List<BranchesSchema> branches = DataManagementService.get_data<List<BranchesSchema>>("branches.json");
        return branches.Find(branch => branch.id ==id);
    }
}