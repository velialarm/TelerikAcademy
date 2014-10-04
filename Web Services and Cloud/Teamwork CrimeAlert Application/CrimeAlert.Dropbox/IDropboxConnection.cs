using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAlert.Dropbox
{
    /// <summary>
    /// Part of Requirements for the RESTful API 
    /// DROPBOX - place to storage images files
    /// </summary>
    public interface IDropboxConnection
    {
        bool WriteImage(string path, string fileName, byte[] imageFile);

        byte[] GetImageFile(string folderPath, string fileName);
    }
}
