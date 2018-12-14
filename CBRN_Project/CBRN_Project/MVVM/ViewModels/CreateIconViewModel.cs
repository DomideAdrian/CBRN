using CBRN_Project.Data_Access;
using CBRN_Project.MVVM.Models;
using CBRN_Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CBRN_Project.MVVM.ViewModels
{
    public class CreateIconViewModel : WorkspaceViewModel
    {
        #region Fields

        readonly Icon icon;
        readonly IconRepository iconRepository;

        // Other fields here

        RelayCommand saveCommand;

        #endregion

        #region Constructor

        public CreateIconViewModel(Icon newIcon, IconRepository newIconRepository)
        {
            icon = newIcon ?? throw new ArgumentNullException("icon");
            iconRepository = newIconRepository ?? throw new ArgumentNullException("iconrepository");
            this.DisplayName = "Create Icon";
        }

        #endregion

        #region Icon Properties

        public double Personnel
        {
            get { return icon.Personnel; }
            set
            {
                if (value == icon.Personnel)
                    return;

                icon.Personnel = value;

                base.OnPropertyChanged("Personeel");
            }
        }

        #endregion

        public ICommand SaveCommand
        {
            get
            {
                if(saveCommand == null)
                {
                    saveCommand = new RelayCommand(param => this.Save(),
                                                    param => this.CanSave);
                }

                return saveCommand;
            }
        }

        public void Save()
        {
            if (this.IsNewIcon)
                iconRepository.AddIcon(icon);

            base.OnPropertyChanged("DisplayName");
        }

        bool CanSave
        {
            get
            {
                return true;
            }
        }

        bool IsNewIcon
        {
            get { return !iconRepository.ContainsIcon(icon); }
        }
    }
}
