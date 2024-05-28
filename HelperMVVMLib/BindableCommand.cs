using System.Windows.Input;


namespace HelperMVVMLib
{
    public class BindableCommand : ICommand
    {
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public BindableCommand(Action<object> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
