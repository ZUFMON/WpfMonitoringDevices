using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringData
{
    public static class Extension
    {
        public static void AddMonitoringData(this IServiceCollection service)
        {
            service.AddSingleton(new DeviceMonitoringData());
            service.AddSingleton<IMonitoringDeviceDataUi>(x => x.GetService<DeviceMonitoringData>());
            service.AddSingleton<IMonitoringDataCalculateCountingControl>(x => x.GetService<DeviceMonitoringData>());
        }
    }
}
