using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using DragDetails.Forms;

namespace DragDetails
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            //bool createdNew = true;
            //using (Mutex mutex = new Mutex(true, "DragonDrop", out createdNew))
            //{
            //    if (createdNew)
            //    {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DragonDropForm());
            //    }
            //    else
            //    {
            //        Message.ShowNewMessage("You already have an instance of Dragon Drop Running", "Duplication");
            //    }
            //}

        }
    }
}