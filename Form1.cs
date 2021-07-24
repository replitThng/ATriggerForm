using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATriggerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer10ms.Enabled = true; //enable the timer, timer will trigger only when form runs
            Setup();
        }

        private void timer10ms_Tick(object sender, EventArgs e)
        {
            trigger.tickTheClass();
            SetTextBox(trigger.GetCounter().ToString());
        }

        public void SetTextBox(String text) //Method to specifically update textbox 1
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { SetTextBox(text); });
                return;
            }
            textBox1.Text = text;
        }

        private void buttonStart_Click(object sender, EventArgs e) // enable the timer after the class is defined
        {
            timer10ms.Enabled = (timer10ms.Enabled == false) ? true : false;
            buttonStart.Text = (timer10ms.Enabled == false) ? "Start" : "Stop";

        }
    }
}
