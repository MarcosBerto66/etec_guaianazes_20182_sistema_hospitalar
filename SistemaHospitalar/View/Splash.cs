using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaHospitalar.View
{
    public partial class Splash : Form
    {
        int cont = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 10;
                if(cont==0){
                    label1.Text = "Carregando.";
                    cont++;
                }
                else if (cont == 1)
                {
                    label1.Text = "Carregando..";
                    cont++;
                }
                else {
                    label1.Text = "Carregando...";
                    cont = 0;
                }
            }
            else
            {
                timer1.Enabled = false;
                label1.Text = "Carregado!";
                Dispose();
            }
        }
    }
}
