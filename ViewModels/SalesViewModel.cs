using POSSEDQI.Views.Windows;
using POSSEDQI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace POSSEDQI.ViewModels
{
    public class SalesViewModel
    {
        public ICommand OpenAddCategoryCommand { get; }

        public SalesViewModel()
        {
            OpenAddCategoryCommand = new RelayCommand(OpenAddCategory);
        }

        private void OpenAddCategory(object parameter)
        {
            var addCategoryWindow = new AddCategoryWindow();
            addCategoryWindow.Owner = Application.Current.MainWindow;
            addCategoryWindow.ShowDialog();
        }
    }
}
