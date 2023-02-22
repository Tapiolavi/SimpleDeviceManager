using SimpleDeviceManager.Interfaces;
using System;
using System.Collections.Generic;

namespace SimpleDeviceManager
{
    public class DeviceManager : IDeviceDriverManager
    {
        private readonly Dictionary<string, IDeviceDriver> drivers;

        public DeviceManager()
        {
            this.drivers = new Dictionary<string, IDeviceDriver>();
        }

        public List<string> GetServiceNames()
        {
            return new List<string>(this.drivers.Keys);
        }

        public void RegisterService(string driverName, IDeviceDriver driver)
        {
            this.drivers[driverName] = driver;
        }

        public IDeviceDriver GetService(string driverName)
        {
            if (!drivers.TryGetValue(driverName, out var service))
            {
                throw new ArgumentException($"Unknown service name: {driverName}");
            }

            return service;
        }
    }
}
