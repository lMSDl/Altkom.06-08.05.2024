using Models;
using Services.InFile.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InFile
{
    public class SymmetricFileEntityService<T> : FileEntityService<T> where T : Entity
    {
        private string _password;
        private SymmetricEncryption _encryption;
        public SymmetricFileEntityService(string filePath, string password)
        {
            FilePath = filePath;
            _password = password;
            _encryption = new SymmetricEncryption("alamakota");
            LoadFromFile();
        }

        protected override void WriteToFile(string json)
        {
            byte[] data = _encryption.Encrypt(json, _password);

            File.WriteAllBytes(FilePath, data);
        }

        protected override string? ReadFromFile()
        {
            byte[] data = File.ReadAllBytes(FilePath);
            string json = _encryption.DecryptToString(data, _password);
            return json;
        }
    }
}
