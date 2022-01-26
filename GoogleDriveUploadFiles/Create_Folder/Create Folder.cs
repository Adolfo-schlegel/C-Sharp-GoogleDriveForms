using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;

namespace GoogleDriveUploadFiles.Create_Folder
{
    public partial class Create_Folder : Form
    {
        public Create_Folder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DriveService driveService = GoogleDriveUploadFiles.Service.getService();

            Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
            body.Name = textBox1.Text;
            body.MimeType = "application/vnd.google-apps.folder";

            var command = driveService.Files.Create(body);
            var file = command.Execute();
         
            MessageBox.Show("Carpeta creada con exito id ( " + file.Id + " )");

            this.Close();
        }
    }
}
