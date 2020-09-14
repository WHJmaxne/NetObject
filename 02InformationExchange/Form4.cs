using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _02InformationExchange
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            StringBuilder sb = new StringBuilder();
            InitializeComponent();

            button1.Click += ButtonClick;
            button2.Click += ButtonClick;
            button3.Click += ButtonClick;
        }

        private void ButtonClick(object sender, EventArgs args)
        {
            var button = sender as Button;
            if (button != null)
            {
                MessageBox.Show(button.Name + "被单击");
            }

            this.Invoke(new Action(() => { }));
        }
    }
}
