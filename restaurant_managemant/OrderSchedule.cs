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

        bool loop = true;

        // while (loop)
        // {
        //     
        //     OrderService orderService = new OrderService();
        //     var order = orderService.FindByStatus(orderStausEnum.inQueue).OrderBy(order =>order.id).First();
        //
        //     if (order == null)
        //     {
        //         return;
        //     }
        //     
        //     BranchesService branchesService = new BranchesService();
        //     var branch = branchesService.FindAll().Where(branch =>branch.activeOrders<=branch.capacity) .OrderBy(branch => branch.activeOrders).First();
        //
        //     
        //     if (branch == null)
        //     {
        //         return;
        //     }
        //
        //     order.status = orderStausEnum.pending;
        //     order.branchId = 1;
        //   //  orderService.a
        // }

    }
}