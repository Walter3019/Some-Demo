/*
* FILE           : Program.cs
*
* PROJECT        : PROG2120-1 - Assignment 04 
*
* PROGRAMMER     : Lingchen Meng (Walter)
*
* FIRST VERSION  : 2015-10-20
*
* DESCRIPTION    : this file is entre of program.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mystify());
        }
    }
}
