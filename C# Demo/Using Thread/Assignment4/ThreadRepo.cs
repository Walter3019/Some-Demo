/*
* FILE           : ThreadRepo.cs
*
* PROJECT        : PROG2120-1 - Assignment 04 
*
* PROGRAMMER     : Lingchen Meng (Walter)
*
* FIRST VERSION  : 2015-10-20
*
* DESCRIPTION    : this file is used to store all alive thread in this program.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment4
{
    class ThreadRepo
    {
        // list to store all threads.
        List<Thread> threads = new List<Thread>();

        // constructor.
        public ThreadRepo() { }

        /// <summary>
        /// This Method is used to add new thread into list called threads.
        /// </summary>
        /// <param name="name"> the name of thread.</param>
        /// <param name="ts"> thread start </param>
        public void Add(string name, ThreadStart ts)
        {
            Thread t = new Thread(ts);
            t.Name = name;
            threads.Add(t);
            // set thread to background.
            t.IsBackground = true;
            // start this thread.
            t.Start();
        }

        /// <summary>
        /// this Method is used to pause all alive threads.
        /// </summary>
        public void PauseAll()
        {
            if (threads.Count != 0)
            {
                foreach (Thread item in threads)
                {
                    if (item.IsAlive)
                    {
                        item.Suspend();
                    }
                }
            }
        }

        /// <summary>
        /// this Method is used to restart threads.
        /// </summary>
        public void Resume()
        {
            if (threads.Count != 0)
            {
                foreach (Thread item in threads)
                {
                    if (item.IsAlive)
                    {
                        item.Resume();
                    }
                }
            }
        }

        public void KillAll()
        {
            // clear all threads in list.
            threads.Clear();
        }
    }
}
