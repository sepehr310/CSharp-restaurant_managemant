using restaurant_managemant;



// Console.Write("Init system... ");
// using (var progress = new ProgressBar()) {
//     for (int i = 0; i <= 100; i++) {
//         progress.Report((double) i / 100);
//         Thread.Sleep(20);
//     }
// }

var timer = new OrderSchedule();
timer.Start();

Console.WriteLine("Done.");
Thread.Sleep(50);


MainMenu.MenuDisplay();
Console.WriteLine("GoodBy");
Thread.Sleep(500);
Console.Clear();

