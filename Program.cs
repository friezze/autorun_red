using System;
using Microsoft.Win32;
using System.Reflection;
using System.Diagnostics;

namespace autorun_red
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

            
            int HelpCount = 0;
            int ReloadCount = 0;
            int OnOROff = 0;
            for (int i = 0; i < args.Length; i++)
            {
                string a = args[i].ToLower();
                if (a == "/r" || a == "-r")
                {
                    ReloadCount = 1;
                }
                else if (a == "/on" || a == "-on")
                {
                    OnOROff = 1;
                }
                else if (a == "/off" || a == "-off")
                {
                    OnOROff = -1;
                }
                else if (a == "/h" || a == "/?" || a =="/help" || a == "-h" || a == "-?" || a == "-help" )
                {
                   HelpCount = 1;
                }

            }
           
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo("cmd.exe", "regsvr32 Microsoft.Win32.Registry.dll");
                p.Start();
                p.Kill();


            if (HelpCount == 0)
            {
                    string first = " ";
                    string second = " ";

                    RegistryKey SwitchLocal = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                    

                        
                        foreach (var name in SwitchLocal.GetValueNames())
                        {
                            if (name == "NoDriveTypeAutoRun")
                            {
                                first = "NoDriveTypeAutoRun";
                            }
                        }

                    SwitchLocal.Close();



                     RegistryKey SwitchGlobal = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"); 
                    

                        foreach (var name in SwitchGlobal.GetValueNames())
                        {
                            if (name == "NoDriveTypeAutoRun")
                            {
                                second = "NoDriveTypeAutoRun";
                            }
                        }

                    SwitchGlobal.Close();






                    SwitchLocal = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                    SwitchGlobal = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");



                if (OnOROff == -1)
                    {
                        if (first != " " && second != " ")
                        {
                            Console.WriteLine(" Keys NoDriveTypeAutoRun existed they value now  = 0x000000ff");
                        }
                        else if (first == " " && second == " ")
                        {
                            Console.WriteLine(" Keys NoDriveTypeAutoRun created they value now  = 0x000000ff");
                        }
                        
                                          
                    SwitchLocal.SetValue("NoDriveTypeAutoRun", 0x000000ff);
                    SwitchGlobal.SetValue("NoDriveTypeAutoRun", 0x000000ff);
                }
                else if (OnOROff == 1)
                {

                        if (first != " " && second != " ")
                        {
                            Console.WriteLine(" Keys NoDriveTypeAutoRun existed but now will be deleted");
                        }
                        else if (first == " " && second == " ")
                        {
                            Console.WriteLine(" Keys NoDriveTypeAutoRun not existed");
                        }

                    SwitchLocal.SetValue("NoDriveTypeAutoRun", 0x000000ff);
                    SwitchGlobal.SetValue("NoDriveTypeAutoRun", 0x000000ff);

                    SwitchLocal.DeleteValue("NoDriveTypeAutoRun");
                    SwitchGlobal.DeleteValue("NoDriveTypeAutoRun");
                }
                else if (OnOROff == 0)
                {
                        Console.WriteLine("  dont have required parameter use -h for learn how to do it right");
                }

                    if (ReloadCount == 1)
                    {
                        
                        
                        while (true)
                        {
                            Console.WriteLine(" Reload computer [y/n]");
                            string Reload = Console.ReadLine();

                            if (Reload == "y")
                            {
                                Process.Start("shutdown", "/r /t 0");
                            }
                            else if (Reload == "n")
                            {
                                break;
                            }
                        }
                       
                       
                    }
            }
            else if(HelpCount == 1)
            {
                    Console.WriteLine("\n  program has been run with 1 required parameter \n   has read 3 parameters:\n   required: \"-off\" - turn off autorun or \"-on\" - turn on autorun\n   \"-r\" - to restart computer to apply changes to the registry\n   \"-h\" - to get help if use this you dont need required parameter");
            }
            }
            catch (Exception)
            {

                Console.WriteLine("\n  something go wrong fistly try too use administrative access if this dont help tell devoloper about this problem");
            }

        }
    }
}
