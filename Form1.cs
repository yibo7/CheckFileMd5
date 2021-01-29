using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckFileMdWu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        private   string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("获取文件的MD5值出错:"+ ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sMd51 = GetMD5HashFromFile(textBox1.Text.Trim());

            string sMd52 = GetMD5HashFromFile(textBox2.Text.Trim());

            if (sMd51.Equals(sMd52))
            {
                MessageBox.Show("这两个文件Md5一样！");
            }
            else
            {
                MessageBox.Show("这两个文件Md5不一样！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //初始化一个OpenFileDialog类
            OpenFileDialog fileDialog = new OpenFileDialog();

            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //初始化一个OpenFileDialog类
            OpenFileDialog fileDialog = new OpenFileDialog();

            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fileDialog.FileName;
            }
        }

        private void btnSelMd5File_Click(object sender, EventArgs e)
        {
            //初始化一个OpenFileDialog类
            OpenFileDialog fileDialog = new OpenFileDialog();

            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = fileDialog.FileName;
            }
        }

        private void btnCreateMd5_Click(object sender, EventArgs e)
        {
            string baseFilePath = @"d:\a.jpg";
            Bitmap bmpBase = new Bitmap(baseFilePath);

            // 画像を切り抜く
            Rectangle rect = new Rectangle(261, 81, 170, 170);
            Bitmap bmpNew = bmpBase.Clone(rect, bmpBase.PixelFormat);

            // 画像をGIF形式で保存
            string newFilePath = @"d:\ a2.jpg";
            bmpNew.Save(newFilePath, ImageFormat.Jpeg);

            // 画像リソースを解放
            bmpBase.Dispose();
            bmpNew.Dispose();

            //string sMd5 = GetMD5HashFromFile(txtFilePath.Text.Trim());
            //lbRzMd5.Text = sMd5;
        }
    }
}
