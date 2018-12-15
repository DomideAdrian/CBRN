using CBRN_Project.Data_Access;
using CBRN_Project.MVVM.Models;
using CBRN_Project.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        IDialogService dialogService;

        RelayCommand saveCommand;
        RelayCommand changeToTextBoxBreathingRate;
        RelayCommand editIpeCommand;

        #endregion

        #region Constructor

        public CreateIconViewModel(Icon newIcon, IconRepository newIconRepository, IDialogService dialogService)
        {
            icon = newIcon ?? throw new ArgumentNullException("icon");
            iconRepository = newIconRepository ?? throw new ArgumentNullException("iconrepository");
            this.dialogService = dialogService;

            this.DisplayName = "Create Icon";

            CreateBreathingRateValues();
            CreateIpeClasses();
        }


        #endregion

        #region Icon Properties

        public float Personnel
        {
            get { return icon.Personnel; }
            set
            {
                if (value == icon.Personnel)
                    return;

                icon.Personnel = value;

                base.OnPropertyChanged("Personnel");
            }
        }

        public float BodySurfaceArea
        {
            get
            {
                return icon.BodySurfaceArea;
            }
            set
            {
                if (value == icon.BodySurfaceArea)
                    return;

                icon.BodySurfaceArea = value;

                base.OnPropertyChanged("BodySurfaceArea");
            }
        }

        #region Breathing Rate

        private ObservableCollection<string> breathingRateList;

        public ObservableCollection<string> BreathingRateList
        {
            get { return breathingRateList; }
            set
            {
                breathingRateList = value;

                OnPropertyChanged("BreathingRateList");
            }
        }

        private string breathingRateSelected;

        public string BreathingRateSelected
        {
            get { return breathingRateSelected; }
            set
            {
                breathingRateSelected = value;
                icon.BreathingRate.BreathingRateActivityLevel = breathingRateSelected;

                OnPropertyChanged("BreathingRateSelected");
            }
        }

        private bool breathingRateTextBoxVisiblity = false;
        
        public bool BreathingRateTextBoxVisibility
        {
            get { return breathingRateTextBoxVisiblity; }
            set
            {
                breathingRateTextBoxVisiblity = value;
                OnPropertyChanged("BreathingRateTextBoxVisibility");
            }
        }

        private bool breathingRateComboBoxVisiblity = true;

        public bool BreathingRateComboBoxVisibility
        {
            get { return breathingRateComboBoxVisiblity; }
            set
            {
                breathingRateComboBoxVisiblity = value;
                OnPropertyChanged("BreathingRateComboBoxVisibility");
            }
        }

        public float BreathingRateChemAg
        {
            get
            {
                return icon.BreathingRate.ChemAg_Ih;
            }
            set
            {
                if (value == icon.BreathingRate.ChemAg_Ih)
                    return;

                icon.BreathingRate.ChemAg_Ih = value;

                base.OnPropertyChanged("BreathingRateChemAg");
            }
        }

        public float BreathingRateBioAg
        {
            get
            {
                return icon.BreathingRate.BioAg_RadPar_Ih;
            }
            set
            {
                if (value == icon.BreathingRate.BioAg_RadPar_Ih)
                    return;

                icon.BreathingRate.BioAg_RadPar_Ih = value;
                base.OnPropertyChanged("BreathingRateBioAg");
            }
        }

        void CreateBreathingRateValues()
        {
            icon.BreathingRate = new BreathingRate();

            var list = BreathingRate.GetActivityLevelList();
            BreathingRateList = new ObservableCollection<string>();
            foreach(var elem in list)
            {
                BreathingRateList.Add(elem);
            }

            BreathingRateSelected = icon.BreathingRate.BreathingRateActivityLevel;
        }

        #region Breathing Rate Command

        public ICommand ChangeToTextBoxBreathingRate
        {
            get
            {
                if(changeToTextBoxBreathingRate == null)
                {
                    changeToTextBoxBreathingRate = new RelayCommand(param => this.ChangeVisiblitiesBreathingRate());
                }
                return changeToTextBoxBreathingRate;
            }
        }

        public void ChangeVisiblitiesBreathingRate()
        {
            BreathingRateComboBoxVisibility = false;
            BreathingRateTextBoxVisibility = true;
        }

        #endregion

        #endregion

        #region IPE 

        private ObservableCollection<string> ipeList;

        public ObservableCollection<string> IpeList
        {
            get { return ipeList; }
            set
            {
                ipeList = value;

                OnPropertyChanged("IpeList");
            }
        }

        private string ipeSelected;

        public string IpeSelected
        {
            get { return ipeSelected; }
            set
            {
                ipeSelected = value;
                icon.IPE.IpeClass = ipeSelected;

                OnPropertyChanged("IpeSelected");
            }
        }

        void CreateIpeClasses()
        {
            icon.IPE = new ProtFactors();

            IpeList = new ObservableCollection<string>();
            var list = ProtFactors.GetProtectionFactorsList();
            foreach(var elem in list)
            {
                IpeList.Add(elem);
            }

            IpeSelected = icon.IPE.IpeClass;
        }

        public ICommand EditIpeCommand
        {
            get
            {
                if (editIpeCommand == null)
                {
                    editIpeCommand = new RelayCommand(param => this.EditIpe());
                }

                return editIpeCommand;
            }
        }

        void EditIpe()
        {
            var viewModel = new DialogViewModel("Hello!");

            bool? result = dialogService.ShowDialog(viewModel);
            if(result.HasValue)
            {
                if(result.Value)
                {

                }
                else
                {

                }
            }
        
        }

        #endregion

        #endregion

        #region Save Command

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

            MainWindowViewModel.Instance.CloseWorkspace();

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

        #endregion
    }
}
