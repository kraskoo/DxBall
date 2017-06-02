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
            OnTimeChange += TickChange;
            OnTimeChange += MilliSecondsChange;
        }

        public long CurrentTick
        {
            get
            {
                OnTimeChange();
                return currentTick;
            }
        }

        public int CurrentMilliSeconds
        {
            get
            {
                OnTimeChange();
                return currentMilliSeconds;
            }
        }

        private event TimeChangHandler OnTimeChange;

        private void TickChange()
        {
            currentTick = DateTime.Now.Ticks;
        }

        private void MilliSecondsChange()
        {
            currentMilliSeconds = DateTime.Now.Millisecond;
        }
    }
}