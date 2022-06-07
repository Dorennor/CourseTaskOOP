using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;
using CourseTaskOOP.PL.Interfaces;
using CourseTaskOOP.PL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System.Windows;

namespace CourseTaskOOP.PL;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder().ConfigureServices(ConfigureServices).Build();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Debug()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .WriteTo.File("logs/log.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IUsersService<UserModel>, UsersService>();
        services.AddScoped<IService<OrderModel>, OrdersService>();
        services.AddScoped<IService<ProjectModel>, ProjectsService>();
        services.AddScoped<IService<TeamMemberModel>, TeamMembersService>();
        services.AddScoped<IService<TeamModel>, TeamsService>();
        services.AddScoped<IService<WorkTaskModel>, WorkTasksService>();
        services.AddScoped<IUserManager, UserManagerService>();
        services.AddSingleton<MainWindow>();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync();
        }

        base.OnExit(e);
    }
}