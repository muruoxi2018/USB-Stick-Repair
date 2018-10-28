using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;


namespace USR
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.muruoxi.com/");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://tieba.baidu.com/f?kw=%B2%A1%B6%BE");
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://tieba.baidu.com/f?kw=%E7%BA%A2%E5%AE%A2");
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://weishi.360.cn/");
        }

        private void CheckBox1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            groupBox2.Enabled = false;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox8.Checked = true;
            checkBox9.Checked = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach (var item in driveInfo)
            {
                if (item.DriveType == DriveType.Removable)
                {
                    textBox1.Text = item.RootDirectory.ToString();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请先选择一个被病毒隐藏了文件的路径！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string dos = "";
                if (checkBox1.Checked)
                {
                    dos = " /d /s +a -s -h -r";
                }
                else
                {
                    if (checkBox8.Checked)
                    {
                        dos += " /s";
                    }
                    if (checkBox9.Checked)
                    {
                        dos += " /d";
                    }
                    if (checkBox10.Checked)
                    {
                        dos += " /l";
                    }
                    if (checkBox3.Checked)
                    {
                        dos += " -r";
                    }
                    if (checkBox4.Checked)
                    {
                        dos += " +a";
                    }
                    if (checkBox5.Checked)
                    {
                        dos += " -s";
                    }
                    if (checkBox6.Checked)
                    {
                        dos += " -h";
                    }
                    if (checkBox7.Checked)
                    {
                        dos += " -i";
                    }
                }
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
#if DEBUG
                                    Console.WriteLine("attrib \"{0}\\*.*\"{1}",textBox1.Text,dos);
#endif

#if !DEBUG
                process.StandardInput.WriteLine("attrib \"{0}\\*.*\"{1}",textBox1.Text,dos);
#endif
                process.StandardInput.WriteLine("exit");
                process.WaitForExit();
                process.Close();
#if !DEBUG
            MessageBox.Show("修复完毕，请检查修复情况。\n此软件无法代替杀毒软件，所以无法用来清理病毒，建议使用360等专业杀毒软件对电脑和移动设备进行全盘查杀以便保证您的电脑安全。","提示：");
            Process.Start("explorer.exe", textBox1.Text);
#endif
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            checkBox1.Checked = false;
            groupBox2.Enabled = true;
        }
    }
}
