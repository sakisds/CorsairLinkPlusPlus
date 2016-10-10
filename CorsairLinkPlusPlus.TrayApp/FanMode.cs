using CorsairLinkPlusPlus.Driver.CorsairLink.Controller.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsairLinkPlusPlus.TrayApp
{
    /// <summary>
    /// Represents a fan mode
    /// </summary>
    enum FanMode
    {
        Performance, Balanced, Quiet, Custom, FixedRPM, FixedPercent, Default
    }

    static class FanModeUtil
    {
        public static IFanController FanModeToController(FanMode mode)
        {
            switch (mode)
            {
                case FanMode.Performance: return new PerformanceMode();
                case FanMode.Balanced: return new BalancedMode();
                case FanMode.Quiet: return new QuiteMode();
                case FanMode.Custom: return new CustomCurve();
                case FanMode.FixedRPM: return new FixedRPM();
                case FanMode.FixedPercent: return new FixedPercent();
                case FanMode.Default: return new Default();
            }

            // Unreachable code
            return null;
        }
    }    
}
