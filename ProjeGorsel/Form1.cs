using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeGorsel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int zaman = 0;
        int sayac = 0;
        double dogru = 0, yanlis = 0, net = 0;

        void sorular()
        {
            if (sayac==1)
            {
                label2.Text = "Başkatsayısı 4, derecesi 3, sabit terimi 8, katsayılar toplamı 6 olan polinom aşağıdakilerden hangisidir?";
                button1.Text = "4x²-6x+8";
                button2.Text = "4x³+x²-7x+8";
                button3.Text = "x³-4x²+8x-6";
                button4.Text = "8x²+6x-4";
                dogrucevap = button2.Text;
            }
            if (sayac == 2)
            {
                label2.Text = "2x²+ax+4=0,  x²-x-a=0  denklemlerinin birer kökü ortak ise a kaçtır?";
                button1.Text = "4";
                button2.Text = "5";
                button3.Text = "6";
                button4.Text = "7";
                dogrucevap = button3.Text;

            }

            if (sayac == 3)
            {
                label2.Text = "f(x)=x²-4x+3 parabolünün eksenleri kestiği noktaları ve tepe noktasını köşe kabul eden dörtgenin alanı kaç br² dir?";
                button1.Text = "4";
                button2.Text = "5";
                button3.Text = "8";
                button4.Text = "10";
                dogrucevap = button1.Text;

            }

            if (sayac == 4)
            {
                label2.Text = "1/sin²15+1/cos²15 işleminin sonucu hangisidir?";
                button1.Text = "8";
                button2.Text = "12";
                button3.Text = "16";
                button4.Text = "20";
                dogrucevap = button3.Text;

            }

            if (sayac == 5)
            {
                label2.Text = "log50=a  ise  log0,016 aşağıdakilerden hangisine eşittir?";
                button1.Text = "2-4a";
                button2.Text = "4-3a";
                button3.Text = "3a-5";
                button4.Text = "5-4a";
                dogrucevap = button4.Text;

            }

        
    }

        private void DortButon(object sender, EventArgs e)
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    item.Enabled = false;
                }
            }
            if (sayac == 5)
            {
                panel1.Visible = false;
                panel2.Visible = true;

                btnSonrSoru.Visible = false;
                MessageBox.Show("Matematik yarışması sona erdi...");
            }

            if ((sender as Button).Text == dogrucevap)
            {
                dogru++;
            }
            else
            {
                yanlis++;
            }

            net = dogru - (yanlis / 3);
            lblDogru.Text = "Doğru Sayısı=" + dogru;
            lblYanlis.Text = "Yanlış Sayısı=" + yanlis;
            lblNet.Text = "Net Sayısı=" + net.ToString("#.##");
            lblGecenZaman.Text = "Geçen Zaman" + zaman;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            zaman++;
            lblZaman.Text = zaman.ToString();
        }

        string dogrucevap = "";
        private void btnSonrSoru_Click(object sender, EventArgs e)
        {
            timer1.Start();
            btnSonrSoru.Text = "Sonraki Soru";
            sayac++;
            label1.Text = "Soru " + sayac + ".";

            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    item.Enabled = true;
                }
            }
            sorular();
        }
    }
}
