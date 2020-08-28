using CompanyInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosCalculator.Models
{
    public interface IMainWindowModel
    {
        ObservableCollection<ICompany> ListOfCompanies { get; set; }
    }
}
