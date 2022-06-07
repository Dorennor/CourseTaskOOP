using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;
using CourseTaskOOP.PL.Extensions;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseTaskOOP.PL.UI.Views.Administrator;

public partial class EditUserView : UserControl
{
    public EditUserView()
    {
        InitializeComponent();

        RolesComboBox.Items.Add("Administrator");
        RolesComboBox.Items.Add("Developer");
        RolesComboBox.Items.Add("Manager");
        RolesComboBox.Items.Add("Client");

        IUsersService<UserModel> usersService = new UsersService();

        foreach (var user in usersService.GetAllAsync().Result)
        {
            UsersComboBox.Items.Add($"{user.Id} | {user.UserName} | {user.FullName} | {user.Role}");
        }
    }

    private async void EditUserButton_OnClick(object sender, RoutedEventArgs e)
    {
        IUsersService<UserModel> usersService = new UsersService();

        await usersService.UpdateAsync(new UserModel
        {
            Id = Int32.Parse(UsersComboBox.SelectedItem.ToString().Split('|').First()),
            FullName = FullName.Text,
            UserName = UserName.Text,
            PasswordHash = Password.Password.GeneratePasswordHash(),
            IsLogged = false,
            Role = RolesComboBox.SelectedItem.ToString()
        });

        UserName.Text = "";
        FullName.Text = "";
        Password.Password = "";
        RolesComboBox.SelectedItem = null;
        UsersComboBox.SelectedItem = null;

        RolesComboBox.Items.Add("Administrator");
        RolesComboBox.Items.Add("Developer");
        RolesComboBox.Items.Add("Manager");
        RolesComboBox.Items.Add("Client");

        foreach (var user in usersService.GetAllAsync().Result)
        {
            UsersComboBox.Items.Add($"{user.Id} | {user.UserName} | {user.FullName} | {user.Role}");
        }
    }
}