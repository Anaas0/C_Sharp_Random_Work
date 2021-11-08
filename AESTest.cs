using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace AESTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AES test;
            string Password;
            byte [] CipherText;

            Password = Console.ReadLine();
            test = new AES(Password);
            CipherText = test.Encrypt();
            Console.WriteLine(CipherText);
            Password = test.Decrypt(CipherText);
            Console.WriteLine(Password);

        }
        class AES
        {
            private static string _Password;
            private static string _PlainText;
            static protected byte[] _Encrypted;
            private static byte[] _Key;
            private static byte[] _IV;

            public AES(string inPassword)
            {
                _Password = inPassword;
            }

            public byte[] Encrypt()
            {
                
                if (_Password == null || _Password.Length <= 0)
                    throw new ArgumentNullException("plainText");

                using (AesManaged AESEncyrpt = new AesManaged())
                {
                    AESEncyrpt.GenerateKey();
                    AESEncyrpt.GenerateIV();
                    _Key = AESEncyrpt.Key;
                    _IV = AESEncyrpt.IV;

                    ICryptoTransform TEncryptor = AESEncyrpt.CreateEncryptor(AESEncyrpt.Key, AESEncyrpt.IV);//decryptor for memory stream transform
                    using (MemoryStream MemStreamEnc = new MemoryStream())
                    {
                        using (CryptoStream CryStreamEnc = new CryptoStream(MemStreamEnc, TEncryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter StreamWEnc = new StreamWriter(CryStreamEnc))
                            {
                                StreamWEnc.Write(_Password);
                            }
                            _Encrypted = MemStreamEnc.ToArray();
                        }
                    }
                }

                return _Encrypted;
            }

            public string Decrypt(byte[] inCipherText)
            {
                if (inCipherText == null || inCipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");

                _PlainText = null;
                using (AesManaged AESmDecrypt = new AesManaged())
                {
                    AESmDecrypt.Key = _Key;
                    AESmDecrypt.IV = _IV;
                    ICryptoTransform TDecryptor = AESmDecrypt.CreateDecryptor(AESmDecrypt.Key, AESmDecrypt.IV);
                    using (MemoryStream MemStreamDecrypt = new MemoryStream(inCipherText))
                    {
                        using (CryptoStream CryStreamDecrypt = new CryptoStream(MemStreamDecrypt, TDecryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader StreamRDecrpt = new StreamReader(CryStreamDecrypt))
                            {
                                _PlainText = StreamRDecrpt.ReadToEnd();
                            }
                        }
                    }
                }
                return _PlainText;
            }
        }
    }

}
