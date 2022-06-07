using CourseTaskOOP.PL.UI.Core;
using CourseTaskOOP.PL.UI.ViewModels.Administrator;
using CourseTaskOOP.PL.UI.ViewModels.Client;
using CourseTaskOOP.PL.UI.ViewModels.Developer;
using CourseTaskOOP.PL.UI.ViewModels.Manager;
using CourseTaskOOP.PL.UI.ViewModels.TeamLeader;

namespace CourseTaskOOP.PL.UI.ViewModels;

public class MainViewModel : ObservableObject
{
    public RelayCommand AddUserViewCommand { get; set; }
    public RelayCommand EditUserViewCommand { get; set; }
    public RelayCommand DeleteUserViewCommand { get; set; }

    public RelayCommand AddOrderViewCommand { get; set; }
    public RelayCommand EditOrderViewCommand { get; set; }
    public RelayCommand DeleteOrderViewCommand { get; set; }

    public RelayCommand AddProjectViewCommand { get; set; }

    public RelayCommand DeleteProjectViewCommand { get; set; }

    public RelayCommand AddTaskViewCommand { get; set; }

    public RelayCommand DeleteTaskViewCommand { get; set; }

    public RelayCommand StartViewCommand { get; set; }

    public RelayCommand GetTasksViewCommand { get; set; }

    public AddUserViewModel AddUserViewModel { get; set; }
    public EditUserViewModel EditUserViewModel { get; set; }
    public DeleteUserViewModel DeleteUserViewModel { get; set; }

    public AddOrderViewModel AddOrderViewModel { get; set; }
    public EditOrderViewModel EditOrderViewModel { get; set; }
    public DeleteOrderViewModel DeleteOrderViewModel { get; set; }

    public AddProjectViewModel AddProjectViewModel { get; set; }

    public DeleteProjectViewModel DeleteProjectViewModel { get; set; }

    public AddTaskViewModel AddTaskViewModel { get; set; }
    public DeleteTaskViewModel DeleteTaskViewModel { get; set; }

    public StartViewModel StartViewModel { get; set; }

    public GetTasksViewModel GetTasksViewModel { get; set; }

    private object _currentView;

    public object CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        AddUserViewModel = new AddUserViewModel();
        EditUserViewModel = new EditUserViewModel();
        DeleteUserViewModel = new DeleteUserViewModel();
        AddOrderViewModel = new AddOrderViewModel();
        EditOrderViewModel = new EditOrderViewModel();
        DeleteOrderViewModel = new DeleteOrderViewModel();
        AddProjectViewModel = new AddProjectViewModel();
        DeleteProjectViewModel = new DeleteProjectViewModel();
        AddTaskViewModel = new AddTaskViewModel();
        DeleteTaskViewModel = new DeleteTaskViewModel();
        StartViewModel = new StartViewModel();
        GetTasksViewModel = new GetTasksViewModel();

        AddUserViewCommand = new RelayCommand(o =>
        {
            CurrentView = AddUserViewModel;
        });
        EditUserViewCommand = new RelayCommand(o =>
        {
            CurrentView = EditUserViewModel;
        });
        DeleteUserViewCommand = new RelayCommand(o =>
        {
            CurrentView = DeleteUserViewModel;
        });

        AddOrderViewCommand = new RelayCommand(o =>
        {
            CurrentView = AddOrderViewModel;
        });
        EditOrderViewCommand = new RelayCommand(o =>
        {
            CurrentView = EditOrderViewModel;
        });
        DeleteOrderViewCommand = new RelayCommand(o =>
        {
            CurrentView = DeleteOrderViewModel;
        });

        AddProjectViewCommand = new RelayCommand(o =>
        {
            CurrentView = AddProjectViewModel;
        });

        DeleteProjectViewCommand = new RelayCommand(o =>
        {
            CurrentView = DeleteProjectViewModel;
        });

        AddTaskViewCommand = new RelayCommand(o =>
        {
            CurrentView = AddTaskViewModel;
        });
        DeleteTaskViewCommand = new RelayCommand(o =>
        {
            CurrentView = DeleteTaskViewModel;
        });

        StartViewCommand = new RelayCommand(o =>
        {
            CurrentView = StartViewModel;
        });

        GetTasksViewCommand = new RelayCommand(o =>
        {
            CurrentView = GetTasksViewModel;
        });
    }
}