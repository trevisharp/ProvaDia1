using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace DesktopPR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             
            DateTime st = DateTime.Now.AddSeconds(10);
            timer1 = new Timer();

            int x = 0;
            int y = 0;

            int count = 0;
            int size = 80;

            var imgs = typeof(Properties.Resources)
                .GetRuntimeProperties()
                .Where(a => a.Name.StartsWith("_"))
                .Select(b => (Bitmap)b.GetValue(null))
                .ToArray();
            
            Random rand = new Random();

            var randImgs = imgs
                .OrderBy(a => rand.Next())
                .Take(8);

            var correct = randImgs.First();

            var imagens = randImgs
                .Zip(randImgs, (t1, t2) => (t1, t2))
                .Append((correct, correct))
                .OrderBy(a => rand.Next());

            panel1.Controls.AddRange(
                imagens.SelectMany(t => new Control[] {
                    create(t.Item1, t.Item1 == t.Item2),
                    create(t.Item2, t.Item1 == t.Item2)
                }).ToArray()
            );

            PictureBox create(Bitmap bmp, bool isCorrect)
            {
                PictureBox pb = new PictureBox();
                pb.Width = size;
                pb.Height = size;
                pb.Location = new Point(x, y);
                pb.Image = bmp;

                x += size + 10;
                if (x > 6 * size)
                {
                    x = 0;
                    y += size + 10;
                }

                pb.Click += delegate
                {
                    if(isCorrect) this.Close();
                    else
                    {
                        count++;
                        if (count > 2) Application.Exit();
                    }
                };

                return pb;
            }
        }
    }
}