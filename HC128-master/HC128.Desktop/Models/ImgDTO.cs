using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC128.Desktop.Models
{
    public class ImgDTO
    {
        private string _Name;
        private Bitmap _Bitmap;
        private Byte[] _Bytes;

        public ImgDTO(string name, Bitmap bitMap = null, Byte[] bytes = null)
        {
            _Name = name;

            if(bitMap != null)
            {
                _Bitmap = bitMap;
                _Bytes = ConvertImg.ToBytes(bitMap);
            }

            if(bytes != null)
            {
                _Bytes = bytes;
                _Bitmap = ConvertImg.ToBitMap(_Bytes);
            }
        }

        public Byte[] ToBytes()
        {
            return _Bytes;
        }

        public Bitmap ToBitmap()
        {
            return _Bitmap;
        }
    }
}
