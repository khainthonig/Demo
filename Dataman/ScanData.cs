using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataman
{
    public class ScanData : INotifyPropertyChanged
    {
        private string _scannedBarcode;
        public string ScannedBarcode
        {
            get { return _scannedBarcode; }
            set
            {
                _scannedBarcode = value;
                OnPropertyChanged("ScannedBarcode");
            }
        }

        private string _scanDate;
        public string ScanDate
        {
            get { return _scanDate; }
            set
            {
                _scanDate = value;
                OnPropertyChanged("ScanDate");
            }
        }

        private string _barcodeType;
        public string BarcodeType
        {
            get { return _barcodeType; }
            set
            {
                _barcodeType = value;
                OnPropertyChanged("BarcodeType");
            }
        }

        private string _scanTime;
        public string ScanTime
        {
            get { return _scanTime; }
            set
            {
                _scanTime = value;
                OnPropertyChanged("ScanTime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
