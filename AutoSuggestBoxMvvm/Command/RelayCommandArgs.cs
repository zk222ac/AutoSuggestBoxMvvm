using System;
using System.Windows.Input;

namespace AutoSuggestBoxMvvm.Command
{
    public class RelayCommandArgs<T> : ICommand
    {
        private readonly Action<T> executeAction;
        readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommandArgs(Action<T> executeAction)
            : this(executeAction, null)
        {
            //var a = ((Page)(((Func<object, bool>)(executeAction.Target)).Target)).Name;
            //((ViewModel.VMBranchSelection)(executeAction.Target)).;

        }

        public RelayCommandArgs(Action<T> executeAction, Func<object, bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            executeAction((T)parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChanged;
            handler?.Invoke(this, new EventArgs());
        }
    }
}
