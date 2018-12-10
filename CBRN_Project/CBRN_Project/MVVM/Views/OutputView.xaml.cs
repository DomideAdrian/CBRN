using System.Windows.Controls;
using CBRN_Project.MVVM.ViewModels;

namespace CBRN_Project.MVVM.Views
{
    public partial class OutputView : Page
    {
        public OutputView()
        {
            InitializeComponent();
            this.DataContext = new OutputViewModel();
        }
    }
}
