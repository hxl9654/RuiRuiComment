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
// *   This program is free software: you can redistribute it and/or modify
// *   it under the terms of the GNU General Public License as published by
// *   the Free Software Foundation, either version 3 of the License, or
// *   (at your option) any later version.
// *
// *   This program is distributed in the hope that it will be useful,
// *   but WITHOUT ANY WARRANTY; without even the implied warranty of
// *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// *   GNU General Public License for more details.
// *
// *   You should have received a copy of the GNU General Public License
// *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// *
// * @author     Xianglong He
// * @copyright  Copyright (c) 2015 Xianglong He. (http://tec.hxlxz.com)
// * @license    http://www.gnu.org/licenses/     GPL v3
// * @version    1.0
// * @discribe   RuiRuiComment弹幕显示程序
// * 本软件作者是何相龙，使用GPL v3许可证进行授权。
namespace RuiRuiComment
{
    public partial class RuiRuiComment : Form
    {
        Label[] label = new Label[100];
        string qunnum = "";
        public RuiRuiComment()
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
            Label m = new Label();
            m.AutoSize = true;
            m.Text = "By何相龙 基于RuiRuiRobot 群137777833 https://github.com/hxl9654/RuiRuiComment";
            m.Font = new Font("SimSun", 15);
            m.Location = new Point(200, 700);
            Controls.Add(m);
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
