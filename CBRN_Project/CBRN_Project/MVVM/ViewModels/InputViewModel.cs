using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using CBRN_Project.MVVM.Models;
using CBRN_Project.MVVM.Views;
using CBRN_Project.Utility;

namespace CBRN_Project.MVVM.ViewModels
{
    class InputViewModel : ObservableObject
    {
        #region Fields

        private EditView editView;

        #endregion

        #region Properties

        public ObservableCollection<Icon> Icons { get; set; }

        private Icon selectedIcon;
        public  Icon SelectedIcon
        {
            get => selectedIcon;
            set => OnPropertyChanged(ref selectedIcon, value);
        }

        private uint iconsCount;
        public  uint IconsCount
        {
            get => iconsCount;
            set => OnPropertyChanged(ref iconsCount, value);
        }

        private uint personnelCount;
        public  uint PersonnelCount
        {
            get => personnelCount;
            set => OnPropertyChanged(ref personnelCount, value);
        }

        private Page crrtPage;
        public  Page CrrtPage
        {
            get => crrtPage;
            set => OnPropertyChanged(ref crrtPage, value);
        }

        #endregion

        #region Commands

        public RelayCommand<object> Add    { get; private set; }
        public RelayCommand<object> Edit   { get; private set; }
        public RelayCommand<object> Remove { get; private set; }

        #endregion

        #region Constructors

        public InputViewModel()
        {
            this.editView = new EditView();

            this.Icons = new ObservableCollection<Icon>();
            this.IconsCount     = 0;
            this.PersonnelCount = 0;

            this.Add    = new RelayCommand<object>(AddIcon);
            this.Edit   = new RelayCommand<object>(EditIcon);
            this.Remove = new RelayCommand<object>(RemoveIcon);
        }

        #endregion

        #region Methods

        private void AddIcon(object param)
        {

        }

        private void EditIcon(object param)
        {
            CrrtPage = editView;
        }

        private void RemoveIcon(object param)
        {

        }

        public void ClearFrameCache(object sender, NavigationEventArgs eventArgs)
        {
            (sender as Frame)?.RemoveBackEntry();
        }

        #endregion
    }
}
