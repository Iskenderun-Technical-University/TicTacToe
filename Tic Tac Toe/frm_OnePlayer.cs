﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class frm_OnePlayer : Form
    {
        public frm_OnePlayer()
        {
            InitializeComponent();
        }
        List<Guna.UI2.WinForms.Guna2Button> buttons;
        Random rand=new Random();
        int player1 = 0;
        int player2 = 0;
        void loadbuttons()
        {
            buttons = new List<Guna.UI2.WinForms.Guna2Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
        }
        void wineffect(Guna.UI2.WinForms.Guna2Button b1 ,Guna.UI2.WinForms.Guna2Button b2 , Guna.UI2.WinForms.Guna2Button b3)
        {
            b1.ForeColor = Color.FromArgb(84, 180, 53);
            b2.ForeColor = Color.FromArgb(84, 180, 53);
            b3.ForeColor = Color.FromArgb(84, 180, 53);
            if (b1.Text== "X")
            {
                player1++;
                lbl1.Text = player1.ToString();
            }
            else
            {
                player2++;
                lbl2.Text = player2.ToString();
            }
        }
        bool win = false;
        void getthewinner()
        {
            if(btn1.Text != ""&& btn1.Text == btn2.Text && btn1.Text == btn3.Text)
            {
                wineffect(btn1, btn2, btn3 );
                win = true;
            }
            else if(btn4.Text != "" && btn4.Text == btn5.Text && btn4.Text == btn6.Text)
            {
                wineffect(btn4, btn5, btn6 );
                win = true;
            }
            else if(btn7.Text != "" && btn7.Text == btn8.Text && btn7.Text == btn9.Text)
            {
                wineffect(btn7, btn8, btn9);
                win = true;
            }
            else if (btn1.Text != "" && btn1.Text == btn4.Text && btn1.Text == btn7.Text)

            {
                wineffect(btn1, btn4, btn7);
                win = true;
            }
            else if (btn2.Text != "" && btn2.Text == btn5.Text && btn2.Text == btn8.Text)

            {
                wineffect(btn2, btn5, btn8);
                win = true;
            }
            else if (btn3.Text != "" && btn3.Text == btn6.Text && btn3.Text == btn9.Text)

            {
                wineffect(btn3, btn6, btn9);
                win = true;
            }
            else if (btn1.Text != "" && btn1.Text == btn5.Text && btn1.Text == btn9.Text)

            {
                wineffect(btn1, btn5, btn9);
                win = true;
            }
            else if (btn3.Text != "" && btn3.Text == btn5.Text && btn3.Text == btn7.Text)

            {
                wineffect(btn3, btn5, btn7);
                win = true;
            }

        }

        private void frm_OnePlayer_Load(object sender, EventArgs e)
        {
            foreach (Control c in panelOfButtens.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button)
                {
                    c.Click += new System.EventHandler(btn_click);
                }
            }
            loadbuttons();
        }
        public void btn_click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn=(Guna.UI2.WinForms.Guna2Button)sender;
            if(btn.Text.Equals(""))
            {
                btn.Text = "X";
                btn.ForeColor = Color.FromArgb(245, 197, 88);
                buttons.Remove(btn);
                getthewinner();
                move.Start();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMain frm = new FrmMain();
            frm.Show();
        }

        private void move_Tick(object sender, EventArgs e)
        {
            if(buttons.Count > 0 && win == false)
            {
                int index = rand.Next(buttons.Count);
                if (buttons[index].Text == "")
                {
                    buttons[index].ForeColor = Color.FromArgb(245, 197, 88);
                    buttons[index].Text = "0";
                    getthewinner();
                    move.Stop();
                }
            }
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            loadbuttons();
            win = false;
            foreach(Control c in panelOfButtens.Controls)
            {
                if(c is Guna.UI2.WinForms.Guna2Button)
                {
                    c.Text = "";
                }
            }
        }
    }
}
