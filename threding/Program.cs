using System.Diagnostics;

#region Definitions
var array = new int[16];
var r = new Random();
var array2d = new int[4, 4];

#endregion

Thread.CurrentThread.Name = "ForegroundThread";

RandomizeArray();
ArrayToArray2D();
var backgroundThread = new Thread(ArrayToArray2D);
backgroundThread.Name = "BackgroundThread";
backgroundThread.Start();


void ArrayToArray2D()
{
    Console.WriteLine($"Поток {Thread.CurrentThread.Name} начал работу.");
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    Array.Sort(array);
    for (int i = 0; i < array.Length; i++)
    {
        array2d[i / 4, i % 4] = array[i];
    }
    stopWatch.Stop();
    Console.WriteLine($"Поток {Thread.CurrentThread.Name} закончил работу.");
    Console.WriteLine($"StopWatch: {stopWatch.ElapsedTicks}");
    
}

void RandomizeArray()
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = r.Next(0, 100);
    }
}