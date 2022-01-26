using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleDriveUploadFiles
{
    internal class Service
    {
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
    }
}
