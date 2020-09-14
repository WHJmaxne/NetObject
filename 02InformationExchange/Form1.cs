using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02InformationExchange
{
    public partial class Form1 : Form
    {
        event Action<int> ClickCounterEvent;
        public Form1()
        {
            InitializeComponent();
            this.button2.MyClick += Button2_MyClick;

            //Form2 f2 = new Form2();
            //Form3 f3 = new Form3();
            //ClickCounterEvent += f2.ClickEvent;
            //ClickCounterEvent += f3.ClickEvent;
            //f2.Show();
            //f3.Show();
        }
        private int counter = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;
            label1.Text = counter.ToString();
            ClickCounterEvent(counter);
        }

        private void Button2_MyClick(object sender, MyEventArgs args)
        {
            MessageBox.Show(args.ClickCount.ToString());
        }

        private void myCustomButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
