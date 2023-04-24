using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCSIM_Adv_CoSimulation.Utilities
{
    internal static class GlobalConstants
    {
        #region Fields
        /// <summary>
        /// CELL Zoning command values.
        /// </summary>
        internal enum CellCommandValues : byte
        {
            None = 0,
            Run = 1,
            Permit = 2,
            Cancel = 3
        }

        /// <summary>
        /// Zoning statuses dictionary.
        /// </summary>
        internal static readonly Dictionary<int, string> ZoningStatuses = new Dictionary<int, string>
        {
            {0, "Stop"},
            {1, "Waiting"},
            {2, "Requesting"},
            {3, "Canceling"},
            {4, "Permit"},
        };
        #endregion // Fields
    }
}
