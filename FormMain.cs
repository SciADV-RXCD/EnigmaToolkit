using EnigmaToolkit.Properties;
using System.Diagnostics;
using System.Drawing.Text;
using System.Net;
using System.Reflection;

namespace EnigmaToolkit
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            label1.Text = $"Enigma Toolkit\nv{Application.ProductVersion}";
            progressBar1.Visible = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
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
                File.Exists($@"{AppContext.BaseDirectory}\\Tools\\tex2dds.exe")
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

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectDATArchive = new OpenFileDialog
            {
                Title = "Select DAT Archive",
                Filter = "DAT Archive (GxArchivedFile*.dat)|GxArchivedFile*.dat",
                RestoreDirectory = true
            };

            if (SelectDATArchive.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = SelectDATArchive.FileName;
                textBox2.Text = SelectDATArchive.FileName + "_extracted";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectExtractedDATArchiveFolder = new FolderBrowserDialog
            {
                Description = "Select Extracted DAT Archive Folder",
                ShowNewFolderButton = true
            };

            if (SelectExtractedDATArchiveFolder.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = SelectExtractedDATArchiveFolder.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Extract Button
            Process ExtractDATArchive = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\extract_dat.exe",
                    Arguments = textBox1.Text + " -o " + textBox2.Text,
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };
            ExtractDATArchive.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Repack Button
            Process RepackDATArchive = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\replace_dat.exe",
                    Arguments = textBox1.Text + " " + textBox2.Text + " -o " + textBox1.Text + "_NEW",
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };
            RepackDATArchive.Start();
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
                    new System.Uri("https://cdn.discordapp.com/attachments/844635048745369611/1409140663995596890/ExternalToolset.zip?ex=68ac4c02&is=68aafa82&hm=cfeda2977916cc479610bd8f9feb24bae99a7e3568c6f755d9233c5da4748fa3&"),
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
