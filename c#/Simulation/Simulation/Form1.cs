using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //MessageBox.Show("hello world");
            Label label = new Label();
            label.Text = "hello world";
            label.Visible = true;
            label.ForeColor = Color.Black;
            label.Location = new Point(100,200);
            this.Controls.Add(label);

            Button button = new Button();
            button.Text = "gomb vagyok";
            button.Enabled = true;
            button.Location = new Point(200, 200);
            button.Size = new Size(100,30);
            button.Click += gomblenyomas;
            this.Controls.Add(button);

            InitializeComponent();
        }

        void gomblenyomas(object sender, EventArgs e)
        {
            Button button = sender as Button;

            Random rand = new Random();
            button.Location = new Point(rand.Next(0, Width - button.Width), rand.Next(0, Height - button.Height));

            Button newButton = new Button();
            newButton.Text = "hello";
            newButton.Location = new Point(rand.Next(0, Width - button.Width), rand.Next(0, Height - button.Height));
            newButton.Size = button.Size;
            newButton.Click += gomblenyomas;
            this.Controls.Add(newButton);
        }
    }
}
