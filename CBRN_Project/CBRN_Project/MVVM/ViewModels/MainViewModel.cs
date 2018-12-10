using System.Windows.Controls;
using System.Windows.Navigation;
using CBRN_Project.MVVM.Views;
using CBRN_Project.Utility;

namespace CBRN_Project.MVVM.ViewModels
{
    class MainViewModel : ObservableObject
    {
        #region Fields

        private InputView  inputView;
        private OutputView outputView;

        #endregion

        #region Properties

        private Page crrtPage;
        public  Page CrrtPage
        {
            get => crrtPage;
            set => OnPropertyChanged(ref crrtPage, value);
        }

        #endregion

        #region Commands

        public RelayCommand<object> New     { get; private set; }
        public RelayCommand<object> Input   { get; private set; }
        public RelayCommand<object> Output  { get; private set; }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            NewSimulation();

            New    = new RelayCommand<object>(param => NewSimulation());
            Input  = new RelayCommand<object>(param => CrrtPage = inputView);
            Output = new RelayCommand<object>(param => CrrtPage = outputView);
        }

        #endregion

        #region Methods

        private void NewSimulation()
        {
            inputView  = new InputView();
            outputView = new OutputView();

            CrrtPage = inputView;
        }

        public void ClearFrameCache(object sender, NavigationEventArgs eventArgs)
        {
            (sender as Frame)?.RemoveBackEntry();
        }

        #endregion
    }
}
