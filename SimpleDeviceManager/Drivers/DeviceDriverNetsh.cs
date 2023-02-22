using SimpleDeviceManager.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace SimpleDeviceManager.Drivers
{
    public class DeviceDriverNetsh : IDeviceDriver
    {
        public bool DisableDevice(string deviceName)
        {
            Process process = new Process();
            process.StartInfo.FileName = "netsh.exe";
            process.StartInfo.Arguments = $"interface set interface \"{deviceName}\" admin=disable";
            process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                return true;
            }

            return false;
        }

        public bool EnableDevice(string deviceName)
        {
            Process process = new Process();
            process.StartInfo.FileName = "netsh.exe";
            process.StartInfo.Arguments = $"interface set interface \"{deviceName}\" admin=enable";
            process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                return true;
            }

            return false;
        }

        public List<string> getDeviceList()
        {
            List<string> adapterNames = new List<string>();

            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    adapterNames.Add(nic.Name);
                }
            }

            return adapterNames;
        }

        public bool IsDeviceEnabled(string deviceName)
        {
            Process process = new Process();
            process.StartInfo.FileName = "netsh.exe";
            process.StartInfo.Arguments = $"interface set interface \"{deviceName}\" admin=enable";
            process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                return true;
            }

            return false;
        }
    }
}
