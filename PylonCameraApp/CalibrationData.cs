using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basler.Pylon;


namespace PylonCameraApp
{
    [Serializable]
    public class CalibrationData
    {
        public int Bins { set; get; }
        public int Columns { set; get; }
        public int Rows { set; get; }
        public byte[] Raster { set; get; }
        public bool[] State { set; get; }
        public PixelType PixelType { set; get; }
    }
}
