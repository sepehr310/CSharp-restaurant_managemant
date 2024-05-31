namespace Orders;

public class OrderSchema
{
  public  int id { get; set; }
  public  List<OrderItemSchema> items { get; set; }
  public int ?branchId { get; set; }
  public double ?totalPrice { get; set; }
  public orderStausEnum status { get; set; }
}