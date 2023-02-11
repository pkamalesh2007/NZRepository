using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

byte[] key = new byte[32];
using (var randomNumberGenerator = new RNGCryptoServiceProvider())
{
    randomNumberGenerator.GetBytes(key);
}

// Create a SymmetricSecurityKey from the random key
SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

Console.WriteLine(securityKey.ToString());//EG_mNJVLGjEMf_YkxKUSFRmOxy0ARVHE54YzxDXOJw4
