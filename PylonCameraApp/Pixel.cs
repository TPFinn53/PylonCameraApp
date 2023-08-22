using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PylonCameraApp
{
    [Serializable]
    public class Pixel
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public ushort Value { get; set; }
    }
}
