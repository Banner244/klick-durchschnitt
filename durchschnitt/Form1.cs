using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace durchschnitt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int zaeler=0, zaeler2=0, zaeler4=0;
        double zaeler3 = 0;
        bool start=false, start2 = false;
        double[] iarray = new double[999];
        private void button1_Click(object sender, EventArgs e)
        {
           
            timer2.Stop();
            zaeler3 = 0;
            timer2.Start();

            if(start==false)
            {
                timer1.Start();
                start = true;
            }
            
            zaeler++;

            ausgabe();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;

            zaeler2++;
            label1.Text = zaeler2+" Sekunden";
           
            if(zaeler2==numericUpDown1.Value)
            {
                button1.Enabled = false;
                ausgabe();
                timer1.Stop();
            }
        }
        double schnitt = 0;
        void ausgabe()
        {
            zaeler4++;

            label2.Text = durchschnitt(zaeler, zaeler2) + " Klicks pro Sekunde" + "\n" + zaeler+" Klicks";
            if (zaeler2 == numericUpDown1.Value)
            {
                for (int i = 0; i < iarray.Length; i++)
                {
           //         MessageBox.Show(iarray+"");
                    schnitt +=iarray[i];
                }
                           
                button1.Text = schnitt.ToString();
                schnitt /= zaeler;
                label3.Text =schnitt+ " Millisekunden abstand pro Klick";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 1;
            zaeler3++;

            iarray[zaeler4] = zaeler3;

        }

        double durchschnitt(int za, int za2)
        {
            double wert=0;

            wert =(double) za / za2;
            return wert;
        }
        
    }
}
