using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Web;
using System.Web.Providers.Entities;
using System.Windows.Forms;

namespace WebRole1
{
    public class BusinessLogic
    {
        Collection<PSObject> results = null;
        static RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
        Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);      


        public string SetupWebPI()
        {
            try
            {
                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //String scriptfile = System.Web.HttpContext.Current.Server.MapPath("App_Data/AzureSetup.ps1");
                //startInfo.FileName = scriptfile;
                //startInfo.RedirectStandardOutput = true;
                //startInfo.RedirectStandardError = true;
                //startInfo.UseShellExecute = false;
                //startInfo.CreateNoWindow = true;
                //Process process = new Process();
                //process.StartInfo = startInfo;
                //process.Start();
                //process.WaitForExit();

                //string path = Directory.GetCurrentDirectory();                
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                String scriptfile = System.Web.HttpContext.Current.Server.MapPath("App_Data/AzureSetup.ps1");
                Command myCommand = new Command(scriptfile);
                pipeline.Commands.Add(myCommand);            
                results = pipeline.Invoke();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }   

        }
        public string SetupAzure()
        {
           String str = null;
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // this script has a sleep in it to simulate a long running script                   
                String scriptfile = System.Web.HttpContext.Current.Server.MapPath("App_Data/AzureSetup.ps1");
                PowerShellInstance.AddScript(scriptfile);

                // begin invoke execution on the pipeline
                Collection<PSObject> result = PowerShellInstance.Invoke();
                foreach (PSObject obj in result)
                {
                    PSMemberInfoCollection<PSPropertyInfo> propInfos = obj.Properties;
                    foreach (PSPropertyInfo propInfo in propInfos)
                    {
                        string propInfoValue = (propInfo.Value == null) ? "" : propInfo.Value.ToString();

                        str += propInfoValue + "    " + propInfo.Name + "\n";
                    }
                }
            }
                return str;
        }

        public String createVM(VMDetails vmDetails)
        {
            
            try
            { 
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            String scriptfile = System.Web.HttpContext.Current.Server.MapPath("App_Data/CreateVM.ps1");
            Command myCommand = new Command(scriptfile);

            CommandParameter Imagename = new CommandParameter("imageName", vmDetails.ImageName);
            myCommand.Parameters.Add(Imagename);
            CommandParameter VmName = new CommandParameter("vmName", vmDetails.VMName);
            myCommand.Parameters.Add(VmName);
            CommandParameter InstanceSize = new CommandParameter("instanceSize", vmDetails.InstanceSize);
            myCommand.Parameters.Add(InstanceSize);
            CommandParameter DataDisk = new CommandParameter("dataDisk", vmDetails.Datadisk);
            myCommand.Parameters.Add(DataDisk);
            CommandParameter serviceName = new CommandParameter("serviceName", vmDetails.ServiceName);
            myCommand.Parameters.Add(serviceName);
            CommandParameter userName = new CommandParameter("userName", vmDetails.UserName);
            myCommand.Parameters.Add(userName);
            CommandParameter Password = new CommandParameter("Password", vmDetails.Passowrd);
            myCommand.Parameters.Add(Password);
            CommandParameter Location = new CommandParameter("Location", vmDetails.Location);
            myCommand.Parameters.Add(Location);

            
            pipeline.Commands.Add(myCommand);
            results = pipeline.Invoke();

            return "VM Created Successfully....  Username: " +vmDetails.UserName +"  Password: "+ vmDetails.Passowrd;
                
          }
            catch(Exception ex)
            {
                return ex.Message.ToString();                
            }

        }

        /// <summary>
        /// Returns the Azure Images
        /// </summary>
        /// <param name="errormsg"></param>
        /// <returns></returns>

        public List<String> GetAzureImages(out string errormsg)
        {
          //  runspace.Open();
            errormsg = null;
            List<String> ImageList = new List<string>();
            Collection<PSObject> result=null;
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                      PowerShellInstance.AddScript("Get-AzureVMImage |Select ImageName");                                     
                        result = PowerShellInstance.Invoke(); 
                    while (result.Count==0)
                    {
                        result = PowerShellInstance.Invoke(); 

                    }
  
                        foreach (PSObject obj in result)
                        {
                            PSMemberInfoCollection<PSPropertyInfo> propInfos = obj.Properties;
                            foreach (PSPropertyInfo propInfo in propInfos)
                            {
                                string propInfoValue = (propInfo.Value == null) ? "" : propInfo.Value.ToString();
                                ImageList.Add(propInfoValue);
                            }
                            
                        }
                }
                return ImageList;
            }
            catch (Exception ex)
            {
                errormsg=ex.Message.ToString(); 
            }
           // runspace.Close();
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public void InstallPowershell()
        {
            try
            {




                ProcessStartInfo psi = new ProcessStartInfo();
                psi.Arguments = "–s –v –qn";
                psi.CreateNoWindow = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.FileName = @"C:\Users\v-prwagh\Downloads\WindowsAzurePowerShell.3f.3f.3fnew.exe";
                Process.Start(psi);


                //WebClient webClient = new WebClient();
        //    webClient.DownloadFile("http://go.microsoft.com/?linkid=9811175", @"C:\Resources\temp\Source\Powershell.exe");
        //        System.Diagnostics.Process.Start("Cmd.exe", @"/C C:\Users\v-prwagh\Downloads\WindowsAzurePowerShell.3f.3f.3fnew.exe /i /q").WaitForExit();
        
        //    string installerFilePath;
        //installerFilePath = @"C:\Users\v-prwagh\Downloads\WindowsAzurePowerShell.3f.3f.3fnew.exe";
        //   System.Diagnostics.Process installerProcess;
        //    installerProcess = System.Diagnostics.Process.Start(installerFilePath, "/q");              

        //    while (installerProcess.HasExited == false)
        //    {
        //        //indicate progress to user                   
        //        System.Threading.Thread.Sleep(250);
        //    }
                MessageBox.Show("done installing");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
    

        public string VMList()
        {
            String str1 = null;
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            String scriptfile = @"C:\Users\v-prwagh\Desktop\VmDetails.ps1";
            //Here's how you add a new script with arguments
            Command myCommand = new Command(scriptfile);
            pipeline.Commands.Add(myCommand);

            // Execute PowerShell script
            results = pipeline.Invoke();

            foreach (PSObject obj in results)
            {
                PSMemberInfoCollection<PSPropertyInfo> propInfos = obj.Properties;
                foreach (PSPropertyInfo propInfo in propInfos)
                {
                    if (propInfo.Name.Contains("Name"))
                    {
                        string propInfoValue = (propInfo.Value == null) ? "" : propInfo.Value.ToString();
                        str1 += propInfoValue + "    " + propInfo.Name + "\n";
                    }
                }
            }

            return str1;

            ///*********************************************************************************************************************
            ///Below code is also working.
            ///
            ///

            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = @"powershell.exe";
            //startInfo.Arguments = @"& 'C:\Users\v-prwagh\Desktop\VmDetails.ps1'";
            //startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = true;
            //startInfo.UseShellExecute = false;
            //startInfo.CreateNoWindow = true;
            //Process process = new Process();
            //process.StartInfo = startInfo;
            //process.Start();

            //string output = process.StandardOutput.ReadToEnd();
            //TextBox1.Text = output;

            //******************************************************************************************************************************//

        }

    }
}