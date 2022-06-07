using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;
using CourseTaskOOP.PL.Extensions;
using CourseTaskOOP.PL.Interfaces;
using CourseTaskOOP.PL.Services;

namespace CourseTaskOOP.PL.Windows;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private async void Login_OnClick(object sender, RoutedEventArgs e)
    {
        IUserManager userManagerService = new UserManagerService(new UsersService());
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        await userManagerService.LoginAsync(new UserModel
        {
            UserName = UserName.Text,
            PasswordHash = Password.Password.GeneratePasswordHash()
        });

        if (mainWindow != null)
        {
            mainWindow.ProcessCallBack();
        }

        Close();
    }

    public static string GeneratePasswordHash(string password)
    {
        using (var sha512 = SHA512.Create())
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashCode = sha512.ComputeHash(bytes);
            return BitConverter.ToString(hashCode);
        }
    }
}