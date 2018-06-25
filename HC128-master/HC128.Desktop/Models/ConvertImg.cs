using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC128.Desktop.Models
{
    public static class ConvertImg
    {
        public static Byte[] ToBytes(Bitmap bitMap)
        {
            ImageConverter imgCon = new ImageConverter();
            return (byte[])imgCon.ConvertTo(bitMap, typeof(byte[]));
        }

        public static Bitmap ToBitMap(Byte[] bytes)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = bytes;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
    }
}
