using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RewardsAdFetcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RewardCoordinator coordinator = new RewardCoordinator();

            //path here!
            coordinator.Coordinate("C:\\programming\\Remote - Projects2");
        }
    }
}
