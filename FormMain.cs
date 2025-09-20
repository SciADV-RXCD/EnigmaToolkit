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
            progressBar1.Visible = false;

            DebugToolkitVersion();
            ReleaseToolkitVersion();
        }

        [ConditionalAttribute("DEBUG")]
        public void DebugToolkitVersion()
        {
            label1.Text = $"Enigma Toolkit\nv{Application.ProductVersion}";
        }

        [ConditionalAttribute("RELEASE")]
        public void ReleaseToolkitVersion()
        {
            label1.Text = $"Enigma Toolkit\nv1.0.1";
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
                if (SelectExtractedDATArchiveFolder.SelectedPath.Contains("GxArchivedFile") && SelectExtractedDATArchiveFolder.SelectedPath.Contains(".dat_extracted"))
                {
                    textBox2.Text = SelectExtractedDATArchiveFolder.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Please select the folder with the same name as the original .DAT Archive and the suffix '_extracted'.");
                    textBox2.Text = "";
                }
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

        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectDATArchiveBatch = new FolderBrowserDialog
            {
                Description = "Select DAT Archive Folder for Batch Extract",
                ShowNewFolderButton = false
            };
            if (SelectDATArchiveBatch.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(SelectDATArchiveBatch.SelectedPath, "GxArchivedFile*.dat");
                foreach (string DATArchive in files)
                {
                    Process ExtractDATArchiveBatch = new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = $@"{AppContext.BaseDirectory}\\Tools\\extract_dat.exe",
                            Arguments = DATArchive + " -o " + DATArchive + "_extracted",
                            WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                        }
                    };
                    ExtractDATArchiveBatch.Start();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectDATArchiveBatch = new FolderBrowserDialog
            {
                Description = "Select DAT Archive Folder for Batch Extract",
                ShowNewFolderButton = false
            };
            if (SelectDATArchiveBatch.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(SelectDATArchiveBatch.SelectedPath, "GxArchivedFile*.dat");
                foreach (string DATArchive in files)
                {
                    Process ExtractDATArchiveBatch = new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = $@"{AppContext.BaseDirectory}\\Tools\\replace_dat.exe",
                            Arguments = DATArchive + " " + DATArchive + "_extracted" + " -o " + DATArchive + "_NEW",
                            WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                        }
                    };
                    ExtractDATArchiveBatch.Start();
                }
            }
        }

        [ConditionalAttribute("DEBUG")]
        public void TestMenu()
        {
            FormMainRegrade testStuff = new FormMainRegrade();
            testStuff.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TestMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectTEXTexture = new OpenFileDialog
            {
                Title = "Select TEX Texture",
                Filter = "TEX Texture (*.tex)|*.tex",
                RestoreDirectory = true
            };

            if (SelectTEXTexture.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = SelectTEXTexture.FileName;
                textBox5.Text = SelectTEXTexture.FileName;

                if (textBox5.Text.Contains(".tex"))
                {
                    textBox5.Text = textBox5.Text.Replace(".tex", ".dds");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectDDSTexture = new OpenFileDialog
            {
                Title = "Select DDS Texture",
                Filter = "DDS Texture (*.dds)|*.dds",
                RestoreDirectory = true
            };

            if (SelectDDSTexture.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = SelectDDSTexture.FileName;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Process ConvertTEXtoDDS = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\tex2dds.exe",
                    Arguments = textBox6.Text,
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertTEXtoDDS.Start();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Process ConvertDDStoTEX = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\dds2tex.exe",
                    Arguments = textBox5.Text,
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertDDStoTEX.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectTEXTextureBatch = new FolderBrowserDialog
            {
                Description = "Select the Folder containing your .tex Files",
                ShowNewFolderButton = false
            };
            if (SelectTEXTextureBatch.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(SelectTEXTextureBatch.SelectedPath, "*.tex");
                foreach (string TEXFile in files)
                {
                    Process ConvertTEXtoDDSBatch = new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = $@"{AppContext.BaseDirectory}\\Tools\\tex2dds.exe",
                            Arguments = TEXFile,
                            WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                        }
                    };
                    ConvertTEXtoDDSBatch.Start();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectDDSTextureBatch = new FolderBrowserDialog
            {
                Description = "Select the Folder containing your .dds Files",
                ShowNewFolderButton = false
            };
            if (SelectDDSTextureBatch.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(SelectDDSTextureBatch.SelectedPath, "*.dds");
                foreach (string DDSFile in files)
                {
                    Process ConvertDDStoTEXBatch = new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = $@"{AppContext.BaseDirectory}\\Tools\\dds2tex.exe",
                            Arguments = DDSFile,
                            WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                        }
                    };
                    ConvertDDStoTEXBatch.Start();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectTIDTexture = new OpenFileDialog
            {
                Title = "Select TID Texture",
                Filter = "TID Texture (*.tid)|*.tid",
                RestoreDirectory = true
            };

            if (SelectTIDTexture.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = SelectTIDTexture.FileName;
                textBox3.Text = SelectTIDTexture.FileName;

                if (textBox3.Text.Contains(".tid"))
                {
                    textBox3.Text = textBox3.Text.Replace(".tid", ".png");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectPNGTexture = new OpenFileDialog
            {
                Title = "Select PNG Texture",
                Filter = "PNG Texture (*.png)|*.png",
                RestoreDirectory = true
            };

            if (SelectPNGTexture.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = SelectPNGTexture.FileName;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Process ConvertTIDtoPNG = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\dds2png.exe",
                    Arguments = textBox4.Text,
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertTIDtoPNG.Start();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string ddsFilePath = textBox3.Text;
            string ddsFilePathFinal = ddsFilePath.Replace(".png", ".dds");

            Process ConvertDDStoTID = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\dds2tid.exe",
                    Arguments = ddsFilePathFinal,
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertDDStoTID.Start();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectGSTRScript = new OpenFileDialog
            {
                Title = "Select GSTR Script",
                Filter = "GSTR Script (*.gstr)|*.gstr",
                RestoreDirectory = true
            };

            if (SelectGSTRScript.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = SelectGSTRScript.FileName;
                textBox7.Text = SelectGSTRScript.FileName + ".txt";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectDecompiledGSTRScript = new OpenFileDialog
            {
                Title = "Select Decompiled GSTR Script",
                Filter = "Decompiled GSTR Script (*.gstr.txt)|*.gstr.txt",
                RestoreDirectory = true
            };

            if (SelectDecompiledGSTRScript.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = SelectDecompiledGSTRScript.FileName;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("-ft DDS -f BC1_UNORM_SRGB " + textBox3.Text + " -o " + Path.GetDirectoryName(textBox3.Text));

            Process ConvertPNGtoDDS = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\texconv.exe",
                    Arguments = "-ft DDS -f BC1_UNORM_SRGB " + textBox3.Text + " -o " + Path.GetDirectoryName(textBox3.Text),
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertPNGtoDDS.Start();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Process ConvertGSTRtoTXT = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\pickup_text.exe",
                    Arguments = "--utf8 -N " + textBox8.Text,
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertGSTRtoTXT.Start();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Process ConvertTXTtoGSTR = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\modify_text.exe",
                    Arguments = "--utf8 -N " + textBox8.Text + " " + textBox7.Text + " -o " + $"{textBox8.Text}_NEW",
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertTXTtoGSTR.Start();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectGBINScript = new OpenFileDialog
            {
                Title = "Select GBIN Script",
                Filter = "GBIN Script (*.gbin)|*.gbin",
                RestoreDirectory = true
            };

            if (SelectGBINScript.ShowDialog() == DialogResult.OK)
            {
                textBox10.Text = SelectGBINScript.FileName;
                textBox9.Text = SelectGBINScript.FileName + ".txt";
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectDecompiledGBINScript = new OpenFileDialog
            {
                Title = "Select Decompiled GBIN Script",
                Filter = "Decompiled GBIN Script (*.gbin.txt)|*.gbin.txt",
                RestoreDirectory = true
            };

            if (SelectDecompiledGBINScript.ShowDialog() == DialogResult.OK)
            {
                textBox9.Text = SelectDecompiledGBINScript.FileName;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Process ConvertGBINtoTXT = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\pickup_text.exe",
                    Arguments = "--utf8 -N " + textBox10.Text,
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertGBINtoTXT.Start();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Process ConvertTXTtoGBIN = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\modify_text.exe",
                    Arguments = "--utf8 -N " + textBox10.Text + " " + textBox9.Text + " -o " + $"{textBox10.Text}_NEW",
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertTXTtoGBIN.Start();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog SelectCL3Archive = new OpenFileDialog
            {
                Title = "Select CL3 Archive",
                Filter = "DAT Archive (*.cl3)|*.cl3",
                RestoreDirectory = true
            };

            if (SelectCL3Archive.ShowDialog() == DialogResult.OK)
            {
                textBox12.Text = SelectCL3Archive.FileName;
                textBox11.Text = SelectCL3Archive.FileName + "_extracted";
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectExtractedCL3ArchiveFolder = new FolderBrowserDialog
            {
                Description = "Select Extracted CL3 Archive Folder",
                ShowNewFolderButton = true
            };

            if (SelectExtractedCL3ArchiveFolder.ShowDialog() == DialogResult.OK)
            {
                if (SelectExtractedCL3ArchiveFolder.SelectedPath.Contains(".cl3_extracted"))
                {
                    textBox11.Text = SelectExtractedCL3ArchiveFolder.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Please select the folder with the same name as the original .CL3 Archive and the suffix '_extracted'.");
                    textBox11.Text = "";
                }
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Process ExtractCL3Archive = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\extract_cl3.exe",
                    Arguments = textBox12.Text + " -o " + textBox11.Text,
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };
            ExtractCL3Archive.Start();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Process RepackCL3Archive = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\replace_cl3.exe",
                    Arguments = textBox12.Text + " " + textBox11.Text + " -o " + textBox12.Text + "_NEW",
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };
            RepackCL3Archive.Start();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectMainDATScript = new OpenFileDialog
            {
                Title = "Select main.DAT Script",
                Filter = "main.DAT Script (*main.DAT)|*main.DAT",
                RestoreDirectory = true
            };

            if (SelectMainDATScript.ShowDialog() == DialogResult.OK)
            {
                textBox14.Text = SelectMainDATScript.FileName;
                textBox13.Text = SelectMainDATScript.FileName + ".txt";
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectDecompiledMainDATScript = new OpenFileDialog
            {
                Title = "Select Decompiled main.DAT Script",
                Filter = "Decompiled main.DAT Script (*main.DAT.txt)|*main.DAT.txt",
                RestoreDirectory = true
            };

            if (SelectDecompiledMainDATScript.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = SelectDecompiledMainDATScript.FileName;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Process ConvertMainDATtoTXT = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\pickup_text.exe",
                    Arguments = "--utf8 -N " + textBox14.Text,
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertMainDATtoTXT.Start();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Process ConvertTXTtoMainDAT = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{AppContext.BaseDirectory}\\Tools\\modify_text.exe",
                    Arguments = "--utf8 -N " + textBox14.Text + " " + textBox13.Text + " -o " + $"{textBox14.Text}_NEW",
                    WorkingDirectory = @$"{AppContext.BaseDirectory}\\Tools",
                }
            };

            ConvertTXTtoMainDAT.Start();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Because idk how, if you want to convert a PNG back to TID, you first need to 'Convert to DDS' and then 'Convert to TID'.");
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

            OpenDocumentation.Start();
        }
    }
}
