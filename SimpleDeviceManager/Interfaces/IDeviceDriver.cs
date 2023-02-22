using System;
using System.Collections.Generic;

namespace SimpleDeviceManager.Interfaces
{
    public interface IDeviceDriver
    {
        bool DisableDevice(string deviceName);
        bool EnableDevice(string deviceName);
        List<string> getDeviceList();
        bool IsDeviceEnabled(string deviceName);
    }
}
