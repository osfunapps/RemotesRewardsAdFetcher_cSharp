using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.program.valuesparser;
using WindowsFormsApp1.program.valuesparser.hooks;

namespace LayoutProject.program.values
{
    class UserActionsCoordinator : HookEventsManager.IUserActionCallback
    {
        private IUserActionsCallback callback;

        //instances
        private FloatingMouseWindow floatingMouseWindowForm;

        public UserActionsCoordinator(IUserActionsCallback callback)
        {
            this.callback = callback;
            floatingMouseWindowForm = new FloatingMouseWindow
            {
                TopMost = true
            };
        }


        internal void ShowMouseNotification(string nodeName)
        {
            floatingMouseWindowForm.AppendMouseTxtLabel(nodeName);
        }

        public void ShowDialog()
        {
                floatingMouseWindowForm.ShowDialog();
        }

        public FloatingMouseWindow GetFloatingMouseWindowForm()
        {
            return floatingMouseWindowForm;
        }

        public void WaitForUserActions()
        {
            HookEventsManager.WaitForUserAction(this);
        }

        public void OnBtnValidated()
        {
            callback.OnUserCallback();
        }
    }

    public interface IUserActionsCallback
    {
        void OnUserCallback();
    }
}
