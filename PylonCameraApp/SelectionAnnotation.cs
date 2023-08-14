using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PylonCameraApp
{
    [Serializable]
    public class SelectionAnnotation
    {
        //
        // Summary:
        //     Gets or sets the minimum X.
        public double MinimumX { get; set; }
        //
        // Summary:
        //     Gets or sets the maximum X.
        public double MaximumX { get; set; }
        //
        // Summary:
        //     Gets or sets the minimum Y.
        public double MinimumY { get; set; }
        //
        // Summary:
        //     Gets or sets the maximum Y.
        public double MaximumY { get; set; }

    }
}
