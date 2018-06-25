using HC128.Desktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HC128.Desktop
{
    public partial class FrmDecrypt : Form
    {
        //private static string IPRegex = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        private string pathFolder;
        private string pathFile;
        public FrmDecrypt()
        {
            InitializeComponent();
        }

        private async Task UpdateListFilesAsync()
        {
            List<string> ListFiles = await API.GetImageName(txtIPServer.Text);
            listFiles.Items.Clear();
            if(ListFiles != null)
            {
                foreach (string imageName in ListFiles)
                {
                    listFiles.Items.Add(imageName);
                }
            }
            else
            {
                ShowMessage("Error al conectarse con el servidor.", true);
            }
        }

        private bool BeforeDownloadFile()
        {
            // Errors list
            List<string> errors = new List<string>();

            // Validate IP Server
            //Regex regex = new Regex(IPRegex);
            var ipServer = txtIPServer.Text;
            if (ipServer.Length == 0)
                //if (!regex.IsMatch(ipServer))
                errors.Add("IP Invalida.");

            // Validate FileName
            var fileName = (string)listFiles.SelectedItem;
            if (fileName == null)
                errors.Add("Debe seleccionar un archivo.");

            // Validate FileName
            //var streamKey = txtStreamKey.Text;
            //if (streamKey.Length == 0)
            //    errors.Add("Debe insertar una Stream Key.");

            // Show messagebox
            if (errors.Count() > 0)
            {
                string message = String.Join("\n", errors);
                ShowMessage(message, true);
                return false;
            }
            return true;
        }

        private async Task DecryptFile()
        {
            ImgAPI imgApi = await API.GetImageDetail(txtIPServer.Text, listFiles.SelectedItem.ToString());
            
            if(imgApi != null)
            {
                Byte[] bytes = Convert.FromBase64String(imgApi.imageByteArray);

                //Desencripción:
                int i = 0, j = 0;
                UInt32[] llave = new UInt32[4];
                UInt32[] vectorinit = new UInt32[4];
                foreach (char x in txtKey.Text)
                {
                    llave[i] = UInt32.Parse(x.ToString());
                    i++;
                }

                foreach (char x in txtIV.Text)
                {
                    vectorinit[j] = UInt32.Parse(x.ToString());
                    j++;
                }
                Encript desencriptar = new Encript(llave, vectorinit);
                desencriptar.inicializacion();
                desencriptar.generateKeyStream((bytes.Length) / 4);

                Byte[] plaintext = desencriptar.generateCiphertext(bytes);

                Bitmap bitmap = ConvertImg.ToBitMap(plaintext);

                picBox.Image = bitmap;
            }
            else
            {
                ShowMessage("Error al descargar la imagen.", true);
            }
        }

        private void FrmDecrypt_Load(object sender, EventArgs e)
        {

        }

        private void btnDownloadImage_Click_1(object sender, EventArgs e)
        {
            // Save dialog para guardar archivo
            SaveFileDialog sf = new SaveFileDialog();
            // Filtros
            sf.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            // Escribe el nombre del archivo
            sf.FileName = listFiles.SelectedItem.ToString();
            // Muestra el dialog
            sf.ShowDialog();
            // Si existe ruta
            if(sf.FileName != null)
            {
                // busco el bitmap
                Bitmap imgOrigin = (Bitmap)picBox.Image;
                // Creo un nuevo bitmap. Si no hago eso, tira error
                Bitmap img = new Bitmap(imgOrigin);
                #region // Guardo archivo dependiendo la extensión
                var path = sf.FileName;
                var extensiones = path.Split('.');
                var extension = extensiones[extensiones.Count() - 1];
                switch (extension.ToLower())
                {
                    case "jpg":
                        img.Save(path, ImageFormat.Jpeg);
                        break;

                    case "jpeg":
                        img.Save(path, ImageFormat.Jpeg);
                        break;

                    case "bmp":
                        img.Save(path, ImageFormat.Bmp);
                        break;

                    case "png":
                        img.Save(path, ImageFormat.Png);
                        break;
                    default:
                        img.Save(path, ImageFormat.Jpeg);
                        break;
                }
                img.Dispose();
                #endregion
                
                pathFile = sf.FileName;
                pathFolder = sf.FileName.Replace(listFiles.SelectedItem.ToString(), "");
                btnAbrirCarpeta.Visible = true;
                btnAbrirImg.Visible = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateListFilesAsync();
        }

        private void btnDecryptImage_Click(object sender, EventArgs e)
        {
            var isValidated = BeforeDownloadFile();
            if (isValidated)
            {
                DecryptFile();
                btnDownloadImage.Enabled = true;
            }
        }

        private void btnDecryptImage_Click_1(object sender, EventArgs e)
        {
            var isValidated = BeforeDownloadFile();
            if (isValidated)
            {
                DecryptFile();
                btnDownloadImage.Enabled = true;
            }
        }

        private void ShowMessage(string message, bool isError = false)
        {
            string caption = "HC-128";
            if (isError)
                MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAbrirImg_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(pathFile);
        }

        private void btnAbrirCarpeta_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(pathFolder);
        }
    }
}
