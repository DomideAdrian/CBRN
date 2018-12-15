using CBRN_Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CBRN_Project.MVVM.ViewModels
{
    public class DialogViewModel : IDialogRequestClose
    {
        public string Message { get; set; }

        public DialogViewModel(string message)
        {
            Message = message;   
        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        RelayCommand okCommand;
        RelayCommand cancelCommand;

        public ICommand OkCommand
        {
            get
            {
                if (okCommand == null)
                {
                    okCommand = new RelayCommand(param => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
                }

                return okCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand(param => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
                }

                return cancelCommand;
            }
        }
    }
}
