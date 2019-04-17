using System;
using static System.Console;

namespace HelperFunctions
{
    public abstract class HelperClass
    {
        public static void PressAnyKey()
        {
            Write("Press any key to continue...");
            ReadKey();
        }

        public static String GetStringInput(String prompt)
        {
            String ret = null;
            do
            {
                Write(prompt);
                ret = ReadLine();
                if (String.IsNullOrEmpty(ret))
                {
                    WriteLine("Your input cannot be empty. Please try again...");
                }
            } while (String.IsNullOrEmpty(ret));
            return ret;
        }

        public static char GetCharInput(String prompt)
        {
            return GetStringInput(prompt)[0];
        }

        public static int GetPositiveIntegerInput(String prompt)
        {
            int ret = -1;
            do
            {
                String entry = GetStringInput(prompt);
                if (entry.Trim() == "0")
                {
                    ret = 0;
                }
                else
                {
                    if (int.TryParse(entry, out ret))
                    {
                        if (ret < 0)
                        {
                            ret = -1;
                        }
                    }
                    else
                    {
                        ret = -1;
                    }
                }
                if (ret == -1)
                    WriteLine("That was not a valid positive whole number. Please try again.");
            } while (ret == -1);
            return ret;
        }

        public static int GetAnyIntegerInput(String prompt)
        {
            int? ret=null;
            do
            {
                String entry = GetStringInput(prompt);
                if (entry.Trim() == "0")
                {
                    ret = 0;
                }
                else
                {
                    int num;
                    int.TryParse(entry, out num);
                    if (num == 0)
                    {
                        WriteLine("That was not a valid whole number. Please try again.");
                    }
                    else
                    {
                        ret = num;
                    }
                }
            } while (ret == null);
            return (int)ret;
        }

        public static double GetPositiveDoubleInput(String prompt)
        {
            double ret = -1.0;
            do
            {
                String entry = GetStringInput(prompt);
                if (entry.Trim() == "0")
                {
                    ret = 0;
                }
                else
                {
                    if (double.TryParse(entry, out ret))
                    {
                        if (ret < 0)
                        {
                            ret = -1;
                        }
                    }
                    else
                    {
                        ret = -1;
                    }
                }
                if (ret == -1)
                    WriteLine("That was not a valid positive double. Please try again.");
            } while (ret == -1);
            return ret;
        }

        public static double GetAnyDoubleInput(String prompt)
        {
            double? ret = null;
            do
            {
                String entry = GetStringInput(prompt);
                if (entry.Trim() == "0")
                {
                    ret = 0;
                }
                else
                {
                    double num;
                    double.TryParse(entry, out num);
                    if (num == 0)
                    {
                        WriteLine("That was not a valid double. Please try again.");
                    }
                    else
                    {
                        ret = num;
                    }
                }
            } while (ret == null);
            return (double)ret;
        }

        public static Decimal GetPositiveDecimalInput(String prompt)
        {
            Decimal ret = -1m;
            do
            {
                String entry = GetStringInput(prompt);
                if (entry.Trim() == "0")
                {
                    ret = 0;
                }
                else
                {
                    if (Decimal.TryParse(entry, out ret))
                    {
                        if (ret < 0)
                        {
                            ret = -1;
                        }
                    }
                    else
                    {
                        ret = -1;
                    }
                }
                if (ret == -1)
                    WriteLine("That was not a valid positive decimal number. Please try again.");
            } while (ret == -1);
            return ret;
        }

        public static Decimal GetAnyDecimalInput(String prompt)
        {
            Decimal? ret = null;
            do
            {
                String entry = GetStringInput(prompt);
                if (entry.Trim() == "0")
                {
                    ret = 0;
                }
                else
                {
                    Decimal num;
                    Decimal.TryParse(entry, out num);
                    if (num == 0)
                    {
                        WriteLine("That was not a valid decimal number. Please try again.");
                    }
                    else
                    {
                        ret = num;
                    }
                }
            } while (ret == null);
            return (Decimal)ret;
        }

    }
}
