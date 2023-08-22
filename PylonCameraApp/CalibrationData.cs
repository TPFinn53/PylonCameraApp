using System;
using System.Drawing;
using System.Collections.Generic;
using Basler.Pylon;
using OxyPlot.Annotations;

namespace PylonCameraApp
{
    [Serializable]
    public class CalibrationData
    {
        public int Bins { set; get; }
        public int Columns { set; get; }
        public int Rows { set; get; }
        public ushort[] Raster { set; get; }
        public bool[] Mask { set; get; }
        public PixelType PixelType { set; get; }
        public SelectionAnnotation Selection { set; get; }
    }
}
