using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveMaker
{

    //https://www.youfit.co.jp/archives/1418

    class WaveHeader
    {
        //RIFF識別子 	4 	“RIFF”(0x52494646)で固定。
        public const string IDENTIFIER = "RIFF";

        //チャンク サイズ 	4 	ファイル全体サイズからRIFFとWAVEのバイト数(8Byte)を引いた数。この情報をもとにWavファイルのファイルサイズを算出できる。
        public int ChankSize { get; set; }  = 0;

        //フォーマット 	4 	WAVファイルの場合は“WAVE”(0x57415645)で固定。AVIファイルの場合は“AVI”が入る
        public const string FORMAT = "WAVE";

        //fmt識別子 	4 	“fmt “(0x666D7420)で固定。
        public const string FMT_IDENTIFER = "fmt ";

        //fmtチャンクのバイト数 	4 	リニアPCMならば16(0x10000000)
        //その他は、16 + 拡張パラメータ
        public int FmtChank = 16;

        //音声フォーマット 	2 	非圧縮のリニアPCMフォーマットは1(0x0100)。A-lawは6、μ-lawは7。それ以外はこちらを参照。
        public int SoundFormat { get; set; } = 1;

        //チャンネル数 	2 	モノラルは1(0x0100)、ステレオは2(0x0200)
        public int ChannelCount { get; set; } = 1;

        //サンプリング周波数(Hz)   4 	8kHzの場合は(0x401F0000)、44.1kHzの場合なら(0x44AC0000)
        public int SamplingRate { get; set; } = 44100;

        //1 秒あたりバイト数の平均 	4 	サンプリング周波数* ブロックサイズで求める
        //44.1kHz、16bit、モノラルならば44100x2x1=88,200(0x88580100)
        public int BytesPerSecond { get; set; } = 88200;

        //ブロックサイズ 	2 	チャンネル数* 1サンプルあたりのビット数 / 8で求める。モノラル16bitなら1*16bit = 16bit = 2byte (0x0200)、ステレオ16bitなら4(0x0400)
        public int BlockSize { get; set; } = 2;

        //ビット／サンプル 	2 	1サンプルに必要なビット数。8ビットの場合は8(0x0800)、16ビットの場合は16(0x1000)など。
        public int BitPerSample { get; set; } = 16;

        //拡張パラメータのサイズ(2)     リニア PCM(音声フォーマットが1) の場合は未使用。
        public int ExtensionParameterSize { get; set; } = 0;

        //拡張パラメータ(*)     リニア PCM(音声フォーマットが1) の場合は未使用。
        public byte[] ExtensionParameter { get; set; } = null;

        //サブチャンク② 識別子 	4 	“data” (0x64617461)で固定。
        public const string SUBCHANK = "data";

        //サブチャンク② サイズ 	4 	波形データのバイト数(総ファイルサイズ – 126)
        public int SubchankSize { get; set; } = 0;
    }
}
