using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BarrageComment
{
    public partial class BarrageComment : Form
    {
        Label[] label = new Label[100];
        string qunnum = "";
        public BarrageComment()
        {
            InitializeComponent();
        }

        private void BarrageComment_Load(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            while (qunnum.Equals(""))
                qunnum = Interaction.InputBox("请输入群号", "请输入群号", "", 100, 100);
            for (int i = 0; i < 10; i++)
            {
                label[i] = new Label();
                label[i].Text = "";
                label[i].Location = new Point(Screen.PrimaryScreen.Bounds.Width, i * 40 + 150);
                label[i].AutoSize = true;
                Controls.Add(label[i]);
            }
            Label l = new Label();
            l.AutoSize = true;
            l.Text = "在群" + qunnum + "内发送“弹幕＆你想说的话”即可参与互动！";
            l.Location = new Point(200, 650);
            Controls.Add(l);
            timer1.Enabled = true;
            timer1.Start();
            timer2.Enabled = true;
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (label[i] == null)
                    break;
                if (label[i].Text == "")
                {
                    label[i].Location = new Point(Screen.PrimaryScreen.Bounds.Width, label[i].Location.Y);
                    continue;
                }
                label[i].Location = new Point(label[i].Location.X - (label[i].Width + Screen.PrimaryScreen.Bounds.Width) / 1000, label[i].Location.Y);
                if (label[i].Location.X < -label[i].Width)
                    label[i].Location = new Point(Screen.PrimaryScreen.Bounds.Width, label[i].Location.Y);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string url = "https://ruirui.hxlxz.com/getcomment.php?qunnum=" + qunnum;
            string temp = SmartQQ.HTTP.HttpGet(url);
            string[] tmp = temp.Split('★');
            for (int i = 0; i < 10 && i < tmp.Length; i++)
            {
                if (tmp[i] == null)
                    break;
                label[i].Text = tmp[i];
            }
        }
    }
}
