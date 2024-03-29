﻿# Simple device manager

POC to fast prototyping to disable and enable devices.

## Available drivers to handle devices 

- DeviceDriverNetshService (uses netsh.exe)
- DeviceDriverrWmiService (uses Windows Management Instrumentation Win32_NetworkAdapter in quering)
- DeviceDriverSystemDeviceManager (uses Windows Management Instrumentation Win32_PnPEntity in quering)


## Usage

### Initialize 

```code
private INetworkDriverServiceManager deviceManager;

deviceManager = new DeviceDriverServiceManager();

deviceManager.RegisterService("Network Wmi Driver", new DeviceDriverrWmiService());
deviceManager.RegisterService("Network Nets Driver", new DeviceDriverNetshService());
deviceManager.RegisterService("System Device management Driver", new DeviceDriverSystemDeviceManagerService());
```

### Get available services 

```code
private INetworkDriverServiceManager deviceManager;

deviceManager.GetServiceNames();
```


### Get service 

```code
private INetworkDriverServiceManager deviceManager;

deviceManager.GetServiceNames();

deviceManager.GetService("Network Wmi Driver");

```

### List devices

Returns list of devicenames available

```code
private INetworkDriverServiceManager deviceManager;

deviceManager.GetServiceNames();

deviceManager.GetService("Network Wmi Driver").getDeviceList();


```

### Enable device

```code
private INetworkDriverServiceManager deviceManager;

deviceManager.GetServiceNames();

deviceManager.GetService("Network Wmi Driver").EnableDevice('Media teck wifi 6g etc');

```


### Check if devise is enabled

```code
private INetworkDriverServiceManager deviceManager;

deviceManager.GetServiceNames();

deviceManager.GetService("Network Wmi Driver").IsDeviceEnabled('Media teck wifi 6g etc');

```

