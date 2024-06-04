using Cognex.DataMan.SDK;
using Cognex.DataMan.SDK.Discovery;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Dataman
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<EthSystemDiscoverer.SystemInfo> _ethDevices;
        private EthSystemDiscoverer _ethSystemDiscoverer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeEthSystemDiscoverer();
        }

        private void InitializeEthSystemDiscoverer()
        {
            _ethDevices = new ObservableCollection<EthSystemDiscoverer.SystemInfo>();
            ethDevicesListBox.ItemsSource = _ethDevices;

            _ethSystemDiscoverer = new EthSystemDiscoverer();
            _ethSystemDiscoverer.SystemDiscovered += OnEthSystemDiscovered;
        }

        private async void OnEthSystemDiscovered(EthSystemDiscoverer.SystemInfo systemInfo)
        {
            await Dispatcher.InvokeAsync(() => _ethDevices.Add(systemInfo));
        }

        private async void DiscoverEthDevicesButton_Click(object sender, RoutedEventArgs e)
        {
            _ethDevices.Clear();
            await DiscoverEthDevicesAsync();
        }

        private async Task DiscoverEthDevicesAsync()
        {
            await Task.Run(() => _ethSystemDiscoverer.Discover())
                .ContinueWith(task =>
                {
                    if (_ethDevices.Count == 0)
                    {
                        MessageBox.Show("Không có thiết bị Ethernet được phát hiện.");
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
