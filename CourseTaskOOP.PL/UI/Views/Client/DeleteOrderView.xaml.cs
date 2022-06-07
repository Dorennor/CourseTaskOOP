using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseTaskOOP.PL.UI.Views.Client;

public partial class DeleteOrderView : UserControl
{
    public DeleteOrderView()
    {
        InitializeComponent();

        IService<OrderModel> ordersService = new OrdersService();

        foreach (var order in ordersService.GetAllAsync().Result)
        {
            OrdersComboBox.Items.Add($"{order.Id} | {order.Name} | {order.Deadline.Date} | {order.Type}");
        }
    }

    private void DeleteOrderButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<OrderModel> orderService = new OrdersService();

        orderService.DeleteAsync(new OrderModel
        {
            Id = Int32.Parse(OrdersComboBox.SelectedItem.ToString().Split('|').First())
        });

        OrdersComboBox.SelectedItem = null;
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}