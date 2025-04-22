using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldWinform
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Hello";
        }

        private void 끝내기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "텍스트 문서(*.txt)|*.txt|csv 파일(*.csv)|*.csv|모든파일(*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            
            switch(result)
            {
                case DialogResult.Cancel:
                    return;
                    break;
                case DialogResult.OK:
                    lblfileName.Text = openFileDialog.FileName;
                    using(StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        textBox1.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                    break;
            }
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblfileName.Text = "제목없음";
            textBox1.Text = "글자를 입력해 주세요";
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lblfileName.Text == "제목없음")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "텍스트 문서(*.txt)|*.txt|csv 파일(*.csv)|*.csv|모든파일(*.*)|*.*";
                DialogResult result = saveFileDialog.ShowDialog();

                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                        break;
                    case DialogResult.OK:
                        lblfileName.Text = saveFileDialog.FileName;
                        break;
                }

            }
            using (StreamWriter sw = new StreamWriter(lblfileName.Text))
            {
                sw.Write(textBox1.Text);
                sw.Close();
            }
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "텍스트 문서(*.txt)|*.txt|csv 파일(*.csv)|*.csv|모든파일(*.*)|*.*";
            saveFileDialog.FileName = lblfileName.Text;
            DialogResult result = saveFileDialog.ShowDialog();

            switch (result)
            {
                case DialogResult.Cancel:
                    return;
                    break;
                case DialogResult.OK:
                    lblfileName.Text = saveFileDialog.FileName;
                    break;
            }
            using (StreamWriter sw = new StreamWriter(lblfileName.Text))
            {
                sw.Write(textBox1.Text);
                sw.Close();
            }
        }
    }
}
