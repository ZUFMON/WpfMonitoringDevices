using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringData
{

    /// <summary>  List of all Devices with Calculate messages </summary>
    public interface IMonitoringDeviceDataUi: INotifyPropertyChanged
    {
        ObservableCollection<DeviceCounterData> DeviceCounterList { get; }
        int SumOfAllMessage { get; }
    }
}
