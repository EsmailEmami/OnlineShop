﻿namespace OnlineShop.Common.Security.RijndaelEncryption
{
    public interface IEncryptSettingsProvider
    {
        byte[] EncryptionKey { get; }
        string EncryptionPrefix { get; }
    }
}
