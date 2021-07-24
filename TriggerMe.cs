using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATriggerForm
{
    public partial class Form1 : Form
    {
        TriggerClass trigger;
        public void Setup()
        {
            trigger = TriggerClass.InitializeTriggerMe();
        }
    }

    class TriggerClass
    {
        public delegate int countUp(int x);
        public event countUp tickEvent;

        private int  value;
        public int GetCounter(){ return value;}
        public int TriggerFunction(int x)
        {
            value = (value >= int.MaxValue) ? 1 : value;
            value = (value == 0) ? 1 : value;
            value += x;
            return value;
        }
        TriggerClass()
        {
            value = 1;
        }
        public static TriggerClass InitializeTriggerMe()
        {
            TriggerClass initState = new TriggerClass();
            initState.tickEvent += new countUp(initState.TriggerFunction);
            return initState;
        }
        public void tickTheClass()
        {
            tickEvent(value);
        }

    }
}
