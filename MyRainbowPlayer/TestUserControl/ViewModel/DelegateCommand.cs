using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TestUserControl
{
 
    public class DelegateCommand : ICommand
    {
        Func<object, bool> canExecute;
        Func<bool> canExecuteWithoutParam;

        Action<object> executeAction;
        bool withParam;
        bool canExecuteCache;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
            withParam = true;
        }

        public DelegateCommand(Action<object> executeAction, Func<bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecuteWithoutParam = canExecute;
            withParam = false;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            bool temp;
            if (withParam == true)
                temp = canExecute(parameter);
            else
                temp = canExecuteWithoutParam();

            if (canExecuteCache != temp)
            {
                canExecuteCache = temp;
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, new EventArgs());
                }
            }

            return canExecuteCache;
        }


        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {

            executeAction(parameter);
        }

        #endregion
    }

}