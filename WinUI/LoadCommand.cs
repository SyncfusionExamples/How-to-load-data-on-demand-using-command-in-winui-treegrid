using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI_TreeGrid
{
    class LoadCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainPage page;
        public bool CanExecute(object parameter)
        {
            TreeNode node = (parameter as TreeNode);
            EmployeeInfo emp = node.Item as EmployeeInfo;
            if (emp != null)
                if (emp.ReportsTo == -1 || emp.ReportsTo == 34 || emp.ReportsTo == 36 || emp.ReportsTo == 65)
                    return true;
            return false;
        }

        public void Execute(object parameter)
        {
            TreeNode node = (parameter as TreeNode);
            page = new MainPage();
            EmployeeInfo emp = node.Item as EmployeeInfo;
            if (emp != null)
            {
                node.PopulateChildNodes((page.DataContext as ViewModel).GetReportees(emp.ID));
            }
        }

        event EventHandler<object> ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
    }
}
