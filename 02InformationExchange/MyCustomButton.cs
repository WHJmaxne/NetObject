using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace _02InformationExchange
{
    public class MyEventArgs : EventArgs
    {
        public int ClickCount { get; private set; }
        public MyEventArgs(int count)
        {
            ClickCount = count;
        }
    }

    public delegate void MyEventHandle(object sender, MyEventArgs args);
    public class MyCustomButton : Button
    {
        public event MyEventHandle MyClick;
        private int ClickCount = 0;
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            ClickCount++;
            MyClick?.Invoke(this, new MyEventArgs(ClickCount));
        }
    }
}
