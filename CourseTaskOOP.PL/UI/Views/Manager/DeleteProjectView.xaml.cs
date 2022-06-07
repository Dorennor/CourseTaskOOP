using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseTaskOOP.PL.UI.Views.Manager;

public partial class DeleteProject : UserControl
{
    public DeleteProject()
    {
        InitializeComponent();

        BindComboBoxes();
    }

    private async void DeleteTeamMemberButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<TeamMemberModel> teamMembersService = new TeamMembersService();

        await teamMembersService.DeleteAsync(new TeamMemberModel
        {
            Id = Int32.Parse(TeamMembersComboBox.SelectedItem.ToString().Split('|').First())
        });

        TeamMembersComboBox.SelectedItem = null;

        BindComboBoxes();
    }

    private async void DeleteTeamLeaderButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<TeamMemberModel> teamMembersService = new TeamMembersService();

        await teamMembersService.DeleteAsync(new TeamMemberModel
        {
            Id = Int32.Parse(TeamLeadersComboBox.SelectedItem.ToString().Split('|').First())
        });

        TeamLeadersComboBox.SelectedItem = null;

        BindComboBoxes();
    }

    private async void DeleteTeamButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<TeamModel> teamsService = new TeamsService();

        await teamsService.DeleteAsync(new TeamModel
        {
            Id = Int32.Parse(TeamsComboBox.SelectedItem.ToString().Split('|').First())
        });

        TeamsComboBox.SelectedItem = null;

        BindComboBoxes();
    }

    private async void DeleteProjectButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<ProjectModel> projectsService = new ProjectsService();

        await projectsService.DeleteAsync(new ProjectModel
        {
            Id = Int32.Parse(ProjectsComboBox.SelectedItem.ToString().Split('|').First())
        });

        ProjectsComboBox.SelectedItem = null;

        BindComboBoxes();
    }

    private void BindComboBoxes()
    {
        IService<ProjectModel> projectsService = new ProjectsService();

        foreach (var project in projectsService.GetAllAsync().Result)
        {
            ProjectsComboBox.Items.Add($"{project.Id} | {project.Name} | {project.Deadline.ToShortDateString()} | {project.OrderId}");
        }

        IService<TeamModel> teamsService = new TeamsService();

        foreach (var team in teamsService.GetAllAsync().Result)
        {
            TeamsComboBox.Items.Add($"{team.Id} | {team.Name} | {team.ProjectId} | {team.Type}");
        }

        IService<TeamMemberModel> teamMembersService = new TeamMembersService();

        foreach (var teamMember in teamMembersService.FindAsync(teamMember => teamMember.Position == "TeamLeader").Result)
        {
            TeamLeadersComboBox.Items.Add($"{teamMember.Id} | {teamMember.UserId} | {teamMember.TeamId} | {teamMember.Position}");
        }

        foreach (var teamMember in teamMembersService.FindAsync(teamMember => teamMember.Position == "Member").Result)
        {
            TeamMembersComboBox.Items.Add($"{teamMember.Id} | {teamMember.UserId} | {teamMember.TeamId} | {teamMember.Position}");
        }
    }
}