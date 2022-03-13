using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveMaker
{
    /// <summary>
    /// フォームクラス
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>WAVE作成オブジェクト</summary>
        private WaveWriter writer = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            writer = new WaveWriter();
        }

        /// <summary>
        /// 再生ボタン押下時処理
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void button1_Click(object sender, EventArgs e)
        {
            var filepath = GetTempWaveFilepath();

            if (Execute(filepath))
            {
                Process.Start(filepath);
            }
        }

        /// <summary>
        /// テンポラリWAVEファイルパスの取得
        /// </summary>
        /// <returns></returns>
        private string GetTempWaveFilepath()
        {
            string folderPath = FileUtil.GetEXEFolderPath();
            string filename = "test.wav";
            return Path.Combine(folderPath, filename);
        }

        /// <summary>
        /// 保存ボタン押下時処理
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Execute(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// WAVE作成
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private bool Execute(string filepath)
        {
            var param = MakeParam(filepath);
            return writer.Execute(param);
        }

        /// <summary>
        /// パラメータ取得
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private WaveWriterParam MakeParam(string filepath)
        {
            double dt = double.Parse(textBox1.Text);
            int dataSize = int.Parse(textBox2.Text);
            int r = int.Parse(textBox3.Text);
            return new WaveWriterParam(filepath, dt, dataSize, r);
        }

        /// <summary>
        /// フォームクローズ時処理
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteTempFile();
        }

        /// <summary>
        /// テンポラリWAVEファイルがあったら削除する
        /// </summary>
        private void DeleteTempFile()
        {
            var filepath = GetTempWaveFilepath();
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
    }
}
