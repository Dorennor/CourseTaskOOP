using CourseTaskOOP.BLL.Services;
using CourseTaskOOP.PL.Interfaces;
using CourseTaskOOP.PL.Services;
using CourseTaskOOP.PL.Windows;
using System.Windows;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;

namespace CourseTaskOOP.PL;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        IUserManager userManagerService = new UserManagerService(new UsersService());
        IService<TeamMemberModel> teamMembersService = new TeamMembersService();

        if (userManagerService.LoggedUser != null)
        {
            LoginButton.Visibility = Visibility.Collapsed;
            RegisterButton.Visibility = Visibility.Collapsed;
            LogoutButton.Visibility = Visibility.Visible;
            LoggedUser.Content = userManagerService.LoggedUser.UserName;

            if (userManagerService.LoggedUser.Role == "Administrator")
            {
                AddUserRadioButton.Visibility = Visibility.Visible;
                EditUserRadioButton.Visibility = Visibility.Visible;
                DeleteUserRadioButton.Visibility = Visibility.Visible;
            }
            if (teamMembersService.FindAsync(teamMember => teamMember.UserId == userManagerService.LoggedUser.Id && teamMember.Position == "TeamLeader").Result.Count > 0)
            {
                AddTaskRadioButton.Visibility = Visibility.Visible;
                DeleteTaskRadioButton.Visibility = Visibility.Visible;
            }
            if (userManagerService.LoggedUser.Role == "Manager")
            {
                AddProjectRadioButton.Visibility = Visibility.Visible;
                DeleteProjectRadioButton.Visibility = Visibility.Visible;
            }
            if (userManagerService.LoggedUser.Role == "Client")
            {
                AddOrderRadioButton.Visibility = Visibility.Visible;
                EditOrderRadioButton.Visibility = Visibility.Visible;
                DeleteOrderRadioButton.Visibility = Visibility.Visible;
            }
            if (userManagerService.LoggedUser.Role == "Developer")
            {
                GetTasksRadioButton.Visibility = Visibility.Visible;
                AddTaskRadioButton.Visibility = Visibility.Collapsed;
                DeleteTaskRadioButton.Visibility = Visibility.Collapsed;
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
        IService<TeamMemberModel> teamMembersService = new TeamMembersService();
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
            AddUserRadioButton.Visibility = Visibility.Visible;
            EditUserRadioButton.Visibility = Visibility.Visible;
            DeleteUserRadioButton.Visibility = Visibility.Visible;
        }
        if (teamMembersService.FindAsync(teamMember => teamMember.UserId == userManagerService.LoggedUser.Id && teamMember.Position == "TeamLeader").Result.Count > 0)
        {
            AddTaskRadioButton.Visibility = Visibility.Visible;
            DeleteTaskRadioButton.Visibility = Visibility.Visible;
        }
        if (userManagerService.LoggedUser.Role == "Manager")
        {
            AddProjectRadioButton.Visibility = Visibility.Visible;
            DeleteProjectRadioButton.Visibility = Visibility.Visible;
        }
        if (userManagerService.LoggedUser.Role == "Client")
        {
            AddOrderRadioButton.Visibility = Visibility.Visible;
            EditOrderRadioButton.Visibility = Visibility.Visible;
            DeleteOrderRadioButton.Visibility = Visibility.Visible;
        }
        if (userManagerService.LoggedUser.Role == "Developer")
        {
            GetTasksRadioButton.Visibility = Visibility.Visible;
            AddTaskRadioButton.Visibility = Visibility.Collapsed;
            DeleteTaskRadioButton.Visibility = Visibility.Collapsed;
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
            DeleteProjectRadioButton.Visibility = Visibility.Collapsed;
            AddTaskRadioButton.Visibility = Visibility.Collapsed;
            DeleteTaskRadioButton.Visibility = Visibility.Collapsed;
            GetTasksRadioButton.Visibility = Visibility.Collapsed;

            Start.Command.Execute(null);
        }
    }
}