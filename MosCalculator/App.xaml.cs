using Company;
using CompanyInterface;
using ExcelInterface;
using InteropExcelWrapperInterface;
using MosCalculator.Models;
using MosCalculator.ViewModels;
using MosCalculator.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using ValueSet;
using ValueSetInterface;
using WebInterface;

namespace MosCalculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            //container.RegisterType<MainWindow>();
            container.RegisterType<IMainWindowViewModel, MainWindowViewModel>();
            container.RegisterType<IMainWindowModel, MainWindowModel>();
            //container.RegisterType<ICompany, Company.Company>();
            //container.RegisterType<IWeb, Web.Web>();
            //container.RegisterType<IExcel, Excel.Excel>();
            //container.RegisterType<IInteropExcelWrapper, InteropExcelWrapper.InteropExcelWrapper>();
            //container.RegisterType<IValueSet, ValueSet.ValueSet>();

            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}
