using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.InFile.Encryption
{
    public class AsymmetricEncryption
    {
        public byte[] Encrypt(string stringToEncrypt, string certName)
        {
            return Encrypt(Encoding.Default.GetBytes(stringToEncrypt), certName);
        }

        public byte[] Encrypt(byte[] bytesToEncrypt, string certName)
        {
            var cert = GetCert(certName);
            var provider = cert.PublicKey.Key;

            using (var algorithm = new AesManaged())
            using (var outStream = new MemoryStream())
            using (var encryptor = algorithm.CreateEncryptor())
            {
                var keyFormatter = new RSAPKCS1KeyExchangeFormatter(provider);
                var encyptedKey = keyFormatter.CreateKeyExchange(algorithm.Key, algorithm.GetType());

                var keyLength = BitConverter.GetBytes(encyptedKey.Length);
                var ivLength = BitConverter.GetBytes(algorithm.IV.Length);

                outStream.Write(keyLength, 0, 4);
                outStream.Write(ivLength, 0, 4);
                outStream.Write(encyptedKey, 0, encyptedKey.Length);
                outStream.Write(algorithm.IV, 0, algorithm.IV.Length);

                using (var encrypt = new CryptoStream(outStream, encryptor, CryptoStreamMode.Write))
                {
                    encrypt.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                    encrypt.FlushFinalBlock();

                    return outStream.ToArray();
                }
            }
        }
        public string DecryptToString(byte[] bytesToDecrypt, string password)
        {
            return Encoding.Default.GetString(Decrypt(bytesToDecrypt, password));
        }
        public byte[] Decrypt(byte[] bytesToDecrypt, string certName)
        {
            var cert = GetCert(certName);
            var provider = cert.GetRSAPrivateKey();
            using (var algorithm = new AesManaged())
            using (var inStream = new MemoryStream(bytesToDecrypt))
            {
                var keyLength = new byte[4];
                var ivLength = new byte[4];
                inStream.Seek(0, SeekOrigin.Begin);

                inStream.Read(keyLength, 0, keyLength.Length);
                inStream.Read(ivLength, 0, ivLength.Length);
                var keyLengthInt = BitConverter.ToInt32(keyLength, 0);
                var ivLengthInt = BitConverter.ToInt32(ivLength, 0);

                var dataStartPosition = keyLengthInt + ivLengthInt + keyLength.Length + ivLength.Length;
                var dataSize = (int)inStream.Length - dataStartPosition;

                var key = new byte[keyLengthInt];
                var iv = new byte[ivLengthInt];
                var data = new byte[dataSize];

                inStream.Read(key, 0, keyLengthInt);
                inStream.Read(iv, 0, ivLengthInt);
                inStream.Read(data, 0, dataSize);

                var decryptedKey = provider.Decrypt(key, RSAEncryptionPadding.Pkcs1);

                using (var outStream = new MemoryStream())
                using (var decryptor = algorithm.CreateDecryptor(decryptedKey, iv))
                using (var decrypStream = new CryptoStream(outStream, decryptor, CryptoStreamMode.Write))
                {
                    decrypStream.Write(data, 0, data.Length);
                    decrypStream.FlushFinalBlock();

                    return outStream.ToArray();
                }

            }
        }

        private X509Certificate2? GetCert(string certName)
        {
            using (var store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadOnly);
                foreach (var cert in store.Certificates)
                {
                    if (cert.SubjectName.Name == certName)
                        return cert;
                }
            }
            return null;
        }
    }
}
