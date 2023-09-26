using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var form = new Form();

form.KeyPreview = true;
form.FormBorderStyle = FormBorderStyle.None;
form.WindowState = FormWindowState.Maximized;

int s = 0;
Label label = new Label();
label.Text = $"Slide {s}";
form.Controls.Add(label);

form.KeyDown += (o, e) =>
{
    if (e.KeyCode == Keys.F5)
    {
        form.Close();
    }

    if (e.KeyCode == Keys.Left)
    {
        s--;
        label.Text = $"Slide {s}";
    }

    if (e.KeyCode == Keys.Right)
    {
        s++;
        label.Text = $"Slide {s}";
    }
};

Application.Run(form);