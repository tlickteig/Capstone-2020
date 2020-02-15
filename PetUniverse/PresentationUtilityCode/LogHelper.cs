using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace WPFPresentationLayer
{
    /// <summary>
    /// NAME: Zach Behrensmeyer
    /// DATE: 2/11/2020
    /// CHECKED BY: Steven Cardona
    /// 
    /// This class is a helper method to call when something needs logged in the PresentationLayer
    /// </summary>
    public class LogHelper
    {
        public static readonly ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
