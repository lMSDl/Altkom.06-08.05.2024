using Models;
using Services.InFile.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InFile
{
    public class AsymmetricFileEntityService<T> : FileEntityService<T> where T : Entity
    {
        private string _certName;
        private AsymmetricEncryption _encryption;
        public AsymmetricFileEntityService(string filePath, string certName)
        {
            FilePath = filePath;
            _certName = certName;
            _encryption = new AsymmetricEncryption();
            LoadFromFile();
        }

        protected override void WriteToFile(string json)
        {
            byte[] data = _encryption.Encrypt(json, _certName);

            File.WriteAllBytes(FilePath, data);
        }

        protected override string? ReadFromFile()
        {
            byte[] data = File.ReadAllBytes(FilePath);
            string json = _encryption.DecryptToString(data, _certName);
            return json;
        }
    }
}
