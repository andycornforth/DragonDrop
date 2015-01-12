using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace DragDetails
{
    public interface ITemplate
    {
        void doSomething();
    }

    public class C : ITemplate
    {
        void ITemplate.doSomething() { }
    }

    static class Program 
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

        //    string[] ordinals = new string[] { "First", "Second", "Third", "Fourth" };
        //    var step1 = ordinals.Take(3);
        //    var step2 = step1.Skip(1);
        //    var step3 = step2.Take(3);
        //    Console.WriteLine(step3.Count()); 


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DragonDropForm());
        }
    }
}