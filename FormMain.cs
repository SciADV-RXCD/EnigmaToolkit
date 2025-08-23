using EnigmaToolkit.Properties;
using System.Drawing.Text;
using System.Reflection;

namespace EnigmaToolkit
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            label1.Text = $"Enigma Toolkit\nv{Application.ProductVersion}";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }
    }
}
