using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.Services;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using MyStore.Views;

namespace MyStore.ViewModels
{
    public class OrdersListViewModel : NotifyPropertyChanged
    {
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;

        IDataService DataService { get; }

        OrdersListWindow OrdersListWindow { get; }
        public ObservableCollection<Order>? Orders { get; set; }

        public OrdersListViewModel(IDataService dataService)
        {
            DataService = dataService;

            Orders = dataService.GetOrdersList();

            OrdersListWindow = new OrdersListWindow(this);
            OrdersListWindow.ShowDialog();
        }

        public RelayCommand AddCommand
        {
            get
            {
                return 
                  (addCommand = new RelayCommand((o) =>
                  {
                      Order vm = new();
                      if (new OrderViewModel(DataService, vm).OpenWindow())
                      {
                          DataService.AddOrder(vm);
                      };
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return 
                    (editCommand = new RelayCommand((selectedItem) =>
                    {
                        // получаем выделенный объект
                        if (selectedItem is not Order order) return;

                        Order vm = new()
                        {
                            Number = order.Number,
                            ProductName = order.ProductName
                        };

                        if (order.Employee != null)
                            vm.Employee = (Employee?)DataService.GetEmloyee(order.Employee.EmployeeId);

                        if (order.Tags != null)
                            vm.Tags = DataService.GetTagsForOrders(order.OrderId);

                        if (new OrderViewModel(DataService, vm).OpenWindow())
                        {
                            order.Number = vm.Number;
                            order.ProductName = vm.ProductName;

                            if (vm.Employee != null)
                                order.Employee = (Employee?)DataService.GetEmloyee(vm.Employee.EmployeeId);

                            if (vm.Tags != null)
                            {
                                if (order?.Tags?.Count > 0) 
                                    order.Tags.Clear();
                                order!.Tags = vm.Tags;
                            }

                            DataService.EditOrder(order);
                        }
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return 
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      // если ни одного объекта не выделено, выходим
                      if (selectedItem is not Order order) return;
                      DataService.DeleteOrder(order);
                  }));
            }
        }
    }
}
