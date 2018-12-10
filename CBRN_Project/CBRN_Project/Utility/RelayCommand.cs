using System;
using System.Windows.Input;

namespace CBRN_Project.Utility
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T>     execute;
        private readonly Func<T, bool> canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute    = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ?? (parameter => true);
        }

        public event EventHandler CanExecuteChanged
        {
            add    => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter) => execute((T)parameter);

        public bool CanExecute(object parameter) => canExecute((T)parameter);
    }
}
