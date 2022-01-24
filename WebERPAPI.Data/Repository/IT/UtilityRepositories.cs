using System;
using System.Collections.Generic;

namespace WebERPAPI.Data.Repository.IT
{
    public class UtilityRepositories
    {
        public Exception error = new Exception();

        public string getStrongPassword()
        {
            try
            {
                string sp = "~!@#$%^*?/}{0987654321ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstwxyz";
                int i = 0, j = 0, len = 0;
                Random R = new Random();

                string key = "", newChars = "";

                len = R.Next(8, sp.Length);
                i = j = 0;

                for (int x = 0; x < len; x++)
                {
                    i = R.Next(1, sp.Length);
                    j = DateTime.Now.Second % i;

                    if (key.Length > 0)
                    {
                        char ch = key.Substring(key.Length - 1, 1).ToCharArray()[0];
                        char ch2 = sp.Substring(i, 1).ToCharArray()[0];

                        if ((ch >= 97 && ch <= 122) && (ch2 >= 97 && ch2 <= 122)) newChars = sp.Substring(i, 1).ToUpper();
                        else if ((ch >= 65 && ch <= 90) && (ch2 >= 65 && ch2 <= 90)) newChars = R.Next(0, 9).ToString(); // + sp.Substring(i, 1).ToLower();
                        else if ((ch >= 48 && ch <= 57) && (ch2 >= 48 && ch2 <= 57)) newChars = sp.Substring(R.Next(0, 10), 1).ToLower();
                        else newChars = sp.Substring(i, 1);
                    }
                    else newChars = sp.Substring(i, 1);

                    if (key.IndexOf(newChars) == -1) key += newChars;

                    System.Threading.Thread.Sleep(20);
                }

                return key;
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<string> getStrongPasswords()
        {
            try
            {
                string sp = "~!@#$%^*?_-/}{0987654321ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstwxyz";
                int i = 0, j = 0, len = 0;
                Random R = new Random();
                List<string> passwords = new List<string>();

                string key = "", newChars = "";

                for (int n = 0; n < 10; n++)
                {
                    len = R.Next(8, sp.Length);
                    i = j = 0;

                    for (int x = 0; x < 25; x++)
                    {
                        i = R.Next(1, sp.Length);
                        j = DateTime.Now.Second % i;

                        if (key.Length > 0)
                        {
                            char ch = key.Substring(key.Length - 1, 1).ToCharArray()[0];
                            char ch2 = sp.Substring(i, 1).ToCharArray()[0];

                            if ((ch >= 97 && ch <= 122) && (ch2 >= 97 && ch2 <= 122)) newChars = sp.Substring(i, 1).ToUpper();
                            else if ((ch >= 65 && ch <= 90) && (ch2 >= 65 && ch2 <= 90)) newChars = R.Next(0, 9).ToString(); // + sp.Substring(i, 1).ToLower();
                            else if ((ch >= 48 && ch <= 57) && (ch2 >= 48 && ch2 <= 57)) newChars = sp.Substring(R.Next(0, 10), 1).ToLower();
                            else newChars = sp.Substring(i, 1);
                        }
                        else newChars = sp.Substring(i, 1);

                        if (key.ToLower().IndexOf(newChars.ToLower()) == -1) key += newChars;

                        System.Threading.Thread.Sleep(30);
                    }

                    if (key.Length > 8) passwords.Add(key);
                    key = "";
                }

                return passwords;
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
    }
}