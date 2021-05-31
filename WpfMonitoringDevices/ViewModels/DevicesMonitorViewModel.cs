using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AbstractBase;
using Microsoft.Extensions.DependencyInjection;
using MonitoringData;
using MonitoringData.Annotations;
using WpfMonitoringDevices.Components;

namespace WpfMonitoringDevices.ViewModels
{
    public class DevicesMonitorViewModel
    {
        public IMonitoringDeviceDataUi MonitoringDeviceDataUi { get; }

        public DevicesMonitorViewModel(IMonitoringDeviceDataUi monitoringDeviceDataUi)
        {
            MonitoringDeviceDataUi = monitoringDeviceDataUi;
        }
    }
}
