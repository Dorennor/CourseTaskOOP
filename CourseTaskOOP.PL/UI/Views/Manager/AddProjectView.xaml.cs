using System;
using System.Windows;
using System.Windows.Controls;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;

namespace CourseTaskOOP.PL.UI.Views.Manager;

public partial class AddProjectView : UserControl
{
    public AddProjectView()
    {
        InitializeComponent();

        IService<OrderModel> orderService = new OrdersService();

        foreach (var order in orderService.GetAllAsync().Result)
        {
            OrdersComboBox.Items.Add($"{order.Id} | {order.Name} | {order.Deadline.Date} | {order.Type}");
        }
    }

    private void CreateProjectButton_OnClick(object sender, RoutedEventArgs e)
    {
        
    }

    private void CreateTeamButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddTeamLeaderButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddTeamMemberButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}