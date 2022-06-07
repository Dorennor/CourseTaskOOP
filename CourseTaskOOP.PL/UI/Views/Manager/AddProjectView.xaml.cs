using System;
using System.Linq;
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

        BindComboBoxes();
    }

    private async void CreateProjectButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<ProjectModel> projectsService = new ProjectsService();

        await projectsService.CreateAsync(new ProjectModel
        {
            Deadline = (DateTime)ProjectDeadline.SelectedDate,
            Description = ProjectDescription.Text,
            Name = ProjectName.Text,
            OrderId = Int32.Parse(OrdersComboBox.SelectedItem.ToString().Split('|').First())
        });

        ProjectDeadline.SelectedDate = null;
        ProjectDescription.Text = "";
        ProjectName.Text = "";
        OrdersComboBox.SelectedItem = null;

        BindComboBoxes();
    }

    private async void CreateTeamButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<TeamModel> teamsService = new TeamsService();

        await teamsService.CreateAsync(new TeamModel
        {
            Name = TeamName.Text,
            Type = TypesComboBox.SelectedItem.ToString(),
            ProjectId = Int32.Parse(ProjectsComboBox.SelectedItem.ToString().Split('|').First())
        });

        TeamName.Text = "";
        TypesComboBox.SelectedItem = null;
        ProjectsComboBox.SelectedItem = null;

        BindComboBoxes();
    }

    private async void AddTeamLeaderButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<TeamMemberModel> teamMemberService = new TeamMembersService();

        await teamMemberService.CreateAsync(new TeamMemberModel
        {
            UserId = Int32.Parse(DevelopersComboBox.SelectedItem.ToString().Split('|').First()),
            TeamId = Int32.Parse(TeamComboBox.SelectedItem.ToString().Split('|').First()),
            Position = "TeamLeader"
        });

        DevelopersComboBox.SelectedItem = null;
        TeamComboBox.SelectedItem = null;

        BindComboBoxes();
    }

    private async void AddTeamMemberButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<TeamMemberModel> teamMemberService = new TeamMembersService();

        await teamMemberService.CreateAsync(new TeamMemberModel
        {
            UserId = Int32.Parse(TeamDevelopersComboBox.SelectedItem.ToString().Split('|').First()),
            TeamId = Int32.Parse(TeamsComboBox.SelectedItem.ToString().Split('|').First()),
            Position = "Member"
        });

        TeamDevelopersComboBox.SelectedItem = null;
        TeamsComboBox.SelectedItem = null;

        BindComboBoxes();
    }

    private void BindComboBoxes()
    {
        IService<OrderModel> orderService = new OrdersService();

        foreach (var order in orderService.GetAllAsync().Result)
        {
            OrdersComboBox.Items.Add($"{order.Id} | {order.Name} | {order.Deadline.ToShortDateString()} | {order.Type}");
        }

        IService<ProjectModel> projectService = new ProjectsService();

        foreach (var project in projectService.GetAllAsync().Result)
        {
            ProjectsComboBox.Items.Add($"{project.Id} | {project.Name} | {project.Deadline.ToShortDateString()} | {project.OrderId}");
        }

        IUsersService<UserModel> usersService = new UsersService();

        foreach (var developer in usersService.FindAsync(user => user.Role == "Developer").Result)
        {
            DevelopersComboBox.Items.Add($"{developer.Id} | {developer.UserName} | {developer.FullName} | {developer.Role}");
            TeamDevelopersComboBox.Items.Add($"{developer.Id} | {developer.UserName} | {developer.FullName} | {developer.Role}");
        }

        TypesComboBox.Items.Add("Web Development Team");
        TypesComboBox.Items.Add("Desktop Development Team");
        TypesComboBox.Items.Add("Security Development Team");
        TypesComboBox.Items.Add("Game Development Team");
        TypesComboBox.Items.Add("3D Development Team");
        TypesComboBox.Items.Add("Server Development Team");
        TypesComboBox.Items.Add("Testing Development Team");

        IService<TeamModel> teamsService = new TeamsService();

        foreach (var team in teamsService.GetAllAsync().Result)
        {
            TeamsComboBox.Items.Add($"{team.Id} | {team.Name} | {team.ProjectId} | {team.Type}");
            TeamComboBox.Items.Add($"{team.Id} | {team.Name} | {team.ProjectId} | {team.Type}");
        }
    }
}