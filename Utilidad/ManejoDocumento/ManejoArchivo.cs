namespace Utilidad.ManejoDocumento
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Permite la manipulacion de archivos
    /// </summary>
    public class ManejoArchivo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo">Información del archivo</param>
        /// <param name="ruta">ruta donde se guarda el archivo</param>
        public void GuardarArchivo(Archivo archivo)
        {
            try
            {
                if (!Directory.Exists(archivo.Ruta))
                {
                    DirectoryInfo di = Directory.CreateDirectory(archivo.Ruta);
                }

                using (FileStream Archivo = new FileStream($"{archivo.Ruta}/{archivo.Nombre}.{archivo.Extension}", FileMode.OpenOrCreate))
                {
                    for (int i = 0; i < archivo.Informacion.Length; i++)
                    {
                        Archivo.WriteByte(archivo.Informacion[i]);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            finally { }
        }

        /// <summary>
        /// Method to list the files of one folder 
        /// </summary>
        /// <param name="path">Value of the route where needs to get the files</param>
        /// <returns>fileNames, array with the names of files in the folder</returns>

        public List<string> ListFiles(string path)
        {

            List<string> fileNames = new List<string>();

            if (Directory.Exists(path))
            {
                string[] fileEntries = Directory.GetFiles(path + "/");
                string[] directoryEntries = Directory.GetDirectories(path + "/");
                List<string> fileDirectoryNames = new List<string>();
                string localPath = string.Empty;
                string nameFile = string.Empty;
                string extensionFile = string.Empty;
                int counter = 0;
                if (fileEntries.LongLength > 0)
                {
                    foreach (string pathName in fileEntries)
                    {
                        if (extensionFile != "db")
                        {
                            fileNames.Add(pathName);
                        }

                        counter++;
                    }
                }

                if (directoryEntries.LongLength > 0)
                {
                    foreach (string pathName in directoryEntries)
                    {
                        if (Directory.Exists(pathName))
                        {
                            fileDirectoryNames = this.ListFiles(pathName);
                            foreach (string filesNames in fileDirectoryNames)
                            {
                                fileNames.Add(filesNames);
                            }
                        }
                    }
                }
            }

            return fileNames;
        }

        public bool SublirArchivos(List<Archivo> list, int id)
        {
            try
            {
                list.ForEach(item =>
                   {
                       item.Ruta = $"{item.Ruta}/{id}";

                       this.GuardarArchivo(item);
                   });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
