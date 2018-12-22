using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SharpAdbClient;
using System.Windows;

namespace DataBindingDemo
{
    public class SMSHelper
    {
        Process cmd;
        AdbServer Server;
        public SMSHelper()
        {
            Server = new AdbServer();
            var result = Server.StartServer(@"C:\Users\msann\AppData\Local\Android\Sdk\platform-tools\adb.exe", restartServerIfNewer: false);
            //cmd = new Process();
            //cmd.StartInfo.FileName = "cmd.exe";
            //cmd.StartInfo.RedirectStandardInput = true;
            //cmd.StartInfo.RedirectStandardOutput = true;
            //cmd.StartInfo.CreateNoWindow = true;
            //cmd.StartInfo.UseShellExecute = false;
            //cmd.Start();
            //cmd.StandardInput.WriteLine("echo Oscar");
            //cmd.StandardInput.Flush();
            //cmd.StandardInput.Close();
            //cmd.WaitForExit();
            //Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }
        public bool SendSMS(List<Parent> recipients,string message)
        {
            try
            {

            var device = AdbClient.Instance.GetDevices().First();
            var receiver = new ConsoleOutputReceiver();
            foreach (var c in recipients)
            {
                if (c.ContactNo1 != null)
                {
                    string s = "adb shell am start - a android.intent.action.SENDTO - d sms:" + c.ContactNo1 + "--es sms_body " + message + "--ez exit_on_sent true";
                    AdbClient.Instance.ExecuteRemoteCommand(s, device, receiver);
                    AdbClient.Instance.ExecuteRemoteCommand("abd shell input keyevent 61", device, receiver);
                    AdbClient.Instance.ExecuteRemoteCommand("abd shell input keyevent 66", device, receiver);
                }
            }
            }
            catch (Exception e)
            {
                if (e.InnerException is NullReferenceException)
                {
                    MessageBox.Show("Device Not found");
                }
                else
                {
                    MessageBox.Show(e.Message);
                }
                return false;
            }

            //foreach(var contact in recipients)
            //{
            //if(contact.ContactNo1!=null)
            //    {
            //    string =
            //    }
            //}
            return true;
        }
        public bool SendSMS(List<Employee> recipients, string message)
        {
            
            try
            {

                var device = AdbClient.Instance.GetDevices().First();
                var receiver = new ConsoleOutputReceiver();
                foreach (var c in recipients)
                {
                    if (c.ContactNo1 != null)
                    {
                        string s = "adb shell am start - a android.intent.action.SENDTO - d sms:" + c.ContactNo1 + "--es sms_body " + message + "--ez exit_on_sent true";
                        AdbClient.Instance.ExecuteRemoteCommand(s, device, receiver);
                        AdbClient.Instance.ExecuteRemoteCommand("abd shell input keyevent 61", device, receiver);
                        AdbClient.Instance.ExecuteRemoteCommand("abd shell input keyevent 66", device, receiver);
                    }
                }
            }
            catch(Exception e)
            {
                if (e.InnerException is NullReferenceException)
                {
                    MessageBox.Show("Device Not found");
                }
                else
                {
                    MessageBox.Show(e.Message);
                }
                return false;
            }
            


            //foreach(var contact in recipients)
            //{
            //if(contact.ContactNo1!=null)
            //    {
            //    string =
            //    }
            //}
            return true;
        }
    }
}
