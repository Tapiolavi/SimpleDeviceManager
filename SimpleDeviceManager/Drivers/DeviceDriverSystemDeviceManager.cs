using SimpleDeviceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Management;

namespace SimpleDeviceManager.Drivers
{
    public class DeviceDriverSystemDeviceManager : IDeviceDriver
    {
        private const string ROOT_MANAGEMENT_SCOPE = "\\\\.\\root\\cimv2";

        public bool DisableDevice(string deviceName)
        {
            var query = new ObjectQuery("SELECT * FROM Win32_PnPEntity");
            var scope = new ManagementScope(ROOT_MANAGEMENT_SCOPE);

            var searcher = new ManagementObjectSearcher(scope, query);
            var deviceList = searcher.Get();

            foreach (var device in deviceList)
            {
                var name = device["Name"].ToString();

                if (name == deviceName)
                {
                    var managementObj = (ManagementObject)device;

                    managementObj.InvokeMethod("Disable", null);

                    return true;
                }
            }

            return false;
        }

        public bool EnableDevice(string deviceName)
        {
            var query = new ObjectQuery("SELECT * FROM Win32_PnPEntity");
            var scope = new ManagementScope(ROOT_MANAGEMENT_SCOPE);

            var searcher = new ManagementObjectSearcher(scope, query);
            var adapterList = searcher.Get();

            foreach (var adapter in adapterList)
            {
                var name = adapter["Name"].ToString();

                if (name == deviceName)
                {
                    var managementObj = (ManagementObject)adapter;
                    managementObj.InvokeMethod("Enable", null);

                    return true;
                }
            }

            return false;
        }

        public List<string> getDeviceList()
        {
            var query = new ObjectQuery("SELECT * FROM Win32_PnPEntity");
            var scope = new ManagementScope(ROOT_MANAGEMENT_SCOPE);

            var searcher = new ManagementObjectSearcher(scope, query);

            List<string> adapterNames = new List<string>();

            foreach (ManagementObject adapterName in searcher.Get())
            {
                string? name = adapterName["Name"] as string;

                if (!string.IsNullOrEmpty(name))
                {
                    adapterNames.Add(name);
                }
            }

            return adapterNames;
        }

        public bool IsDeviceEnabled(string deviceName)
        {
            var query = new ObjectQuery("SELECT * FROM Win32_PnPEntity");
            var scope = new ManagementScope(ROOT_MANAGEMENT_SCOPE);

            var searcher = new ManagementObjectSearcher(scope, query);
            var adapterList = searcher.Get();

            foreach (ManagementObject adapter in adapterList)
            {
                var name = adapter["Name"].ToString();

                if (name == deviceName)
                {

                    var status = adapter["NetConnectionStatus"];

                    if ((UInt16)status == 2)
                    {
                        return true;
                    }

                    // We wont loop anymore further here.
                    return false;

                }
            }

            return false;
        }
    }
}
