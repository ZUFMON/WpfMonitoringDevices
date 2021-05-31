using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MonitoringData.Annotations;

namespace MonitoringData
{
    /// <summary> Devices counter data for Calulation receive and sending message </summary>
    public class DeviceCounterData : INotifyPropertyChanged
    {
        private int _incommingMessagesCount;
        private int _sendMessagesCount;
        public string Name { get; internal set; }

        public int IncommingMessagesCount
        {
            get => _incommingMessagesCount;
            internal set
            {
                _incommingMessagesCount = value;
                OnPropertyChanged();
            }
        }

        public int SendMessagesCount
        {
            get => _sendMessagesCount;
            internal set
            {
                _sendMessagesCount = value;
                OnPropertyChanged();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is DeviceCounterData deviceData)
            {
                return deviceData.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}