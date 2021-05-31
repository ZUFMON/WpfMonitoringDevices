using System.Collections.Generic;
using AbstractBase;
using Microsoft.Extensions.DependencyInjection;
using MonitoringDevices.Devices;

namespace MonitoringDevices
{
    public static class Extension
    {
        public static void AddMonitoringDevices(this IServiceCollection service)
        {
            service.AddSingleton<DeviceLight>();
            service.AddSingleton<IProcessingMonitoringDevice>(x => x.GetService<DeviceLight>());
            service.AddSingleton<IMonitoringDevicesBase>(x => x.GetService<DeviceLight>());

            service.AddSingleton<DeviceEngine>();
            service.AddSingleton<IProcessingMonitoringDevice>(x => x.GetService<DeviceEngine>());
            service.AddSingleton<IMonitoringDevicesBase>(x => x.GetService<DeviceEngine>());

            service.AddSingleton<DeviceAlien>();
            service.AddSingleton<IProcessingMonitoringDevice>(x => x.GetService<DeviceAlien>());
            service.AddSingleton<IMonitoringDevicesBase>(x => x.GetService<DeviceAlien>());


            service.AddSingleton<AnotherAlien>();
            service.AddSingleton<IProcessingMonitoringDevice>(x => x.GetService<AnotherAlien>());
            service.AddSingleton<IMonitoringDevicesBase>(x => x.GetService<AnotherAlien>());
            
        }
    }
}
