namespace Branches;

public class BranchesSchema
{
    public int ?id { get; set; }
    public string branchName { get; set; }
    public int capacity { get; set; }
    
    public int ?activeOrders { get; set; }
    
}