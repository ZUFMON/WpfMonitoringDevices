using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MonitoringData.Annotations;

namespace MonitoringData
{
    public class DeviceMonitoringData : IMonitoringDeviceDataUi, IMonitoringDataCalculateCountingControl,INotifyPropertyChanged
    {
        public ObservableCollection<DeviceCounterData> DeviceCounterList { get; } = new ObservableCollection<DeviceCounterData>();

        
        public int SumOfAllMessage
        {
            get => _sumOfAllMessage;
            private set
            {
                _sumOfAllMessage = value;
                OnPropertyChanged();
            }
        }

        private object _locker = new object();
        private int _sumOfAllMessage = 0;

        public void CalculateIncommingMessagesCount(string name)
        {
            lock (_locker)
            {
                var actualDevice = DeviceCounterList.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                if (actualDevice == null)
                {
                    DeviceCounterList.Add(new DeviceCounterData() { Name = name, IncommingMessagesCount = 1, SendMessagesCount = 0 });
                }
                else
                {
                    actualDevice.IncommingMessagesCount++;
                }

                SumOfAllMessage++;
            }
        }

        public void CalculateOutComingMessagesCount(string name)
        {
            lock (_locker)
            {
                var actualDevice = DeviceCounterList.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                if (actualDevice == null)
                {
                    DeviceCounterList.Add(new DeviceCounterData() { Name = name, IncommingMessagesCount = 0, SendMessagesCount = 1 });
                }
                else
                {
                    actualDevice.SendMessagesCount++;
                }

                SumOfAllMessage++;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}