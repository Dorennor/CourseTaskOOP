using CourseTaskOOP.PL.UI.Core;
using CourseTaskOOP.PL.UI.ViewModels.Administrator;
using CourseTaskOOP.PL.UI.ViewModels.Client;

namespace CourseTaskOOP.PL.UI.ViewModels;

public class MainViewModel : ObservableObject
{
    public RelayCommand AddUserViewCommand { get; set; }
    public RelayCommand EditUserViewCommand { get; set; }
    public RelayCommand DeleteUserViewCommand { get; set; }

    public RelayCommand AddOrderViewCommand { get; set; }
    public RelayCommand EditOrderViewCommand { get; set; }
    public RelayCommand DeleteOrderViewCommand { get; set; }

    public AddUserViewModel AddUserViewModel { get; set; }
    public EditUserViewModel EditUserViewModel { get; set; }
    public DeleteUserViewModel DeleteUserViewModel { get; set; }

    public AddOrderViewModel AddOrderViewModel { get; set; }
    public EditOrderViewModel EditOrderViewModel { get; set; }
    public DeleteOrderViewModel DeleteOrderViewModel { get; set; }

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
    }
}