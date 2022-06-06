using CourseTaskOOP.BLL.Services;
using System.Windows;

namespace CourseTaskOOP.PL;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DevelopersService developersService = new DevelopersService();
        TextBlock.Text = developersService.GetById(1).FullName;
    }
}