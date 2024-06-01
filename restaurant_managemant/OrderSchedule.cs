using Timer = System.Timers;
using Branches;
using Orders;
namespace restaurant_managemant;

public class OrderSchedule
{
    private Timer.Timer timer;

    public event EventHandler TimerElapsed;

    public OrderSchedule()
    {
        timer = new Timer.Timer(30000); 
        timer.Elapsed += TimerElapsedHandler;
        timer.AutoReset = true;
    }

    public void Start()
    {
        timer.Start();
    }

    public void Stop()
    {
        timer.Stop();
    }

    private void TimerElapsedHandler(object sender, Timer.ElapsedEventArgs e)
    {
        TimerElapsed?.Invoke(this, EventArgs.Empty);
        
        OrderService orderService = new OrderService();
        var orders = orderService.FindByStatus(orderStausEnum.inQueue).OrderBy(order =>order.id);
        
        BranchesService branchesService = new BranchesService();
        var listBranches = branchesService.FindAll().Where(branch =>branch.activeOrders<=branch.capacity) .OrderBy(branch => branch.activeOrders);

        foreach (var order in orders)
        {
            
        }

    }
}