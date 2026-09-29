using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;

namespace FrmBasicThread
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();

            AllocConsole();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            // Initial console and label state output matching Figure 2
            Console.WriteLine("-Before starting thread-");

            // Create two threads pointing to MyThreadClass.Thread1
            ThreadStart tsA = new ThreadStart(MyThreadClass.Thread1);
            ThreadStart tsB = new ThreadStart(MyThreadClass.Thread1);

            Thread threadA = new Thread(tsA);
            Thread threadB = new Thread(tsB);

            // Name the threads as required
            threadA.Name = "Thread A Process";
            threadB.Name = "Thread B Process";

            // Start both threads
            threadA.Start();
            threadB.Start();

            // Use Join() to stop the calling thread until each thread terminates
            threadA.Join();
            threadB.Join();

            // Once threads stop, update label to "-End of Thread-" and print to console
            label1.Text = "-End of Thread-";
            Console.WriteLine("-End of Thread-");
        }
    }
}