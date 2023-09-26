using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopPR
{
    public partial class Principal : Form
    {
        DesktopPREntities1 db = new DesktopPREntities1();
        Graphics g;

        public Principal(Usuarios user)
        {
            InitializeComponent();

            Load += delegate
            {
                

                var a = db.Alunos.FirstOrDefault(x => x.Pessoa.Usuarios.Id == user.Id);
                if(a != null)
                {
                    salvarToolStripMenuItem.Enabled = false;
                    novoToolStripMenuItem.Enabled = false;

                    inserirToolStripMenuItem.Enabled = false;
                    listagemAlunoToolStripMenuItem.Enabled = false;
                }

                flowLayoutPanel1.BackColor = Color.White;
                pb.BackColor = Color.White;
            };
        }

        private void tExtoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void apresentarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

    public class Projeto
    {
        List<Bitmap> slides = new List<Bitmap>();

        public void addSlide(PictureBox pb)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            slides.Add(bmp);
        }
            
        public void removeSlide(int index)
            => slides.RemoveAt(index);

        public void desenhaSlide(int index, PictureBox pb)
        {
            Bitmap bmp = slides[index];
            pb.Image = bmp;
            pb.Refresh();
        }

        public void insereImage(int index, PictureBox pb, Graphics g)
        {
            Bitmap bmp = slides[index];
            g = Graphics.FromImage(bmp);
            pb.Image = bmp;


        }
    }
}
