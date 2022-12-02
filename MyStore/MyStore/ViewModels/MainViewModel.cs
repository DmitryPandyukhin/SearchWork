using System;
using System.Linq;
using MyStore.Models;
using MyStore.Services;
using MyStore.Views;

namespace MyStore.ViewModels
{
    public class MainViewModel
    {

        IDataService DataService { get; }

        RelayCommand? openOrdersCommand;
        RelayCommand? openEmployeesCommand;
        RelayCommand? openDepartamentsCommand;

        public MainViewModel()
        {
            DataService = new DataService();
        }

        public RelayCommand OpenOrdersCommand
        {
            get
            {
                return
                  (openOrdersCommand = new RelayCommand((o) =>
                  {
                      _ = new OrdersListViewModel(DataService);
                  }));
            }
        }
        public RelayCommand OpenEmployeesCommand
        {
            get
            {
                return
                  (openEmployeesCommand = new RelayCommand((o) =>
                  {
                      _ = new EmployeesListViewModel(DataService);
                  }));
            }
        }

        public RelayCommand OpenDepartamentsCommand
        {
            get
            {
                return
                  (openDepartamentsCommand = new RelayCommand((o) =>
                  {
                      _ = new DepartamentsListViewModel(DataService);
                  }));
            }
        }

        
    }
}
