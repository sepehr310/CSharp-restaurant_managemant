//using Newtonsoft.Json;

using DataManagement;
using Orders;

namespace Branches;

public class BranchesService
{
    public void create_Branch(BranchesSchema branch)
    {
     List<BranchesSchema> branches = DataManagementService.get_data<List<BranchesSchema>>("branches.json");

     branch.id = branches.OrderBy(list=>list.id).ToList().Last().id +1;

     branch.activeOrders = 0;
     branches.Add(branch);
     branch.orders = new List<OrderSchema>();

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
        BranchesSchema findBranch = branches.Find(x => x.id == branch.id);

        if (findBranch != null)
        {
            findBranch.branchName = branch.branchName;
            findBranch.capacity = branch.capacity;
            findBranch.activeOrders = branch.activeOrders;
            findBranch.orders = branch.orders;
            DeleteBranch(findBranch.id);
            Thread.Sleep(10);
            DataManagementService.save_data(branches,"branches.json");
        }
        
    }

    public void AddOrderToBranch(OrderSchema order, int branchId)
    {
        List<BranchesSchema> branches = DataManagementService.get_data<List<BranchesSchema>>("branches.json");
        BranchesSchema findBranch = branches.Find(item => item.id == branchId);
        findBranch.orders.Add(order);
        findBranch.activeOrders += 1;
        
        UpdateById(findBranch);        
        
    }
    
    public void DeleteBranch(int id)
    {
        List<OrderSchema> branches = DataManagementService.get_data<List<OrderSchema>>("branches.json");
        OrderSchema findBranch = branches.Find(item => item.id == id);

        if (findBranch != null)
        {
            
            branches.Remove(findBranch);
            DataManagementService.save_data(branches,"orders.json");
        }
        
    }

    public BranchesSchema FindById(int id)
    {
        List<BranchesSchema> branches = DataManagementService.get_data<List<BranchesSchema>>("branches.json");
        return branches.Find(branch => branch.id ==id);
    }
}