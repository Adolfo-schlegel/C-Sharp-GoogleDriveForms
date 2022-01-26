using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Download;
using Google.Apis.Auth;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3.Data;
using System.Threading;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleDriveUploadFiles
{
    public partial class Form1 : Form
    {
        DriveService servico = new DriveService();

        public Form1()
        {
            InitializeComponent();
        }

        public static DriveService getService()
        {       
            //Credenciales creadas en GoolgeDriveApiv2
            var clienteId = "260028708618-mssuc80o0rdt0k318p5c49l7mntjki6b.apps.googleusercontent.com";
            var clienteSecret = "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";

            //basicamente scopes son los alcances que quiero que tenga esta autorizacion,se pueden agregar mas autorizaciones si se desea
            string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile };

            //Creacion de acceso y refrezco del token de acceso (dura 1 hora)
            UserCredential Credential;

            string token = @"C:\Users\adolf\AppData\Roaming\MyAppsToken";

            Credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clienteId,
                ClientSecret = clienteSecret                                         //"MyAppsToken" acompañado de su metodo basicamnte es el directorio %appdata% donde se almacenara el token 
            }, scopes, Environment.UserName, CancellationToken.None, new FileDataStore(token, true)).Result;

            Console.WriteLine("El Token se guardo en " + token);

            //Hasta ahora estuvimos autorizandonos con las credenciales en OAuth 2.0 la cual nos arrojara el token de acceso
            //----------------------Conectando con el servicio y pasandole las credenciales verificadas--------------------
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = Credential,
                ApplicationName = "Google Drive VB Dot Net"
            });

            return service;
        }
      
        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Ruta.Text = fileDialog.FileName;
            }
        }

        private static string GetMimeType(string fileName)
        {
            //esta pequeña funcion es la encargada de saber cual es el tipo del archivo,
            string mimeType = "application/unknown"; //ejemplo "application/txt", es lo que deberia de retornarme si es un txt
            string ext = System.IO.Path.GetExtension(fileName).ToLower();

            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();

            System.Diagnostics.Debug.WriteLine(mimeType);

            return mimeType;
        }

        private void Subir_Click(object sender, EventArgs e)
        {
            DriveService service = getService();
            //puedo subir un archivo y pasarle mis propias propiedades a travez del objeto file
            // o
            //puedo utilizar System.IO.Path y absorver las propiedades de un archivo existente en el sistema 


            string folderid = getFolderId(comboBox1.Text);
          //string desc = "";

            if (System.IO.File.Exists(Ruta.Text))
            {
                try
                {
                    Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                    body.Name = System.IO.Path.GetFileName(Ruta.Text);//nombre del archivo
                    //body.Description = desc;//descripcion
                    body.MimeType = GetMimeType(Ruta.Text);//tipo de archivo
                    body.Parents = new List<string> { folderid };//guarda el archivo en una carpeta, por defecto te arroja el archivo a "mi unidad"


                    byte[] bytearray = System.IO.File.ReadAllBytes(Ruta.Text);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(bytearray);

                    var request = service.Files.Create(body, stream, body.MimeType);//creo el archivo

                    var result = request.Upload();//lo subo
                    MessageBox.Show("Espere un momento...");
                    MessageBox.Show( result.Status + " :)");//retorno el resultado
                }
                catch (Exception error)
                {
                    MessageBox.Show("ERROR \n" + error.Message);
                }
            }
            else
            {
                MessageBox.Show("El archivo no existe, o lo tiene abierto");
            }

        }

        public static List<Google.Apis.Drive.v3.Data.File> getFileList()
        {
            DriveService driveService = getService();
            List<Google.Apis.Drive.v3.Data.File> result = new List<Google.Apis.Drive.v3.Data.File>();

            Google.Apis.Drive.v3.FilesResource.ListRequest Request = driveService.Files.List();
            do
            {
                try
                {
                    FileList files = Request.Execute();

                    result.AddRange(files.Files);

                    Request.PageToken = files.NextPageToken;


                }
                catch (Exception ex)
                {
                    Console.WriteLine("error \n" + ex.Message);
                }
            }
            while (!String.IsNullOrEmpty(Request.PageToken));
   
            return result;
        }
        
        public static string getFileid(string name)
        {
            try
            {
                var files = getFileList();

                for(int i =0; i<files.Count -1; i++)
                {
                    if(files[i].MimeType != "application/vnd.google-apps.folder")
                        if(files[i].Name == name)
                            return files[i].Id;
                }
            }
            catch(Exception ex)
            {
                return "error" + ex.Message;
            }

            return "false";
        }
        public static string getFolderId(string name)
        {
            try
            {
                var folders = getFileList();
                for (int i = 0; i < folders.Count - 1; i++)
                {
                    if (folders[i].MimeType == "application/vnd.google-apps.folder")
                    {
                        if (folders[i].Name == name)
                        {
                            return folders[i].Id;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error \n" + ex.Message);
                
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var folders = getFileList();
            for(int i =0; i<folders.Count -1; i++)
            {
                if(folders[i].MimeType == "application/vnd.google-apps.folder")
                comboBox1.Items.Add(folders[i].Name);
            }
            
            //File file = service.Files.Get(comboBox1.SelectedItem).Execute();
        }

        private void createFolder_Click(object sender, EventArgs e)
        {
            GoogleDriveUploadFiles.Create_Folder.Create_Folder create_Folder = new GoogleDriveUploadFiles.Create_Folder.Create_Folder();
            create_Folder.ShowDialog();
            comboBox1.Items.Clear();
            Form1_Load(null, null);
        }

        private void Download_files_Click(object sender, EventArgs e)
        {
            Download_Files.DownloadFiles downloadFiles = new Download_Files.DownloadFiles();

            downloadFiles.ShowDialog();
        }

       
    }
}
