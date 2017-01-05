using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAEncryption
{
    class RSA
    {
        private int keyDimension = 8;
        private int N, E, D;
        private byte[] encryptKey, encryptSecretKey, decryptKey;

        /* encrypted data */
        List<byte> result = new List<byte>();

        public RSA()
        {
            this.encryptSecretKey = new byte[keyDimension];
            this.decryptKey = new byte[keyDimension];
        }

        public RSA(int D)
        {
            this.D = D;

            this.encryptSecretKey = new byte[keyDimension];
            this.decryptKey = new byte[keyDimension];
        }

        public RSA(int N, int E)
        {
            this.N = N;
            this.E = E;

            this.encryptSecretKey = new byte[keyDimension];
            this.decryptKey = new byte[keyDimension];
        }

        public Boolean encrypt(String fileToRead)
        {
            BitReader bitReader = new BitReader(fileToRead);

            FileInfo f = new FileInfo(fileToRead);
            int nbr = 8 * (int)f.Length;

            /* Generate random key */
            this.encryptKey = generateRandomKey();

            /* Generate secret key */
            this.encryptSecretKey = generateSecretKey(encryptKey, N, E);

            byte data;
            int i = 0;
            int character;

            /* read data from file */
            while (nbr > 0)
            {
                character = bitReader.readNBits(8);
                data = Convert.ToByte(character ^ encryptKey[i]);
                result.Add(data);
                i++;
                i %= 8;

                nbr -= 8;
            }          

            bitReader.cleanUp();

            String encryptedFile = "encrypted_file.rsa";
            BitWriter bitWriter = new BitWriter(encryptedFile);

            writeEncryptedFile(bitWriter);
            bitWriter.cleanUp(); 

            return true;
        }

        public Boolean decrypt(String encryptedFileToRead)
        {
            BitReader bitReader = new BitReader(encryptedFileToRead);

            FileInfo f = new FileInfo(encryptedFileToRead);
            int nbr = 8 * (int)f.Length;

            /* get N and E from header */
            int[] headerData = getNEFromHeader(bitReader, nbr);
            this.N = headerData[0];
            this.E = headerData[1];

            nbr -= 2 * 32;

            /* get encrypted key from header */
            byte[] encryptedKeyFromFile = getEncryptedKeyFromHeader(bitReader, nbr);
            nbr -= keyDimension * 32;

            /* decrypt encrypted key from header */
            decryptKey = decryptEncryptedKey(encryptedKeyFromFile);

            byte data;
            int i = 0;
            int character;

            /* read data from file */
            while (nbr > 0)
            {
                character = bitReader.readNBits(8);
                data = Convert.ToByte(character ^ decryptKey[i]);
                result.Add(data);
                i++;
                i %= 8;

                nbr -= 8;
            }

            //generate the decrypted file
            String decompressedFile = "decrypted_file.decrypted";
            BitWriter bitWriter = new BitWriter(decompressedFile);

            //writeDecryptedDataToFile(bitWriter);
            bitWriter.cleanUp();

            return true;

        }

        private byte modularExponent(int B, int X, int N)
        {
            int R = 1;
            for (int k = 1; k <= X; k++)
            {
                R *= B;
                R %= N;
            }
            return Convert.ToByte(R);
        }

        private byte[] generateRandomKey()
        {
            byte[] generatedKey = new byte[keyDimension];
            Random random = new Random();

            for (int i = 0; i < keyDimension; i++)
            {
                generatedKey[i] = Convert.ToByte(random.Next(keyDimension * keyDimension));
            }

            return generatedKey;
        }
        
        private byte[] generateSecretKey(byte[] key, int N, int E)
        {
            byte[] generatedKey = new byte[keyDimension];

            for (int i = 0; i < keyDimension; i++)
            {
                generatedKey[i] = modularExponent(key[i], E, N);
            }
            return generatedKey;
        }

        private void writeKeys(BitWriter bitWriter)
        {
            bitWriter.writeNBits(N, 32);
            bitWriter.writeNBits(E, 32);

            for(int i = 0; i < keyDimension; i++)
            {
                bitWriter.writeNBits(encryptSecretKey[i], 32);
            }
        }

        private void writeEncryptedFile(BitWriter bitWriter)
        {
            writeKeys(bitWriter);

            foreach(byte data in result)
            {
                bitWriter.writeNBits(data, 8);
            }
        }

        private int[] getNEFromHeader(BitReader bitReader, int fileSize)
        {
            int NFromHeader;
            int EFromHeader;

            int[] headerData = new int[2];

            if (fileSize > 0)
            {
                NFromHeader = bitReader.readNBits(32);
                EFromHeader = bitReader.readNBits(32);

                headerData[0] = NFromHeader;
                headerData[1] = EFromHeader;
            }

            return headerData;
        }

        private byte[] getEncryptedKeyFromHeader(BitReader bitReader, int fileSize)
        {
            byte[] encryptedKeyFromFile = new byte[keyDimension];            
                        
            for(int i = 0; i < keyDimension; i++)
            {
                if (fileSize > 0)
                {
                    encryptedKeyFromFile[i] = Convert.ToByte(bitReader.readNBits(32));
                    fileSize -= 32;
                }
            }
            
            return encryptedKeyFromFile;
        }

        private byte[] decryptEncryptedKey(byte[] encryptedKey)
        {
            byte[] decryptedKey = new byte[keyDimension];

            for (int i = 0; i < keyDimension; i++)
            {
                decryptedKey[i] = modularExponent(encryptedKey[i], D, N);
            }
            
            return decryptedKey;
        }










        /* functions needed to display data in form */
        public String getEncryptKey()
        {
            String keyText = "";
            for (int i = 0; i < keyDimension; i++)
            {
                keyText += encryptKey[i].ToString();
            }

            return keyText;
        }

        public String getDecryptKey()
        {
            String keyText = "";
            for (int i = 0; i < keyDimension; i++)
            {
                keyText += decryptKey[i].ToString();
            }

            return keyText;
        }

        public String getE()
        {
            return E.ToString();
        }

        public String getN()
        {
            return N.ToString();
        }

    }
}
