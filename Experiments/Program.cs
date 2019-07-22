using System;

namespace Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Consumer consumer = new Consumer(counter);

            Console.WriteLine("press a key to increase total!");
            while(!consumer.YouCanLeave){
                Console.WriteLine("adding one!");
                counter.Add(1);
                System.Threading.Thread.Sleep(1000);
            }
        }      
    }

    public class Counter {
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        public int Threshold    {get; set;}
        public int Total        {get;set;}

        public Counter(){
            Threshold = new Random().Next(5,10);
            Total = 0;
        }

        public void Add(int x){
            Total += x;
            if (Total >= Threshold){
                OnThresholdReached(new ThresholdReachedEventArgs {
                    Threshold   = Threshold,
                    TimeReached = DateTime.UtcNow
                });
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e){
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            handler?.Invoke(this, e);
        }
    }

    public class ThresholdReachedEventArgs : EventArgs {
        public int Threshold        { get; set; } 
        public DateTime TimeReached { get; set; }
    }

    public class Consumer {
        public bool YouCanLeave {get;set;}
        public Consumer(Counter c){
            c.ThresholdReached += c_ThresholdReached;
            YouCanLeave = false;
        }
        void c_ThresholdReached(object sender, ThresholdReachedEventArgs e){
            Console.WriteLine($"The threshold of {e.Threshold} was reached at {e.TimeReached}");
            YouCanLeave = true;
        }
    }
}
