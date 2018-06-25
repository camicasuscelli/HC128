using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC128.Desktop
{
    class Encript
    {
        private UInt32[] k = new UInt32[4];
        private UInt32[] vi = new UInt32[4];
        private UInt32[] q = new UInt32[512];
        private UInt32[] p = new UInt32[512];
        private UInt32[] message = new UInt32[1024];
        private int size;

        private UInt32[] s;

        public Encript(UInt32[] llave, UInt32[]vectorini)
        {
            //inicializa key e vi:
           /* k = llave;
            vi = vectorini;*/
            for (int i = 0; i < 4; i++)
            {
                k[i] = llave[i];
                vi[i] = vectorini[i];
            }
            
        }

        //	right rotation operator >>>
        private int RRO(int x, int n)
        {
            return ((x >> n) ^ (x << (32 - n)));
        }

        //	left rotation operator <<<

        private int LRO(int x, int n)
        {
            return ((x << n) ^ (x >> (32 - n)));
        }

        //	dividir entero en partes:
        byte int3(int x) { return (byte)(x >> 24); }
        byte int2(int x) { return (byte)(x >> 16); }
        byte int1(int x) { return (byte)(x >> 8); }
        byte int0(int x) { return (byte)(x >> 0); }

        // Formulas que se usarán en el algoritmo:

        private int f1(int x)
        {
            return ((RRO(x, 7)) ^ (RRO(x, 18)) ^ (x >> 3));
            //		return ((x>>>7)^(x>>>18)^(x>>3));
        }

        private int f2(int x)
        {

            return ((RRO(x, 17)) ^ (RRO(x, 19)) ^ (x >> 10));
            //		return ((x>>>17)^(x>>>19)^(x>>10));
        }

        private int g1(int x, int y, int z)
        {
            return ((RRO(x, 10)) ^ (RRO(z, 23)) + (RRO(x, 8)));
            //		return ((x>>> 10)^(z>>>23)+(x>>>8));
        }

        private int g2(int x, int y, int z)
        {
            return ((LRO(x, 10)) ^ (LRO(z, 23)) + (LRO(x, 8)));
            //return ((x <<< 10)^(z <<< 23)+(x <<< 8));
        }

        private uint h1(int x)
        {
            return q[int0(x)] + q[256 + int2(x)];
        }

        private uint h2(int x)
        {
            return p[int0(x)] + p[256 + int2(x)];
        }

        //	Formula de inicialización
        public void inicializacion()
        {

            //		punto 1
            UInt32[] w = new UInt32[1280];
            for (int i = 0; i < 4; i++)
            {
                w[i] = k[i];

                w[i + 4] = k[i];
            }
            for (int i = 0; i < 4; i++)
            {
                w[i + 8] = vi[i];
                w[i + 12] = vi[i];
            }

            for (int i = 16; i <= 1279; i++)
            {
                w[i] = (UInt32)(f2((int)w[i - 2]) + w[i - 7] + f1((int)w[i - 15]) + i);
            }

            //		punto 2
            for (int i = 0; i <= 511; i++)
            {
                p[i] = w[i + 256];
                q[i] = w[i + 768];
            }

            //punto 3
            for (int i = 0; i <= 511; i++)
            {
                uint i1 = (uint)(i - 3) % 512;
                uint i2 = (uint)(i - 10) % 512;
                uint i3 = (uint)(i - 511) % 512;
                uint i4 = (uint)(i - 12) % 512;
                p[i] = (uint)(p[i] + g1((int)p[i1], (int)p[i2], (int)p[i3])) ^ h1((int)p[i4]);
                q[i] = (uint)(q[i] + g2((int)q[i1], (int)q[i2], (int)q[i3])) ^ h2((int)q[i4]);
            }
        }

        //generar la secuencia  para obtener el ciphertext
        //el tamaño es en bytes.
        public void generateKeyStream(int tamaño)
        {
            int i = 0, j;
            s = new UInt32[tamaño];
            while (i < tamaño)
            {

                j = i % 512;
                UInt32 j1 = (UInt32)(j - 3) % 512;
                UInt32 j2 = (UInt32)(j - 10) % 512;
                UInt32 j3 = (UInt32)(j - 511) % 512;
                UInt32 j4 = (UInt32)(j - 12) % 512;

                if ((i % 1024) < 512)
                {
                    p[j] = p[j] + (uint)g1((int)p[j1], (int)p[j2], (int)p[j3]);
                    UInt32 h = p[j4];
                    UInt32 f = p[j];
                    s[i] = (UInt32)(h1((int)h) ^ f);
                }
                else
                {

                    q[j] = q[j] + (UInt32)g2((int)q[j1], (int)q[j2], (int)q[j3]);
                    UInt32 h = p[j4];
                    UInt32 f = p[j];
                    s[i] = (UInt32)h2((int)h) ^ f;
                }

                i++;
            }

        }

        //generar texto cifrado con xor entre texto plano y keystream.
        public byte[] generateCiphertext(byte[] plaintext)
        {
            byte[] aux = new byte[4];
            byte[] keystrm = new byte[plaintext.Length];
            int j = 0;
            foreach (UInt32 val in s)
            {
                aux = BitConverter.GetBytes(val);
                
                keystrm[j] = aux[0];
                keystrm[j + 1] = aux[1];
                keystrm[j + 2] = aux[2];
                keystrm[j + 3] = aux[3];
                j = j + 4;
            }
            
            byte[] ciphertxt = new byte[plaintext.Length];
            for (int i = 0; i < plaintext.Length; i++)
            {
                ciphertxt[i] = (byte)(plaintext[i] ^ keystrm[i]);
            }
            return ciphertxt;
        }
    }
}
