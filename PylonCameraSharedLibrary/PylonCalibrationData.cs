using System;
using System.Drawing;
using Basler.Pylon;

namespace PylonCameraSharedLibrary
{
    [Serializable]
    public class PylonCalibrationData
    {
        public int Bins { set; get; }
        public int Columns { set; get; }
        public int Rows { set; get; }
        public ushort[] Raster { set; get; }
        public bool[] Mask { set; get; }
        public PixelType PixelType { set; get; }
        public Rectangle Selection { set; get; }
    }
}
