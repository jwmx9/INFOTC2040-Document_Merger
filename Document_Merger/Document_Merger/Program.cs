using System;
using System.IO;
using System.Collections.Generic;

namespace Document_Merger
{
    class MainClass
    {


        public static void Main(string[] args)
        {

            int CountNonSpaceChars(string value)
            {
                int result = 0;
                foreach (char c in value)
                {
                    if (!char.IsWhiteSpace(c))
                    {
                        result++;
                    }
                }
                return result;
            }

            string mergedFile = "";
            string[] mergedFiletext;
            string[] file1text;
            string[] file2text;

            Console.WriteLine("Document Merger");
            Console.WriteLine("");

            Console.Write("Enter the name of the first text file: ");
            string file1 = Console.ReadLine();
            //verify that the file exists
            Console.WriteLine(File.Exists(file1) ? "File exists." : "File does not exist.");

            int check1 = 0;
            while (check1 == 0) {

                if (File.Exists(file1) == true)
                {
                    Console.Write("Enter the name of the second text file: ");
                    string file2 = Console.ReadLine();
                    //verify that the second file exists
                    Console.WriteLine(File.Exists(file2) ? "File exists." : "File does not exist.");
                    if (File.Exists(file2) == true)
                    {
                        mergedFile = file1.Replace(".txt", "") + file2.Replace(".txt", "") + ".txt";
                        file1text = File.ReadAllLines(file1);
                        file2text = File.ReadAllLines(file2);

                        var myList = new List<string>();
                        myList.AddRange(file1text);
                        myList.AddRange(file2text);
                        mergedFiletext = myList.ToArray();

                        try
                        {
                            StreamWriter sw = new StreamWriter(mergedFile);

                            //Write a line of text
                            sw.Write("{0} {1}", mergedFiletext[0], mergedFiletext[1]);

                            //Close the file
                            sw.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }
                        finally
                        {
                            int totalcount = CountNonSpaceChars(file1text.ToString()) + CountNonSpaceChars(file2text.ToString());
                            Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", mergedFile, totalcount);
                            Console.WriteLine("Would you like to merge two more files?");
                                Console.WriteLine("Enter y for yes or any key for no");
                                string check2 = Console.ReadLine();
                                if (check2 == "y")
                                {
                                    check1 = 0;
                                }
                                else
                                {
                                check1 = 1;
                                }
                            
                        }

                        check1 = 1;

                    }
                    else { check1 = 0; }
                } 
                else
                {
                    Console.Write("Enter the name of the first text file: ");
                    file1 = Console.ReadLine();
                    //verify that the file exists
                    Console.WriteLine(File.Exists(file1) ? "File exists." : "File does not exist.");
                    check1 = 0;
                }
            }
        }
    }
}
