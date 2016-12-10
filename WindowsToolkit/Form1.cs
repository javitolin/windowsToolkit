using System;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;
using System.Threading;

namespace WindowsToolkit
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void fixPrinterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                runProcess("cmd.exe", "/C net stop spooler");
                runProcess("cmd.exe", "/C net start spooler");
                printLogMessage("Try now. If it still doesn't work.. try turning off and on the printer and running this tool again. Sorry but that's all I can do for now.");
            }
            catch(Exception e1)
            {
                printLogMessage("Error running Fix Printer. {0}", e1.Message);
            }
        }

        private void runProcess(string command, string arguments)
        {
            Process process = new Process();

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Setup executable and parameters
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;

            // Go
            process.Start();
        }


        private void printLogMessage(string msg, params string[] args)
        {
            MessageBox.Show(string.Format(msg, args), "Windows Toolkit", MessageBoxButtons.OK);
        }

        private void fixWifiBtn_Click(object sender, EventArgs e)
        {
            bool didItFixedIt = false;
            //First try to reset the network adapter.
            didItFixedIt = resetNetworkAdapter();
            if (didItFixedIt) return;

            if(MessageBox.Show("Restart the computer?", "Windows Toolkit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                didItFixedIt = restartComputer();
            }

            if (!didItFixedIt)
            {
                printLogMessage("Sorry, but that's all I can do. In the future I'll add more options.");
            }

        }

        private bool restartComputer()
        {
            //Restart the computer
            try
            {
                runProcess("shutdown.exe", "/r /t 0");
                return true;
            }

            catch(Exception e1)
            {
                printLogMessage("Couldn't restart computer, please restart computer manually. {0}", e1.Message);
                return false;
            }

        }

        private bool didItHelpMsgBox()
        {
            return MessageBox.Show("Please check if now it works. Does it?", "Did we help?", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private bool resetNetworkAdapter()
        {
            try
            {
                bool networkAdapterFound = false;
                string networkConnectionName = Properties.Settings.Default.NetworkConnectionName;
                SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
                ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
                foreach (ManagementObject item in searchProcedure.Get())
                {
                    if (((string)item["NetConnectionId"]) == networkConnectionName)
                    {
                        item.InvokeMethod("Disable", null);
                        Thread.Sleep(3500);
                        item.InvokeMethod("Enable", null);
                        networkAdapterFound = true;
                    }
                }

                if (!networkAdapterFound)
                {
                    printLogMessage("We coulnd't find any network connection. Please contact support");
                }

                return didItHelpMsgBox();
            }
            catch(Exception e1)
            {
                printLogMessage("Error running Reset Network Adapter. {0}", e1.Message);
                return false;
            }
        }
    }
}
