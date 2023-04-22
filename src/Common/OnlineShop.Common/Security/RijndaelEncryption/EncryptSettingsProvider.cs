using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace OnlineShop.Common.Security.RijndaelEncryption
{
    public class EncryptSettingsProvider : IEncryptSettingsProvider
    {
        private readonly string _encryptionPrefix;
        private readonly byte[] _encryptionKey;


        public EncryptSettingsProvider(EncryptionOptions options)
        {
            //read settings from configuration
            var useHashingString = options.UseHashingForEncryption;
            var useHashing = string.Compare(useHashingString, "false", StringComparison.OrdinalIgnoreCase) != 0;
            _encryptionPrefix = options.UseHashingForEncryption;
            string key = options.UseHashingForEncryption;

            if (useHashing)
            {
                SHA256Managed hash = new();
                _encryptionKey = hash.ComputeHash(Encoding.UTF8.GetBytes(key));
                hash.Clear();
                hash.Dispose();
            }
            else
            {
                _encryptionKey = Encoding.UTF8.GetBytes(key);
            }
        }

        #region ISettingsProvider Members

        public byte[] EncryptionKey
        {
            get
            {
                return _encryptionKey;
            }
        }

        public string EncryptionPrefix
        {
            get { return _encryptionPrefix; }
        }

        #endregion

    }
}
