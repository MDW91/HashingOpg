using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashingOpg
{
    class MACHandler
    {

        private HMAC myMAC;

        public MACHandler(string name)
        {


            if (name.CompareTo("SHA1") == 0)
            {
                myMAC = new System.Security.Cryptography.HMACSHA1();
            }
            if (name.CompareTo("SHA2") == 0)
            {
                myMAC = new System.Security.Cryptography.HMACSHA256();
            }
            if (name.CompareTo("MD5") == 0)
            {
                myMAC = new System.Security.Cryptography.HMACMD5();
            }


        }

        public bool CheckAuthenticity(byte[] mes, byte[] mac, byte[] key)
        {
            myMAC.Key = key;
            if (CompareByteArrays(myMAC.ComputeHash(mes), mac, myMAC.HashSize / 8) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte[] ComputeMAC(byte[] mes, byte[] key)
        {
            myMAC.Key = key;
            return myMAC.ComputeHash(mes);
        }

        public int MACByteLength()
        {
            return myMAC.HashSize / 8;
        }

        private bool CompareByteArrays(byte[] a, byte[] b, int len)
        {
            for (int i = 0; i < len; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
                
            }
            return true;
        }

    }
}
