using EventHook;
using LayoutProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LayoutProject.program.values;

namespace WindowsFormsApp1.program.valuesparser.hooks
{
    class HookEventsManager
    {
        private bool validated = false;

        public void WaitForUserAction(IUserActionCallback userAcitonCallback)
        {
            KeyboardWatcher.Start();
            validated = false;

            KeyboardWatcher.OnKeyInput += (s, e) =>
            {
                Console.WriteLine("btn name: " + e.KeyData.Keyname);
                if (e.KeyData.Keyname.Equals("left ctrl"))
                    Validated(userAcitonCallback);

            };
        }

        private void Validated(IUserActionCallback validationCallback)
        {
            validated = true;
            Console.WriteLine("validated!");
            KeyboardWatcher.Stop();
            MouseWatcher.Stop();
            validationCallback.OnBtnValidated();
        }

        public interface IUserActionCallback
        {
            void OnBtnValidated();
        }

        internal static void WaitForUserAction(UserActionsCoordinator userActionsCoordinator)
        {
            throw new NotImplementedException();
        }
    }


}
