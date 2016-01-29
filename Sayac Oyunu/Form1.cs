using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sayac_Oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool duraklama = false;
        int hak = 5;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!duraklama)
            {
                duraklama = true;
                timer1.Stop();
                button1.Text = "Continue..";
                button1.ForeColor = Color.Green;
                if (sl == 0)
                {
                    timer2.Start();
                    panel1.BackColor = Color.Green;
                    label3.Text = "Tebrikler Oyunu Kazandınız !!";
                    hak = 5;
                    dk = 0;sn = 0;sl = 0;
                }
                else
                {
                    timer2.Start();
                    panel1.BackColor = Color.Red;
                    label3.Text = "Maales, Olmadı !! \nSaniyenin 100'de " + (sl < 50 ? sl : (50 - (sl-50))).ToString() + " 'i zaman ile yanıldınız";
                    hak--;
                    label2.Text = "Kalan Hak = " + hak;
                    if (hak == 0)
                    {
                        DialogResult diyalog= MessageBox.Show("Maales Hakkınız Doldu !","Başarısız Oldunuz !",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        if(diyalog==DialogResult.OK)
                        {
                            Application.Exit();
                        }
                    }
                }
            }
            else
            {
                duraklama = false;
                button1.Text = "Catch !";
                button1.ForeColor = Color.Red;
                timer1.Start();
            }
        }
        int dk=0, sn=0, sl=0;
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Height = 0;
            timer1.Interval = 10;
            timer1.Start();
            timer2.Interval = 10;
        }
        int sayac = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac<100)
            {
                panel1.Height += 10;
            }
            else
            {
                panel1.Height -= 10;
            }
            if(panel1.Height==0)
            {
                timer2.Stop();
                sayac = 0;
                panel1.Height = 0;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sl++;
            if (sl >= 100)
            {
                sl = 0;
                sn++;
            }
            if (sn >= 60)
            {
                sn = 0;
                dk++;
            }

            label1.Text = Ayarla(dk) + " : " + Ayarla(sn) + " : " + Ayarla(sl);

        }
        string Ayarla(int sayi)
        {
            if (sayi < 10)
                return "0" + sayi.ToString();
            return sayi.ToString();
        }
    }
}
