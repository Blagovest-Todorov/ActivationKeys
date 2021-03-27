using System;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Generate")
                {
                    Console.WriteLine($"Your activation key is: {text}");
                    break;
                }

                string[] parts = line
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string comand = parts[0];
                string secPart;
                string thirdPart;
                string fourthPart;


                if (comand == "Contains")
                {
                    secPart = parts[1];

                    if (text.Contains(secPart))
                    {
                        Console.WriteLine($"{line} contains {secPart}");
                        continue;
                    }

                    Console.WriteLine($"Substring not found!");
                }
                else if (comand == "Flip")
                {
                    secPart = parts[1];
                    thirdPart = parts[2];  // start idx   //Flip>>>Upper>>>3>>>14
                    fourthPart = parts[3]; //endIdx
                    int length = int.Parse(fourthPart) - int.Parse(thirdPart);

                    if (secPart == "Upper")
                    {
                        string sectionToChange = text.Substring(int.Parse(thirdPart), length);
                        string sectionReplacement = sectionToChange.ToUpper();
                        text = text.Replace(sectionToChange, sectionReplacement);
                                               
                    }
                    else //// if (secPart == "Lower")
                    {
                        string sectionToChange = text.Substring(int.Parse(thirdPart), length);
                        string sectionReplacement = sectionToChange.ToLower();
                        text = text.Replace(sectionToChange, sectionReplacement);                       
                    }

                    Console.WriteLine(text);
                }
                else // if (comand == "Slice")
                {
                    secPart = parts[1];  // stardIdx
                    thirdPart = parts[2]; //endIdx
                    int length = int.Parse(thirdPart) - int.Parse(secPart); //length to be deleted
                    text = text.Remove(int.Parse(secPart), length);
                    

                    Console.WriteLine(text);
                }
            }
        }
    }
}