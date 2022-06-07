using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseTaskOOP.PL.UI.Views.Client;

public partial class AddOrderView : UserControl
{
    public AddOrderView()
    {
        InitializeComponent();

        TypesComboBox.Items.Add("Web Project");
        TypesComboBox.Items.Add("Desktop Project");
        TypesComboBox.Items.Add("Security Project");
        TypesComboBox.Items.Add("Game Project");
        TypesComboBox.Items.Add("3D Project");
        TypesComboBox.Items.Add("Server Project");
        TypesComboBox.Items.Add("Testing Project");
    }

    private async void AddOrderButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<OrderModel> orderService = new OrdersService();

        await orderService.CreateAsync(new OrderModel
        {
            Name = Name.Text,
            OrderDate = DateTime.Now,
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
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}