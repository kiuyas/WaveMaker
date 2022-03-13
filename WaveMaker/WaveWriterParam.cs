using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveMaker
{
    class WaveWriterParam
    {
        /// <summary>出力ファイルパス</summary>
        public string Filepath { get; set; }

        /// <summary>θ増分</summary>
        public double Dt { get; set; }

        /// <summary>データサイズ</summary>
        public int DataSize { get; set; }

        /// <summary>振幅</summary>
        public int R { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filepath">出力ファイルパス</param>
        /// <param name="dt">θ増分</param>
        /// <param name="dataSize">データサイズ</param>
        /// <param name="r">振幅</param>
        public WaveWriterParam(string filepath, double dt, int dataSize, int r)
        {
            Filepath = filepath;
            Dt = dt;
            DataSize = dataSize;
            R = r;
        }
    }
}
