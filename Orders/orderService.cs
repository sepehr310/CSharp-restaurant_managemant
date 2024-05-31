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
}