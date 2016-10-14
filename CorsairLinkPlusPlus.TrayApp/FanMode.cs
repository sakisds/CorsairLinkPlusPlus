using CorsairLinkPlusPlus.Driver.CorsairLink.Controller.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsairLinkPlusPlus.TrayApp
{
    static class FanModeUtil
    {
        /// <summary>
        /// Creates a new Fan Controller of the given type.
        /// </summary>
        /// <param name="mode">What kind of fan controller to create</param>
        /// <returns>A new fan controller of the requested type</returns>
        public static IFanController StringToController(string mode)
        {
            switch (mode)
            {
                case "Performance": return new PerformanceMode();
                case "Balanced": return new BalancedMode();
                case "Quiet": return new QuiteMode();
                case "Custom": return new CustomCurve();
                case "Fixed RPM": return new FixedRPM();
                case "Fixed %": return new FixedPercent();
                case "Default": return new Default();
                default: return null;
            }
        }
    }    
}
