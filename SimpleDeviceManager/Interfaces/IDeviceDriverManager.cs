using System;
using System.Collections.Generic;

namespace SimpleDeviceManager.Interfaces
{
    public interface IDeviceDriverManager
    {
        List<string> GetServiceNames();
        void RegisterService(string serviceName, IDeviceDriver service);
        IDeviceDriver GetService(string serviceName);
    }
}
