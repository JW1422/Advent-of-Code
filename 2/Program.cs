using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2
{
    class Program
    {
        public static List<string> FilePolicies()
        {
            StreamReader sr = new StreamReader("policies.txt");
            var file = sr.ReadToEnd();
            
            return file.Split("\n").Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        public static bool PolicyValidator(string policy)
        {
            int count = 0;
            var splitPolicy = policy.Split('\n'); // [0] 1-3, [1] z:, [2]: value
            var splitPolicyDetails = splitPolicy[0].Split(' ');
            var lowValue = int.Parse(splitPolicyDetails[0].Split('-')[0]);
            var highValue = int.Parse(splitPolicyDetails[0].Split('-')[1]);
            var comparerValue = splitPolicyDetails[1].Trim(':');

            foreach(var character in splitPolicyDetails[2].ToCharArray())
            {
                if(character.ToString() == comparerValue)
                    count++;
            }

            if(count >= lowValue && count <= highValue)
                return true;
            else
                return false;
        }

        public static bool PasswordPositionValidator(string policy)
        {
            int count = 0;
            var splitPolicy = policy.Split('\n'); // [0] 1-3, [1] z:, [2]: value
            var splitPolicyDetails = splitPolicy[0].Split(' ');
            var lowValue = int.Parse(splitPolicyDetails[0].Split('-')[0]);
            var highValue = int.Parse(splitPolicyDetails[0].Split('-')[1]);
            var comparerValue = splitPolicyDetails[1].Trim(':');

            var valueToCharArr = splitPolicyDetails[2].ToCharArray();

            if(valueToCharArr[lowValue-1].ToString() == comparerValue ^ 
                valueToCharArr[highValue-1].ToString() == comparerValue)
                {
                    return true;
                }
            else
                return false;
        }


        static void Main(string[] args)
        {
            int count = 0;
            var policies = FilePolicies();

            foreach(var policy in policies)
            {
                var result = PolicyValidator(policy);
                if(result)
                    count++;
            }

            Console.WriteLine(count); // Part 1


            count = 0;
            foreach(var policy in policies)
            {
                var result = PasswordPositionValidator(policy);
                if(result)
                    count++;
            }

            Console.WriteLine(count); //part 2
        }
    }
}
