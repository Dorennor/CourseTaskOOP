using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;
using CourseTaskOOP.PL.Extensions;
using CourseTaskOOP.PL.Services;
using System.Windows;
using System.Windows.Controls;

namespace CourseTaskOOP.PL.UI.Views.Administrator;

public partial class AddUserView : UserControl
{
    public AddUserView()
    {
        InitializeComponent();

        RolesComboBox.Items.Add("Administrator");
        RolesComboBox.Items.Add("Developer");
        RolesComboBox.Items.Add("Manager");
        RolesComboBox.Items.Add("Client");
    }

    private async void AddUserButton_OnClick(object sender, RoutedEventArgs e)
    {
        UserManagerService userManagerService = new UserManagerService(new UsersService());

        await userManagerService.RegisterAsync(new UserModel
        {
            UserName = UserName.Text,
            PasswordHash = Password.Password.GeneratePasswordHash(),
            FullName = FullName.Text,
            IsLogged = false,
            Role = RolesComboBox.SelectedItem.ToString()
        });

        UserName.Text = "";
        FullName.Text = "";
        Password.Password = "";
        RolesComboBox.SelectedItem = null;
    }
}