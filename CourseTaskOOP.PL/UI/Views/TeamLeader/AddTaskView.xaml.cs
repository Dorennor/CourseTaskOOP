using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseTaskOOP.PL.UI.Views.TeamLeader;

public partial class AddTaskView : UserControl
{
    public AddTaskView()
    {
        InitializeComponent();
    }

    private async void AddTaskButton_OnClick(object sender, RoutedEventArgs e)
    {
        IService<WorkTaskModel> taskServices = new WorkTasksService();

        await taskServices.CreateAsync(new WorkTaskModel
        {
            Name = Name.Text,
            Description = Description.Text,
            HoursToComplete = Int32.Parse(HoursToComplete.Text)
        });

        Name.Text = "";
        Description.Text = "";
        HoursToComplete.Text = "";
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}