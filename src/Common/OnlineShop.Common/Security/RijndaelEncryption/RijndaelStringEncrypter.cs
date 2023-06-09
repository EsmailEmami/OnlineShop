﻿using System.Security.Cryptography;
using System.Text;

namespace OnlineShop.Common.Security.RijndaelEncryption
{
    public class RijndaelStringEncrypter : IRijndaelStringEncrypter
    {
        private RijndaelManaged _encryptionProvider;
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public RijndaelStringEncrypter(IEncryptSettingsProvider settings, string key)
        {
            _encryptionProvider = new RijndaelManaged();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            var derivedbytes = new Rfc2898DeriveBytes(settings.EncryptionKey, keyBytes, 3);
            _key = derivedbytes.GetBytes(_encryptionProvider.KeySize / 8);
            _iv = derivedbytes.GetBytes(_encryptionProvider.BlockSize / 8);
        }

        #region IEncryptString Members

        public string Encrypt(string value)
        {
            var valueBytes = Encoding.UTF8.GetBytes(value);

            ICryptoTransform _cryptoTransform = _encryptionProvider.CreateEncryptor(_key, _iv);

            var encryptedBytes = _cryptoTransform.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
            var encrypted = Convert.ToBase64String(encryptedBytes);

            return encrypted;
        }

        public string Decrypt(string value)
        {
            var valueBytes = Convert.FromBase64String(value);

            ICryptoTransform cryptoTransform = _encryptionProvider.CreateDecryptor(_key, _iv);

            var decryptedBytes = cryptoTransform.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
            var decrypted = Encoding.UTF8.GetString(decryptedBytes);

            return decrypted;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            //if (_cryptoTransform != null)
            //{
            //    _cryptoTransform.Dispose();
            //    _cryptoTransform = null;
            //}

            if (_encryptionProvider != null)
            {
                _encryptionProvider.Clear();
                _encryptionProvider.Dispose();
                _encryptionProvider = null;
            }
        }

        #endregion
    }
}
