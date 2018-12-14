using CBRN_Project.Data_Access;
using CBRN_Project.MVVM.Models;
using CBRN_Project.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CBRN_Project.MVVM.ViewModels
{
    public class MainWindowViewModel : WorkspaceViewModel
    {
        #region Fields

        readonly IconRepository                     iconRepository;
        IconListViewModel                           iconsList;
        ObservableCollection<WorkspaceViewModel>    workspaces;

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            base.DisplayName = "MainWindow";
            iconRepository = new IconRepository();
        }

        #endregion

        #region Icon List

        public IconListViewModel IconsList
        {
            get
            {
                if(iconsList == null)
                {
                    iconsList = new IconListViewModel(iconRepository);
                }
                return iconsList;
            }
        }

        #endregion

        #region Workspaces

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if(workspaces == null)
                {
                    workspaces = new ObservableCollection<WorkspaceViewModel>();
                    workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }

                return workspaces;
            }
        }

        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        #endregion

        #region Private Functions

        RelayCommand createIconCommand;

        public ICommand CreateIconCommand
        {
            get
            {
                if(createIconCommand == null)
                {
                    createIconCommand = new RelayCommand(param => this.CreateNewIcon());
                }

                return createIconCommand;
            }
        }

        void CreateNewIcon()
        {
            if (Workspaces.Count == 4)
                return;

            Icon newIcon = Icon.CreateNewIcon(IconRepository.LastId);
            CreateIconViewModel workspace = new CreateIconViewModel(newIcon, iconRepository);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }


        void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
