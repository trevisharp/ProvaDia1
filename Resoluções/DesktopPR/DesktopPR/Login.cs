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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            DesktopPREntities1 db = new DesktopPREntities1();   
            int count = 0;

            button1.Click += delegate
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    
                }

                var r = db.Usuarios.FirstOrDefault(x => x.Usuario == textBox1.Text);

                if (r == null)
                {
                    MessageBox.Show("Usuario inexistente");
                }
                else
                {
                    if (r.Senha == textBox2.Text && (r.Bloqueado == false || r.Bloqueado == null))
                    {
                        Principal p = new Principal(r);
                        p.Show();
                        this.Hide();
                    }
                    else
                    {
                        count++;
                        Form1 form = new Form1();
                        switch (count)
                        {
                            case 1:
                                bloquear(5);
                                form.Show();
                                break;
                            case 2:
                                bloquear(10);
                                form.Show();
                                break;
                            case 3:
                                r.Bloqueado = true;
                                db.SaveChanges();
                                MessageBox.Show("Usuario foi bloqueado.");
                                break;
                        }

                    }
                }
            };
        }

        void bloquear(int secs)
        {
            var form = new Form();
            form.BackColor = Color.Magenta;
            form.TransparencyKey = Color.Magenta;
            form.FormBorderStyle = FormBorderStyle.None;

            form.Load += async delegate
            {
                await Task.Delay(secs * 1000);
                form.Close();
            };

            form.ShowDialog();
        }
    }
}
