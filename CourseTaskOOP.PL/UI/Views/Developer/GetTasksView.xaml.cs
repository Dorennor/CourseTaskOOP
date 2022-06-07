using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.BLL.Services;
using System.Windows.Controls;

namespace CourseTaskOOP.PL.UI.Views.Developer;

public partial class GetTasksView : UserControl
{
    public GetTasksView()
    {
        InitializeComponent();

        IService<WorkTaskModel> tasksService = new WorkTasksService();

        TasksDataGrid.ItemsSource = tasksService.GetAllAsync().Result;
    }
}