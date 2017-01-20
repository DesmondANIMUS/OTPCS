using System;
using System.Text;
using System.Text.RegularExpressions;

namespace OneTimePad
{
    class Program
    {
        static void Main(string[] args)
        {
            string ans, buffer;
            byte[] inBytes = null, keyBytes = null;                        


            Console.Write("Enter data: ");
            ans = Console.ReadLine();

            inBytes = Encoding.Unicode.GetBytes(ans);


            buffer = Guid.NewGuid().ToString().Substring(0, inBytes.Length/2);
            keyBytes = Encoding.Unicode.GetBytes(buffer);                                   

            var data = otpEncDec(inBytes, keyBytes, inBytes);

            Console.WriteLine("\nHere's your secure data: {0}", Encoding.UTF8.GetString(data));
            System.IO.StreamWriter file = new System.IO.StreamWriter("test.txt");
            file.Write(Encoding.UTF8.GetString(data));

            file.Close();

            string text = System.IO.File.ReadAllText("test.txt");
            data = Encoding.UTF8.GetBytes(text);

            // Decrypting:
            var newData = otpEncDec(data, keyBytes, data);
            Regex trimmer = new Regex(@"\s\s+");
            
            string ok = Regex.Replace(Encoding.UTF8.GetString(newData), @"\s+", " ");

            Console.WriteLine("\n\nAfter Decrypting: {0}", ok);
            
            Console.ReadLine();
        }

        private static byte[] otpEncDec(byte[] inBytes, byte[] keyBytes, byte[] outBytes)
        {
            
            // Check arguments:
            if ((inBytes.Length != keyBytes.Length) || (keyBytes.Length != outBytes.Length))
                throw new ArgumentException("Byte-array are not of same length");

            // Encrypt/decrypt by XOR:
                for (int i = 0; i < inBytes.Length; i++)
                    outBytes[i] = (byte)(inBytes[i] ^ keyBytes[i]);
                                
            return outBytes;
        }        

        private static void NeedToSave(string key, string cipher)
        {
            // TODO: Implement this later, preferbly with mongodb

            cipher = cipher + "|" + key;

            Console.WriteLine("\n\n{0}", cipher);
        }
    }
}