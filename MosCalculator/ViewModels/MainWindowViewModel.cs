using Company;
using CompanyInterface;
using ExcelInterface;
using MosCalculator.Base;
using MosCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MosCalculator.ViewModels
{
    public class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        private readonly IMainWindowModel _mainWindowModel;
        private readonly IExcel _excel;

        public ICommand CheckButtonCommand { get; set; }

        public MainWindowViewModel(IMainWindowModel mainWindowModel/*, IExcel excel*/)
        {
            _mainWindowModel = mainWindowModel;
            //_excel = excel;
            CheckButtonCommand = new RelayCommand(OnCheckButtonCommand);
        }

        private void OnCheckButtonCommand(object param)
        {
            _excel.CheckIfDownloaded();

            if (_excel.IsDownloaded)
            {
                if (MessageBox.Show("The spreadsheet is already downloaded", "Would you like to replace the file?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _excel.DeleteExisting();
                    _excel.DownloadUrl("https://www.asx.com.au/asx/research/ASXListedCompanies.csv");
                }

                _excel.LoadRange(4, 1);
            }
        }

        public ObservableCollection<ICompany> ListOfCompanies
        {
            get { return _mainWindowModel.ListOfCompanies; }
            set
            {
                _mainWindowModel.ListOfCompanies = value;
                NotifyPropertyChanged("ListOfCompanies");
            }
        }
    }
}
