using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1
{
    class Program
    {
        // read in the file of values
        // loop through the values - take the first one and add it to each one checking for 2020
        // if it is true => multiply the values and print out the result


        public static List<int> FileValues()
        {
            StreamReader sr = new StreamReader("values.txt");
            var file = sr.ReadToEnd();
            // check for empty string just in case
            return file.Split("\n").Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x.ToString())).ToList();
        }

        public static void TwoValueExpenses(List<int> values)
        {
            int result = 0;
            for(int i = 0; i < values.Count; i++)
            {
                for(int j = 0; j < values.Count; j++)
                {
                    if(i != j) // make sure its not the same value
                    {
                        if(values[i] + values[j] == 2020)
                        {
                            result = values[i] * values[j];
                            break;
                        }
                    }
                }

                if(result != 0)
                {
                    break;
                }
            }

            Console.WriteLine("The result of two values multiplied are: " + result); // part 1
        }

        public static void ThreeValueExpenses(List<int> values)
        {
            int result = 0;
            for(int i = 0; i < values.Count; i++)
            {
                for(int j = 0; j < values.Count; j++)
                {
                    for(int l = 0; l < values.Count; l++)
                    {
                        if(i != j && i != l && j != l) // make sure its not the same value
                        {
                            if(values[i] + values[j] + values[l] == 2020)
                            {
                                result = values[i] * values[j] * values[l];
                                break;
                            }
                        }
                    }   
                    if(result != 0)
                    {
                        break;
                    }
                }
                if(result != 0)
                {
                    break;
                }
            }

            Console.WriteLine("The result of three values multiplied are: " + result); // part 1
        }

        static void Main(string[] args)
        {
            List<int> values = FileValues();
            TwoValueExpenses(values);
            ThreeValueExpenses(values);
        }
    }
}
