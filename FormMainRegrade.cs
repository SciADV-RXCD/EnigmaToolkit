using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnigmaToolkit
{
    public partial class FormMainRegrade : Form
    {
        public FormMainRegrade()
        {
            InitializeComponent();
            progressBar1.Visible = false;

            DebugToolkitVersion();
            ReleaseToolkitVersion();
        }

        [ConditionalAttribute("DEBUG")]
        public void DebugToolkitVersion()
        {
            label1.Text = $"Enigma Toolkit\n[Regrade]\nv{Application.ProductVersion}";
        }

        [ConditionalAttribute("RELEASE")]
        public void ReleaseToolkitVersion()
        {
            label1.Text = $"Enigma Toolkit\n[Regrade]\nv2.0.1";
        }

        private void FormMainRegrade_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("Tools"))
            {
                Directory.CreateDirectory("Tools");
            }

            if (File.Exists($@"{AppContext.BaseDirectory}\\Tools\\dds2png.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\dds2tex.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\dds2tid.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\extract_cl3.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\extract_dat.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\modify_text.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\pickup_text.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\png2tex.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\replace_cl3.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\replace_dat.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\tex2dds.exe") &&
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\texconv.exe")
                )
            {
                button5.Enabled = false;
                button5.Text = "Installed";
            }
            else
            {
                button5.Enabled = true;
                button5.Text = "Install Tools";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDERQRegrade DERQRegrade = new FormDERQRegrade();
            DERQRegrade.ShowDialog();
            this.Dispose();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Process OpenDocumentation = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "https://docs.google.com/document/d/1AVqnTxH1n66ATuarwuVVEqYiJImpsO3sopChHfH0Iew",
                    UseShellExecute = true
                }
            };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            button5.Enabled = false;
            button5.Text = "Downloading...";

            using (WebClient wc_locale = new WebClient())
            {
                wc_locale.DownloadProgressChanged += wc_locale_DownloadProgressChanged;
                wc_locale.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://github.com/SciADV-RXCD/EnigmaToolkit/releases/download/0.0.0/ExternalToolset.zip"),
                    // Param2 = Path to save
                    AppContext.BaseDirectory + "ExternalToolset.zip"
                );
                wc_locale.DownloadFileCompleted += (s, ev) =>
                {
                    if (ev.Error != null)
                    {
                        MessageBox.Show("Error downloading file: " + ev.Error.Message);
                    }
                    else
                    {
                        // Optionally, you can extract the downloaded zip file here
                        System.IO.Compression.ZipFile.ExtractToDirectory(AppContext.BaseDirectory + "ExternalToolset.zip", AppContext.BaseDirectory + "Tools");
                        System.IO.File.Delete(AppContext.BaseDirectory + "ExternalToolset.zip"); // Delete the zip file after extraction
                        button5.Enabled = false;
                        button5.Text = "Installed";
                        progressBar1.Visible = false;
                    }
                };
            }
        }

        void wc_locale_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
