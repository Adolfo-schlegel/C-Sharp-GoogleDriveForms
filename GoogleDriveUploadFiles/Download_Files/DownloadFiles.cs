using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Download;
using Google.Apis.Drive.v3;

namespace GoogleDriveUploadFiles.Download_Files
{
    public partial class DownloadFiles : Form
    {
        public string fileid = "";
        public string folderid = "";
        public DownloadFiles()
        {
            InitializeComponent();
        }

        private void DownloadFolder_Click(object sender, EventArgs e)
        {
            string fileid = Form1.getFolderId(comboBox1.Text);

            DriveService driveService = Form1.getService();           
            
            var stream = new System.IO.MemoryStream();

            driveService.Files.Get(fileid).Download(stream);
           
        }

        private void DownloadFiles_Load(object sender, EventArgs e)
        {
            
            var files = Form1.getFileList();
            //relleno los comobox filtrando por Mimetype de carpeta y archivos
            //cb1
            foreach (var file in files)
            {
                if (file.MimeType == "application/vnd.google-apps.folder")  
                    comboBox1.Items.Add(file.Name);               
            }

            //cb2
            foreach (var file in files)
            {
                if(file.MimeType != "application/vnd.google-apps.folder")
                    comboBox2.Items.Add(file.Name);
            }
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            string saveTo = @"C:\Users\adolf\OneDrive\Escritorio\Captura de pantalla 2021-12-22 003056.png"; //path

            var stream = new System.IO.MemoryStream();  // instancia temporal en memoria del archivo

           // Google.Apis.Drive.v3.Data.File file = Form1.getFileid(comboBox1.Text);        //agarro mi file por nombre   
            DriveService driveService = GoogleDriveUploadFiles.Service.getService();// agarro mi servicio

            var respuesta = driveService.Files.Get(Form1.getFileid(comboBox2.Text)); //descargo mi archivo

                                //verifico mi respuesta
            respuesta.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                        case Google.Apis.Download.DownloadStatus.Downloading:
                        {
                            MessageBox.Show(progress.BytesDownloaded.ToString());
                            break;
                        }
                        case Google.Apis.Download.DownloadStatus.Completed:
                        {
                           // MessageBox.Show("el archivo se descargo");//si el archivo se descargo, guardar el archivo
                            SaveStream(stream, saveTo);// si el archivo se completo, procedo a hacer una creacion de un archivo
                            MessageBox.Show("el archivo se descargo");//si el archivo se descargo, guardar el archivo
                            break;
                        }
                        case Google.Apis.Download.DownloadStatus.Failed:
                        {
                            MessageBox.Show("Fallo la descarga, vuelva a intentar");
                            break;
                        }
                }
            };
            respuesta.Download(stream);
        }
       
        public static void SaveStream(System.IO.MemoryStream stream, string path)
        {
            //1) crear archivo
            //2) 

            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {

                stream.WriteTo(file);
            }
            //System.IO.FileStream file = new System.IO.FileStream(saveTo, FileMode.Create, FileAccess.ReadWrite); 
            // stream.WriteTo(file);


            /*
                //1. Provide early notification that the user does not have permission to write.
             FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, saveTo);
             if (!SecurityManager.IsGranted(writePermission))
             {
                 throw new SecurityException("acceso no garantizado");
             }

             try 
             { 
                   using (FileStream fstream = new FileStream(saveTo, FileMode.Create, FileAccess.Write)) 
                   using (TextWriter writer = new StreamWriter(fstream)) 
                   { 
                       writer.WriteLine("sometext"); 
                   } 
             } 
             catch (UnauthorizedAccessException ex) 
             {
               MessageBox.Show(ex.Message);
               //No permission. 
               //Either throw an exception so this can be handled by a calling function 
               //or inform the user that they do not have permission to write to the folder and return.
             }

        */






        }
    }
}
