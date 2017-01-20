namespace OneTimePad
{
    class irrevelvant
    {

        static string convertToBits(int n, int pad)
        {
            string result = null;

            while (n > 0)
            {
                if (n % 2 == 0)
                    result = "0" + result;
                else
                    result = "1" + result;

                n = n / 2;
            }

            while (result.Length < pad)
                result = "0" + result;

            return result;
        }

        static string strToBits(string str)
        {
            string result = null;
            int i = 0, num = 23;

            foreach (char c in str)
            {
                num = num + i;
                result = convertToBits(num, 8) + result;
                i = i + 67;
            }

            return result;
        }

        // Below data was in Main()

        // ******************************************************************************************** //

        //Console.Write("Enter data: ");
        //ans = Console.ReadLine();

        //ans = strToBits(ans);

        // Console.WriteLine("\n" + ans + "\n");            
        //Console.ReadKey();

        // ******************************************************************************************** //

        // Console.WriteLine("What is your intent: ");
        // ans = Console.ReadLine();

    }
}
