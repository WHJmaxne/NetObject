﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _02InformationExchange
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        public void ClickEvent(int counter)
        {
            label1.Text = counter.ToString();
        }
    }
}
