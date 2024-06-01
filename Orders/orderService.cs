 using DataManagement;

namespace Orders;

public class OrderService
{
    public void CreateOrder(OrderSchema order)
    {
        List<OrderSchema>
            orders = DataManagement.DataManagementService.get_data<List<OrderSchema>>("orders.json");
        order.id = orders.Count + 1;  
        orders.Add(order);

        DataManagementService.save_data(orders, "orders.json");
        
        Console.WriteLine("Orders added successfully \npress any key to continues...");
        Console.ReadKey();

    }

    public List<OrderSchema> FindAllOrders()
    {
        return DataManagement.DataManagementService.get_data<List<OrderSchema>>("orders.json");
    }

    public List<OrderSchema> FindByStatus(orderStausEnum status)
    {
        return DataManagement.DataManagementService.get_data<List<OrderSchema>>("orders.json")
            .FindAll(order => order.status == status);
    }
    
    public void UpdateById(OrderSchema order)
    {
        List<OrderSchema> orders = DataManagementService.get_data<List<OrderSchema>>("orders.json");
        OrderSchema findOrders = orders.Find(item => item.id == item.id);

        if (findOrders != null)
        {
            findOrders.status = order.status;
            findOrders.branchId = order.branchId;
            
            DataManagementService.save_data(orders,"orders.json");
        }
        
    }

    public void DeleteOrder(int id)
    {
        List<OrderSchema> orders = DataManagementService.get_data<List<OrderSchema>>("orders.json");
        OrderSchema findOrders = orders.Find(item => item.id == id);

        if (findOrders != null)
        {
            
            orders.Remove(findOrders);
            DataManagementService.save_data(orders,"orders.json");
        }
        
    }
}