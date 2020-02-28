using System.Windows.Forms;

namespace WindowsSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            labelText.Text = testText.Text + ".";
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
        }
    }
}