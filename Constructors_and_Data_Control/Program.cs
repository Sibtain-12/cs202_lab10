using System;

namespace Lab10.Constructors
{
    class Program
    {
        private int data;
        private static int liveCount = 0;

        public Program()
        {
            liveCount++;
            Console.WriteLine($"Constructor Called. Active objects: {liveCount}");
        }

        ~Program()
        {
            liveCount--;
            Console.WriteLine($"Object Destroyed. Active objects: {liveCount}");
        }

        public void set_data(int x) => data = x;

        public void show_data() => Console.WriteLine($"data = {data}");

        // Create objects in a separate scope so they become unreachable
        static void MakeObjects()
        {
            var p1 = new Program();
            var p2 = new Program();
            var p3 = new Program();

            p1.set_data(10);
            p2.set_data(20);
            p3.set_data(30);
            Console.WriteLine("\nValues in sequential order:");
            p1.show_data();
            p2.show_data();
            p3.show_data();
            Console.WriteLine();
        }

        public static void Main()
        {
            Console.WriteLine("Creating objects...\n");
            MakeObjects();                    
            GC.Collect();                     
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine();          
            Console.WriteLine("End of Main");
        }
    }
}
