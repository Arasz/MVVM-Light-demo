using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace App1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private ObservableCollection<string> _items = null;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            CreateClearDataCommand();
            CreateLoadDataCommand();
            CreateAddDataCommand();

            _items = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                Set(nameof(Items), ref _items, value); 
            }
        }

        public ICommand LoadDataCommand { get; private set; }

        private void CreateLoadDataCommand() => LoadDataCommand = new RelayCommand(LoadData, CanExecuteLoadDataCommand);

        private bool CanExecuteLoadDataCommand() => _items.Count == 0;

        private void LoadData()
        {
            var range = Enumerable.Range(1, 10);
            foreach (var item in range)
            {
                _items.Add($"Element {item}");
            }
        }

        public ICommand ClearDataCommand { get; private set; }

        private void CreateClearDataCommand() => ClearDataCommand = new RelayCommand(ClearData);

        private void ClearData()
        {
            _items.Clear();
        }

        public ICommand AddDataCommand { get; private set; }

        private void CreateAddDataCommand() => AddDataCommand = new RelayCommand<string>(AddData);

        private void AddData(string data)
        {
            _items.Add(data);
            RaisePropertyChanged(nameof(Items));
        }

    }
}