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

public partial class EditOrderView : UserControl
{
    public EditOrderView()
    {
        InitializeComponent();

        TypesComboBox.Items.Add("Web Project");
        TypesComboBox.Items.Add("Desktop Project");
        TypesComboBox.Items.Add("Security Project");
        TypesComboBox.Items.Add("Game Project");
        TypesComboBox.Items.Add("3D Project");
        TypesComboBox.Items.Add("Server Project");
        TypesComboBox.Items.Add("Testing Project");

        IService<OrderModel> ordersService = new OrdersService();

        foreach (var order in ordersService.GetAllAsync().Result)
        {
            OrdersComboBox.Items.Add($"{order.Id} | {order.Name} | {order.Deadline.Date} | {order.Type}");
        }
    }

    private void EditOrderButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<OrderModel> orderService = new OrdersService();

        orderService.UpdateAsync(new OrderModel
        {
            Id = Int32.Parse(OrdersComboBox.SelectedItem.ToString().Split('|').First()),
            Name = Name.Text,
            Deadline = (DateTime)Deadline.SelectedDate,
            Description = Description.Text,
            Price = Int32.Parse(Price.Text),
            Type = TypesComboBox.SelectedItem.ToString()
        });

        Name.Text = "";
        Deadline.SelectedDate = null;
        Description.Text = "";
        Price.Text = "";
        TypesComboBox.SelectedItem = null;
        OrdersComboBox.SelectedItem = null;
    }

    public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}