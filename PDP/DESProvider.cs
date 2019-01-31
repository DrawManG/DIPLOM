
using System;
using System.Text;
using System.IO;
using System.Collections;

namespace Cipher
{
    class DESProvider : DES, ICipher
    {
        public event ProgressEventHandler ProgressChanged;
        ProgressEventArgs Args = new ProgressEventArgs();

        public DESProvider()
        {
            base.InitializeTables();
        }

        public void Encrypt(string SourceFileName, string DestinationFileName, string Key)
        {
            FileStream FS1 = null, FS2 = null;
            try
            {
                FS1 = new FileStream(SourceFileName, FileMode.Open);
                FS2 = new FileStream(DestinationFileName, FileMode.OpenOrCreate);

                byte[] input = new byte[FS1.Length];
                FS1.Read(input, 0, input.Length);
                byte[] Encrypted = Encrypt(input, Key);
                FS2.Write(Encrypted, 0, Encrypted.Length);
            }
            finally
            {
                FS1.Close();
                FS2.Close();
                if (Args.stop)
                {
                    File.Delete(DestinationFileName);
                }
            }
        }

        public void Decrypt(string SourceFileName, string DestinationFileName, string Key)
        {
            FileStream FS1 = null, FS2 = null;
            try
            {
                FS1 = new FileStream(SourceFileName, FileMode.Open);
                FS2 = new FileStream(DestinationFileName, FileMode.OpenOrCreate);

                byte[] input = new byte[FS1.Length];
                FS1.Read(input, 0, input.Length);
                byte[] Decrypted = Decrypt(input, Key);
                FS2.Write(Decrypted, 0, Decrypted.Length);
            }
            finally
            {
                FS1.Close();
                FS2.Close();
                if (Args.stop)
                {
                    File.Delete(DestinationFileName);
                }
            }
        }

        public byte[] Encrypt(byte[] BytesInput, string Key)
        {
            if (this.Key != Key) { PermuteKeys(Key); }
            Args.stop = false;

            byte[] BlockIn = new byte[8];
            byte[] BlockOut = new byte[8];
            //Extend input to multiples of 8
            byte[] BytesOut = new byte[BytesInput.Length +
                ((BytesInput.Length % 8) == 0 ? 0 : (8 - BytesInput.Length % 8))];

            //Encrypt by 8 bytes
            int tmp = BytesInput.Length / 8;
            for (int i = 0; i < tmp; i++)
            {
                Array.Copy(BytesInput, i * 8, BlockIn, 0, 8);
                base.Encrypt64Bit(new BitArray(BlockIn)).CopyTo(BlockOut, 0);
                Array.Copy(BlockOut, 0, BytesOut, i * 8, 8);
                if ((Args.progress != (i * 100) / tmp) && ProgressChanged != null)
                {
                    Args.progress = (i * 100) / tmp;
                    ProgressChanged(this, Args);//signal to parent object
                    if (Args.stop)
                        break;

                }
            }

            //Encrypt last 8 bytes(if present)
            int leftBytesNum = BytesInput.Length % 8;
            if (leftBytesNum > 0)
            {
                BlockIn = new byte[8];
                Array.Copy(BytesInput, BytesInput.Length - leftBytesNum, BlockIn, 0, leftBytesNum);
                base.Encrypt64Bit(new BitArray(BlockIn)).CopyTo(BlockOut, 0);
                Array.Copy(BlockOut, 0, BytesOut, BytesOut.Length - 8, 8);
            }
            Args.progress = 100;
            if (ProgressChanged != null) ProgressChanged(this, Args);
            return BytesOut;

        }

        public byte[] Decrypt(byte[] BytesInput, string Key)
        {
            if (this.Key != Key) { PermuteKeys(Key); }
            Args.stop = false;

            byte[] BlockIn = new byte[8];
            byte[] BlockOut = new byte[8];
            //Extend input to multiples of 8
            byte[] BytesOut = new byte[BytesInput.Length +
                ((BytesInput.Length % 8) == 0 ? 0 : (8 - BytesInput.Length % 8))];

            //Decrypt by 8 bytes
            int tmp = BytesInput.Length / 8;
            for (int i = 0; i < tmp; i++)
            {
                Array.Copy(BytesInput, i * 8, BlockIn, 0, 8);
                base.Decrypt64Bit(new BitArray(BlockIn)).CopyTo(BlockOut, 0);
                Array.Copy(BlockOut, 0, BytesOut, i * 8, 8);
                if ((Args.progress != (i * 100) / tmp) && ProgressChanged != null)
                {
                    Args.progress = (i * 100) / tmp;
                    ProgressChanged(this, Args);//signal to parent object
                    if (Args.stop)
                        break;
                }
            }

            //Decrypt last 8 bytes(if present)
            int leftBytesNum = BytesInput.Length % 8;
            if (leftBytesNum > 0)
            {
                BlockIn = new byte[8];
                Array.Copy(BytesInput, BytesInput.Length - leftBytesNum, BlockIn, 0, leftBytesNum);
                base.Decrypt64Bit(new BitArray(BlockIn)).CopyTo(BlockOut, 0);
                Array.Copy(BlockOut, 0, BytesOut, BytesOut.Length - 8, 8);
            }
            Args.progress = 100;
            if (ProgressChanged != null) ProgressChanged(this, Args);
            return BytesOut;
        }
    }
}
