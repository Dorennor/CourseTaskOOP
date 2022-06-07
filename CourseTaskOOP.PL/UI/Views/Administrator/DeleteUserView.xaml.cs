using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;

namespace CourseTaskOOP.PL.UI.Views.Administrator;


public partial class DeleteUserView : UserControl
{
    public DeleteUserView()
    {
        InitializeComponent();

        IUsersService<UserModel> usersService = new UsersService();

        foreach (var user in usersService.GetAllAsync().Result)
        {
            UsersComboBox.Items.Add($"{user.Id} | {user.UserName} | {user.FullName} | {user.Role}");
        }
    }

    private async void DeleteUserButton_OnClick(object sender, RoutedEventArgs e)
    {
        IUsersService<UserModel> usersService = new UsersService();

        await usersService.DeleteAsync(new UserModel
        {
            Id = Int32.Parse(UsersComboBox.SelectedItem.ToString().Split('|').First())
        });

        UsersComboBox.SelectedItem = null;
    }
}