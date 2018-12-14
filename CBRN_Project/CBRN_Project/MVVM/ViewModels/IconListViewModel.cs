using CBRN_Project.Data_Access;
using CBRN_Project.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBRN_Project.MVVM.ViewModels
{
    public class IconListViewModel : ViewModelBase
    {
        #region Fields

        readonly IconRepository iconRepository;

        public double TotalIcons
        {
            get
            {
                return IconRepository.LastId - 1;
            }
        }

        public ObservableCollection<Icon> IconsList { get; private set; }

        #endregion 

        public IconListViewModel(IconRepository newIconRepository)
        {
            IconsList = new ObservableCollection<Icon>();

            this.iconRepository = newIconRepository;
            base.DisplayName = "List";

            // Subscribe for notifications of when a new icon is saved.
            iconRepository.IconAdded += this.OnIconAddedToRepository;
        }

        void OnIconAddedToRepository(object sender, IconAddedEventArgs e)
        {
            var icon = new Icon(IconRepository.LastId);
            this.OnPropertyChanged("TotalIcons");
            IconsList.Add(icon);
        }
    }
}
