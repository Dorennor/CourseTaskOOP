using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;

namespace CourseTaskOOP.PL.UI.Views.TeamLeader;

public partial class DeleteTaskView : UserControl
{
    public DeleteTaskView()
    {
        InitializeComponent();

        IService<WorkTaskModel> tasksService = new WorkTasksService();

        foreach (var task in tasksService.GetAllAsync().Result)
        {
            TasksComboBox.Items.Add($"{task.Id} | {task.Name} | {task.Description} | {task.HoursToComplete}");
        }
    }

    private async void DeleteTaskButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<WorkTaskModel> tasksService = new WorkTasksService();

        await tasksService.DeleteAsync(new WorkTaskModel
        {
            Id = Int32.Parse(TasksComboBox.SelectedItem.ToString().Split('|').First())
        });

        TasksComboBox.SelectedItem = null;

        foreach (var task in tasksService.GetAllAsync().Result)
        {
            TasksComboBox.Items.Add($"{task.Id} | {task.Name} | {task.Description} | {task.HoursToComplete}");
        }
    }
}