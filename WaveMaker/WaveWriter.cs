using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveMaker
{
    class WaveWriter
    {
        public bool Execute(WaveWriterParam p)
        {
            try
            {
                using (FileStream s = new FileStream(p.Filepath, FileMode.OpenOrCreate))
                {
                    WaveHeader h = new WaveHeader();
                    int headerSize = 44;
                    int totalFileSize = headerSize + p.DataSize;
                    h.ChankSize = totalFileSize - 8;
                    h.SubchankSize = p.DataSize;
                    int size = WriteHeader(s, h);

                    double theta = 0;
                    for (int i = 0; i < p.DataSize; i++)
                    {
                        //byte b = (byte)(i % 64);
                        //byte b = (byte)(Math.Cos(theta) * r);
                        //s.WriteByte(b);
                        //size++;

                        int a = (int)(Math.Sin(theta) * p.R);
                        WriteInt(s, a, 2);
                        size += 2;

                        theta += p.Dt;

                    }
                    size += p.DataSize;
                    Console.WriteLine("size={0}", size);

                }
                return true;
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private int WriteHeader(FileStream s, WaveHeader h)
        {
            int size = 0;
            size += WriteString(s, WaveHeader.IDENTIFIER);
            size += WriteInt(s, h.ChankSize, 4);

            size += WriteString(s, WaveHeader.FORMAT);
            size += WriteString(s, WaveHeader.FMT_IDENTIFER);

            size += WriteInt(s, h.FmtChank, 4);
            size += WriteInt(s, h.SoundFormat, 2);
            size += WriteInt(s, h.ChannelCount, 2);
            size += WriteInt(s, h.SamplingRate, 4);
            size += WriteInt(s, h.BytesPerSecond, 4);
            size += WriteInt(s, h.BlockSize, 2);
            size += WriteInt(s, h.BitPerSample, 2);

            //WriteInt(s, h.ExtensionParameterSize, 2);
            //s.Write(h.ExtensionParameter, 0, h.ExtensionParameter.Length);

            size += WriteString(s, WaveHeader.SUBCHANK);
            size += WriteInt(s, h.SubchankSize, 4);

            return size;
        }

        private int WriteString(FileStream s, string str)
        {
            byte[] b = Encoding.ASCII.GetBytes(str);
            s.Write(b, 0, b.Length);
            return b.Length;
        }

        private int WriteByte(FileStream s, byte b)
        {
            s.WriteByte(b);
            return 1;
        }

        private int WriteInt(FileStream s, int num, int size)
        {
            byte[] b = new byte[size];
            Array.Copy(BitConverter.GetBytes(num), b, size);
            //Array.Reverse(b);
            s.Write(b, 0, b.Length);
            return b.Length;
        }
    }
}
