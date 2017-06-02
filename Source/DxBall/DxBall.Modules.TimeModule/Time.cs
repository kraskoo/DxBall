namespace DxBall.Modules.TimeModule
{
    using System;

    internal delegate void TimeChangHandler();

    public class Time
    {
        private long currentTick;
        private int currentMilliSeconds;

        public Time()
        {
            this.OnTimeChange += TickChange;
            this.OnTimeChange += MilliSecondsChange;
        }

        public long CurrentTick
        {
            get
            {
                this.OnTimeChange();
                return this.currentTick;
            }
        }

        public int CurrentMilliSeconds
        {
            get
            {
                this.OnTimeChange();
                return this.currentMilliSeconds;
            }
        }

        private event TimeChangHandler OnTimeChange;

        private void TickChange()
        {
            this.currentTick = DateTime.Now.Ticks;
        }

        private void MilliSecondsChange()
        {
            this.currentMilliSeconds = DateTime.Now.Millisecond;
        }
    }
}