using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsynchronousTimer
{
    class AsyncTimer
    {
        private int timeIntervals;
        private int allTicks;
        public Action<string> Tick { get; private set; }

        public AsyncTimer(int timeIntervals, int allTicks, Action<string> tick)
        {
            this.TimeIntervals = timeIntervals;
            this.AllTicks = allTicks;
            this.Tick = tick;
        }

        public int TimeIntervals
        { 
            get { return this.timeIntervals; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interval can not be negative!");
                }
                this.timeIntervals=value;
            }
        }

        public int AllTicks
        {
            get { return this.allTicks; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interval can not be negative!");
                }
                this.allTicks = value;
            }
        }

        private void OnTick()
        {
            while (this.AllTicks > 0)
            {
                Thread.Sleep(this.TimeIntervals);
                if (Tick != null)
                {
                    Tick(this.AllTicks + "");
                }
                this.AllTicks--;
            }
        }
        public void Start()
        {
            Thread thread = new Thread(this.OnTick);
            thread.Start();
        }
    }
}
