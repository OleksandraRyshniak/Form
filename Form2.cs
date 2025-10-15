using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormElements
{
    public partial class Form2 : Form
    {
        TreeView tree;
        Label lbl;
        PictureBox pic;
        CheckBox c_btn1, c_btn2, c_btn3, c_btn4;
        RadioButton r_btn1, r_btn2;
        TabControl tabC;
        TabPage tabP1, tabP2, tabP3, tabP4;
        ListBox lb;
        //TextBox tb;
        bool t = true;

        public Form2()
        {
            this.Height = 513;
            this.Width = 800;
            this.Text = "Form2";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Controls");
            tn.Nodes.Add("Pildid");
            tn.Nodes.Add("Märkeruudud");
            tn.Nodes.Add("Radio nupud");
            tn.Nodes.Add("Message Box");
            tn.Nodes.Add("Tab Control");
            tn.Nodes.Add("List Box");
            //tn.Nodes.Add("Tekst");
            tn.Nodes.Add("Menu");

            lbl = new Label();
            lbl.Text = "Elementide loomine c# abil";
            lbl.Font = new Font("Arial", 18);
            lbl.Size = new Size(400, 30);
            lbl.Location = new Point(150, 0);
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseLeave += Lbl_MouseLeave;

            pic = new PictureBox();
            pic.Size = new Size(70, 70);
            pic.Location = new Point(150, 60);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Image = Image.FromFile(@"..\..\Images\1.jpg");
            pic.DoubleClick += Pic_DoubleClick;

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        int click = 0;
        private void Pic_DoubleClick(object sender, EventArgs e)
        {   
            string[] images = { "2.jpg", "3.jpg", "4.jpg" };
            string fail = images[click];
            pic.Image = Image.FromFile(@"..\..\Images\" + fail);
            click++;
            if (click == 3) { click = 0; }
        }
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Pildid")
            {
                this.Controls.Add(pic);
            }
            else if (e.Node.Text == "Märkeruudud")
            {
                c_btn1 = new CheckBox();
                c_btn1.Text = "Vali mind";
                c_btn1.Size = new Size(c_btn1.Text.Length * 9, 20);
                c_btn1.Location = new Point(250, 100);
                c_btn1.CheckedChanged += C_btn1_CheckedChanged;
                c_btn2 = new CheckBox();
                c_btn2.Size = new Size(100, 100);
                c_btn2.Image = Image.FromFile(@"..\..\Images\1.jpg");
                c_btn2.Location = new Point(350, 100);
                c_btn2.CheckedChanged += C_btn2_CheckedChanged;
                c_btn3 = new CheckBox();
                c_btn3.Size = new Size(100, 100);
                c_btn3.Image = Image.FromFile(@"..\..\Images\3.jpg");
                c_btn3.Location = new Point(450, 100);
                c_btn3.CheckedChanged += C_btn3_CheckedChanged;
                c_btn4 = new CheckBox();
                c_btn4.Text = "Kuva pilt";
                c_btn4.Size = new Size(c_btn1.Text.Length * 9, 20);
                c_btn4.Location = new Point(550, 100);
                c_btn4.CheckedChanged += C_btn4_CheckedChanged;

                this.Controls.Add(c_btn1);
                this.Controls.Add(c_btn2);
                this.Controls.Add(c_btn3);
                this.Controls.Add(c_btn4);
            }
            else if (e.Node.Text == "Radio nupud")
            {
                r_btn1 = new RadioButton();
                r_btn1.Text = "Must teema";
                r_btn1.Location = new Point(200, 330);
                r_btn2 = new RadioButton();
                r_btn2.Text = "Valge teema";
                r_btn2.Location = new Point(200, 300);
                this.Controls.Add(r_btn1);
                this.Controls.Add(r_btn2);
                r_btn1.CheckedChanged += new EventHandler(r_btn_Checked);
                r_btn2.CheckedChanged += new EventHandler(r_btn_Checked);
            }
            else if (e.Node.Text == "Message Box")
            {
                MessageBox.Show("Tere tulemast!", "MessageBox");
                var answer = MessageBox.Show("Kas soovid registreeruda?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta oma nimi", "InputBox", "...");
                    if (MessageBox.Show("Kas tahad tekst saada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = "Tere " + text + " !"; ;
                        Controls.Add(lbl);
                    }
                    else
                    {
                        lbl.Text = "Siis mina lisan oma teksti!";
                        Controls.Add(lbl);
                    }
                }
                else
                {
                    MessageBox.Show("Veel MessageBox", "Kõige lihtsam aken");
                }
            }
            else if (e.Node.Text == "Tab Control")
            {
                tabC = new TabControl();
                tabC.Location = new Point(450, 200);
                tabC.Size = new Size(300, 200);
                tabP1 = new TabPage("Esimene pilt");
                PictureBox pb1 = new PictureBox();
                pb1.Dock = DockStyle.Fill;
                pb1.Image = Image.FromFile(@"..\..\Images\1.jpg");
                pb1.SizeMode = PictureBoxSizeMode.CenterImage;
                tabP1.Controls.Add(pb1);

                tabP2 = new TabPage("Teine pilt");
                PictureBox pb2 = new PictureBox();
                pb2.Dock = DockStyle.Fill;
                pb2.Image = Image.FromFile(@"..\..\Images\2.jpg");
                pb2.SizeMode = PictureBoxSizeMode.CenterImage;
                tabP2.Controls.Add(pb2);

                tabP3 = new TabPage("Kolmmas pilt");
                PictureBox pb3 = new PictureBox();
                pb3.Dock = DockStyle.Fill;
                pb3.Image = Image.FromFile(@"..\..\Images\3.jpg");
                pb3.SizeMode = PictureBoxSizeMode.CenterImage;
                tabP3.Controls.Add(pb3);

                tabP4 = new TabPage("+");
                tabP4.DoubleClick += TabP4_DoubleClick;

                tabC.Controls.Add(tabP1);
                tabC.Controls.Add(tabP2);
                tabC.Controls.Add(tabP3);
                tabC.Controls.Add(tabP4);
                this.Controls.Add(tabC);

                tabC.DoubleClick += TabC_DoubleClick;
            }
            else if (e.Node.Text == "List Box")
            {
                lb = new ListBox();
                lb.Items.Add("Kollane");
                lb.Items.Add("Rosa");
                lb.Items.Add("Roheline");
                lb.Items.Add("Punane");
                lb.Items.Add("Sinine");
                lb.Location = new Point(150, 150);
                lb.SelectedIndexChanged += new EventHandler(ls_SelectedIndexChanged);
                this.Controls.Add(lb);
            }
            else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuFile = new MenuItem("Form");
                menuFile.MenuItems.Add("Restart", new EventHandler(menuFile_Exit_Select));
                menu.MenuItems.Add(menuFile);
                this.Menu = menu;
            }
            //else if (e.Node.Text == "Tekst")
            //{
            //    tb = new TextBox();
            //    tb.Size = new Size(200, 30);
            //    tb.Location = new Point(150, 50);
            //    tb.GotFocus += Tb_GotFocus;
            //    tb.LostFocus += Tb_LostFocus;
            //    this.Controls.Add(tb);
            //}
            tree.SelectedNode = null;
        }
        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            lbl.BackColor = Color.Transparent;
            Form1 Form = new Form1();
            Form.Show();
            this.Hide();
        }
        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            lbl.BackColor = Color.FromArgb(200, 10, 20);
        }
        private void menuFile_Exit_Select(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void ls_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lb.SelectedItem.ToString())
            {
                case ("Sinine"): BackColor = Color.Blue; break;
                case ("Kollane"): BackColor = Color.Yellow; break;
                case ("Punane"): BackColor = Color.Red; break;
                case ("Rosa"): BackColor = Color.Pink; break;
                case ("Roheline"): BackColor = Color.Green; break;
            }
        }
        private void r_btn_Checked(object sender, EventArgs e)
        {
            if (r_btn1.Checked)
            {
                this.tree.BackColor = Color.Black;
                tree.ForeColor = Color.White;
            }
            else if (r_btn2.Checked)
            {
                this.tree.BackColor = Color.White;
                tree.ForeColor = Color.Black;
            }
        }
        private void C_btn1_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                this.Size = new Size(1000, 1000);
                pic.BorderStyle = BorderStyle.Fixed3D;
                c_btn1.Text = "Väiksem";
                c_btn1.Font = new Font("Arial", 8, FontStyle.Bold);
                t = false;
            }
            else
            {
                this.Size = new Size(700, 500);
                pic.BorderStyle = BorderStyle.Fixed3D;
                c_btn1.Text = "Suurendame";
                c_btn1.Font = new Font("Arial", 7, FontStyle.Bold);
                t = true;
            }
        }
        private void C_btn2_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                c_btn2.Size = new Size(100, 100);
                c_btn2.Image = Image.FromFile(@"..\..\Images\2.jpg");
                c_btn2.Location = new Point(350, 100);
                t = false;
            }
            else
            {
                c_btn2.Size = new Size(100, 100);
                c_btn2.Image = Image.FromFile(@"..\..\Images\1.jpg");
                c_btn2.Location = new Point(350, 100);
                t = true;
            }
        }
        private void C_btn3_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                c_btn3.Size = new Size(100, 100);
                c_btn3.Image = Image.FromFile(@"..\..\Images\4.jpg");
                c_btn3.Location = new Point(450, 100);
                t = false;
            }
            else
            {
                c_btn3.Size = new Size(100, 100);
                c_btn3.Image = Image.FromFile(@"..\..\Images\3.jpg");
                c_btn3.Location = new Point(450, 100);
                t = true;
            }
        }
        private void C_btn4_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                c_btn4.Size = new Size(100, 100);
                c_btn4.Text = " ";
                c_btn4.Image = Image.FromFile(@"..\..\Images\2.jpg");
                c_btn4.Location = new Point(550, 100);
                t = false;
            }
            else
            {
                pic.BorderStyle = BorderStyle.Fixed3D;
                c_btn4.Text = "Kuva pilt";
                c_btn4.Image = Image.FromFile(@"..\..\Images\pusto.png");
                c_btn4.Font = new Font("Arial", 8, FontStyle.Bold);
                c_btn4.Location = new Point(550, 100);
                t = true;
            }

        }
        private void TabC_DoubleClick(object sender, EventArgs e)
        {
            string title = "tabP" + (tabC.TabCount - 1).ToString();
            TabPage tb = new TabPage(title);

            tabC.TabPages.Add(tb);
        }
        private void TabP4_DoubleClick(object sender, EventArgs e)
        {
            string title = "New tab" + (tabC.TabCount + 1).ToString();
            TabPage tb = new TabPage(title);
            tabC.TabPages.Add(tb);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        //private void Tb_LostFocus(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(tb.Text))
        //    {
        //        tb.ForeColor = Color.Gray;
        //        tb.Text = "Sisesta pealkiri ...";
        //    }
        //}
        //private void Tb_GotFocus(object sender, EventArgs e)
        //{
        //    if (tb.ForeColor == Color.Gray)
        //    {
        //        tb.Text = "";
        //        tb.ForeColor = Color.Black;
        //    }
        //}
    }
}
