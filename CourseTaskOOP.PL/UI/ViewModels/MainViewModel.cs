using CourseTaskOOP.PL.UI.Core;
using CourseTaskOOP.PL.UI.ViewModels.Administrator;
using CourseTaskOOP.PL.UI.ViewModels.Client;
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
    public RelayCommand EditProjectViewCommand { get; set; }
    public RelayCommand DeleteProjectViewCommand { get; set; }

    public RelayCommand AddTeamLeaderViewCommand { get; set; }
    public RelayCommand DeleteTeamLeaderViewCommand { get; set; }

    public RelayCommand AddTeamViewCommand { get; set; }
    public RelayCommand DeleteTeamViewCommand { get; set; }

    public RelayCommand AddTaskViewCommand { get; set; }
    public RelayCommand EditTaskViewCommand { get; set; }
    public RelayCommand DeleteTaskViewCommand { get; set; }

    public RelayCommand StartViewCommand { get; set; }

    public AddUserViewModel AddUserViewModel { get; set; }
    public EditUserViewModel EditUserViewModel { get; set; }
    public DeleteUserViewModel DeleteUserViewModel { get; set; }

    public AddOrderViewModel AddOrderViewModel { get; set; }
    public EditOrderViewModel EditOrderViewModel { get; set; }
    public DeleteOrderViewModel DeleteOrderViewModel { get; set; }

    public AddProjectViewModel AddProjectViewModel { get; set; }
    public EditProjectViewModel EditProjectViewModel { get; set; }
    public DeleteProjectViewModel DeleteProjectViewModel { get; set; }

    public AddTeamLeaderViewModel AddTeamLeaderViewModel { get; set; }
    public DeleteTeamLeaderViewModel DeleteTeamLeaderViewModel { get; set; }

    public AddTeamViewModel AddTeamViewModel { get; set; }
    public DeleteTeamViewModel DeleteTeamViewModel { get; set; }

    public AddTaskViewModel AddTaskViewModel { get; set; }
    public EditTaskViewModel EditTaskViewModel { get; set; }
    public DeleteTaskViewModel DeleteTaskViewModel { get; set; }

    public StartViewModel StartViewModel { get; set; }

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
        EditProjectViewModel = new EditProjectViewModel();
        DeleteProjectViewModel = new DeleteProjectViewModel();
        AddTeamLeaderViewModel = new AddTeamLeaderViewModel();
        DeleteTeamLeaderViewModel = new DeleteTeamLeaderViewModel();
        AddTeamViewModel = new AddTeamViewModel();
        DeleteTeamViewModel = new DeleteTeamViewModel();
        AddTaskViewModel = new AddTaskViewModel();
        EditTaskViewModel = new EditTaskViewModel();
        DeleteTaskViewModel = new DeleteTaskViewModel();
        StartViewModel = new StartViewModel();

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
        EditProjectViewCommand = new RelayCommand(o =>
        {
            CurrentView = EditProjectViewModel;
        });
        DeleteProjectViewCommand = new RelayCommand(o =>
        {
            CurrentView = DeleteProjectViewModel;
        });

        AddTeamLeaderViewCommand = new RelayCommand(o =>
        {
            CurrentView = AddTeamLeaderViewModel;
        });
        DeleteTeamLeaderViewCommand = new RelayCommand(o =>
        {
            CurrentView = DeleteTeamLeaderViewModel;
        });

        AddTeamViewCommand = new RelayCommand(o =>
        {
            CurrentView = AddTeamViewModel;
        });
        DeleteTeamViewCommand = new RelayCommand(o =>
        {
            CurrentView = DeleteTeamViewModel;
        });

        AddTaskViewCommand = new RelayCommand(o =>
        {
            CurrentView = AddTaskViewModel;
        });
        EditTaskViewCommand = new RelayCommand(o =>
        {
            CurrentView = EditTaskViewModel;
        });
        DeleteTaskViewCommand = new RelayCommand(o =>
        {
            CurrentView = DeleteTaskViewModel;
        });

        StartViewCommand = new RelayCommand(o =>
        {
            CurrentView = StartViewModel;
        });
    }
}