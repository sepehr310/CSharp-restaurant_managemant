using Spectre.Console;
namespace Orders;

public class OrdersMenu
{
     enum MenuDisplayEnum
    {
        AddOrder,
        Back,
    }
     
    public static void MenuDisplay()
    {
        bool manuLoop = true;

        while (manuLoop)
        {

            Console.Clear();
            AnsiConsole.Clear();
            var orderService = new OrderService();

            List<OrderSchema> list = orderService.FindAllOrders();
            var dataTable = new Table().Centered();

            dataTable.Title = new TableTitle("List Branches");
            dataTable.AddColumn("id");
            dataTable.AddColumn("Status");
            dataTable.AddColumn("Branch ID");
            dataTable.AddColumn("Price");

            foreach (var variable in list)
            {
                dataTable.AddRow($"{variable.id}",$"{variable.status}",$"{variable.branchId}", $"{variable.totalPrice}");
                AnsiConsole.Write(dataTable);
            }
            var Options = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Menu Options")
                    .PageSize(10)
                    .Mode(SelectionMode.Leaf)
                    .AddChoices(new[] {
                        MenuDisplayEnum.AddOrder.ToString(),MenuDisplayEnum.Back.ToString()
                    }));


            if (Options == MenuDisplayEnum.AddOrder.ToString())
            {
                bool addOrderLoop = true;
                List<OrderItemSchema> items = new List<OrderItemSchema>();
                while (addOrderLoop)
                {
                    Console.WriteLine($"Add Order\nitem no {items.Count} ");
                    Console.WriteLine("Item name: ");
                    string itemnName = Console.ReadLine();
                    Console.WriteLine("Item price: ");
                    double itemnPrice = Convert.ToDouble(Console.ReadLine());

                    OrderItemSchema newItem = new OrderItemSchema()
                    {
                        name = itemnName,
                        price = itemnPrice
                    };
                    items.Add(newItem);
                   Console.WriteLine("press F1 to save Or any key to add more"); 
                   var key = Console.ReadKey(true).Key;

                   if (key == ConsoleKey.F1)
                   {
                       OrderSchema newOrder = new OrderSchema()
                       {
                           id = 1,
                           items = items,
                           status = orderStausEnum.inQueue,
                           branchId = null,
                           totalPrice = items.Sum(item => item.price),
                       };
                       
                       orderService.CreateOrder(newOrder);
                       addOrderLoop = false;
                   }
                   Console.Clear(); 
                }
                
            }
            else if (Options== MenuDisplayEnum.Back.ToString())
            {
                manuLoop = false;
            }
        
        }


    }
}