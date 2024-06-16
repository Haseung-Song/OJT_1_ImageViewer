using OJT_1_ImageViewer.ViewModels;
using System.Windows;

namespace OJT_1_ImageViewer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }

    }

}
