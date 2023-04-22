namespace OnlineShop.Common.Security.RijndaelEncryption
{
    public class EncryptionOptions
    {
        public string UseHashingForEncryption { get; set; }
        public string EncryptionPrefix { get; set; } = "encryptedHidden_";
        public string EncryptionKey { get; set; }
    }
}
