using CourseTaskOOP.BLL.Services;
using CourseTaskOOP.PL.Interfaces;
using CourseTaskOOP.PL.Services;
using CourseTaskOOP.PL.Windows;
using System.Windows;
using CourseTaskOOP.PL.UI.ViewModels;

namespace CourseTaskOOP.PL;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        IUserManager userManagerService = new UserManagerService(new UsersService());

        if (userManagerService.LoggedUser != null)
        {
            LoginButton.Visibility = Visibility.Collapsed;
            RegisterButton.Visibility = Visibility.Collapsed;
            LogoutButton.Visibility = Visibility.Visible;
            LoggedUser.Content = userManagerService.LoggedUser.UserName;

            if (userManagerService.LoggedUser.Role == "Administrator")
            {
                ContentControl.Visibility = Visibility.Visible;
                AddUserRadioButton.Visibility = Visibility.Visible;
                EditUserRadioButton.Visibility = Visibility.Visible;
                DeleteUserRadioButton.Visibility = Visibility.Visible;
            }
            if (userManagerService.LoggedUser.Role == "TeamLeader")
            {
                ContentControl.Visibility = Visibility.Visible;
            }
            if (userManagerService.LoggedUser.Role == "Manager")
            {
                ContentControl.Visibility = Visibility.Visible;
                AddProjectRadioButton.Visibility = Visibility.Visible;
            }
            if (userManagerService.LoggedUser.Role == "Client")
            {
                ContentControl.Visibility = Visibility.Visible;
                AddOrderRadioButton.Visibility = Visibility.Visible;
                EditOrderRadioButton.Visibility = Visibility.Visible;
                DeleteOrderRadioButton.Visibility = Visibility.Visible;
            }
        }
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
    }

    public void ProcessCallBack()
    {
        IUserManager userManagerService = new UserManagerService(new UsersService());

        if (userManagerService.LoggedUser == null)
        {
            MessageBox.Show("Wrong password or login!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        LoginButton.Visibility = Visibility.Collapsed;
        RegisterButton.Visibility = Visibility.Collapsed;
        LogoutButton.Visibility = Visibility.Visible;
        LoggedUser.Content = userManagerService.LoggedUser.UserName;

        if (userManagerService.LoggedUser.Role == "Administrator")
        {
            ContentControl.Visibility = Visibility.Visible;
            AddUserRadioButton.Visibility = Visibility.Visible;
            EditUserRadioButton.Visibility = Visibility.Visible;
            DeleteUserRadioButton.Visibility = Visibility.Visible;
        }
        if (userManagerService.LoggedUser.Role == "TeamLeader")
        {
            ContentControl.Visibility = Visibility.Visible;
        }
        if (userManagerService.LoggedUser.Role == "Manager")
        {
            ContentControl.Visibility = Visibility.Visible;
            AddProjectRadioButton.Visibility = Visibility.Visible;
        }
        if (userManagerService.LoggedUser.Role == "Client")
        {
            ContentControl.Visibility = Visibility.Visible;
            AddOrderRadioButton.Visibility = Visibility.Visible;
            EditOrderRadioButton.Visibility = Visibility.Visible;
            DeleteOrderRadioButton.Visibility = Visibility.Visible;
        }
    }

    private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
    {
        RegisterWindow registerWindow = new RegisterWindow();
        registerWindow.Show();
    }

    private async void LogoutButton_OnClick(object sender, RoutedEventArgs e)
    {
        IUserManager userManagerService = new UserManagerService(new UsersService());
        await userManagerService.LogoutAsync();
        if (userManagerService.LoggedUser == null)
        {
            LoginButton.Visibility = Visibility.Visible;
            RegisterButton.Visibility = Visibility.Visible;
            LogoutButton.Visibility = Visibility.Collapsed;
            LoggedUser.Content = "";
            AddUserRadioButton.Visibility = Visibility.Collapsed;
            EditUserRadioButton.Visibility = Visibility.Collapsed;
            DeleteUserRadioButton.Visibility = Visibility.Collapsed;
            AddOrderRadioButton.Visibility = Visibility.Collapsed;
            EditOrderRadioButton.Visibility = Visibility.Collapsed;
            DeleteOrderRadioButton.Visibility = Visibility.Collapsed;
            AddProjectRadioButton.Visibility = Visibility.Collapsed;
            ContentControl.Visibility = Visibility.Collapsed;
            Start.Command.Execute(null);
        }
    }
}