﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentBuilderLibrary;

namespace INFO_3137_Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string selection = "";
            Director director = null;

            UIHelper.PrintUsage();
            Console.WriteLine();

            do
            {
                Console.Write('>');
                input = Console.ReadLine();

                selection = input.Contains(':') ? input.Remove(input.IndexOf(':')).ToUpper() : input.ToUpper();

                switch (selection)
                {
                    case "HELP":
                        UIHelper.PrintUsage();
                        break;

                    case "MODE":
                        if (input.  Substring(input.IndexOf(':')+1).ToUpper().Equals("JSON"))
                        {
                            director = new Director("JSON");
                        }
                        else if ((input.Substring(input.IndexOf(':')+1).ToUpper().Equals("XML")))
                        {
                            director = new Director("XML");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. For Usage, type 'Help'\n");
                        }
                        break;

                    case "BRANCH":
                        
                        if(director == null) 
                        {
                            Console.WriteLine("Error. Mode has not been set. For usage, type 'Help'");
                            break;
                        }

                        director._name = input.Substring(input.IndexOf(':') + 1);
                        director.BuildBranch();
                        break;

                    case "LEAF":
                        if (director == null)
                        {
                            Console.WriteLine("Error. Mode has not been set. For usage, type 'Help'");
                            break;
                        }

                        if (input.Count(x => x == ':') != 2)
                        {
                            Console.WriteLine("Invalid input. For Usage, type 'Help'");
                            break;
                        }

                        int firstDelim = input.IndexOf(':') + 1;
                        int secondDelim = input.LastIndexOf(':'); 
                        director._name = input.Substring(firstDelim, secondDelim - firstDelim);
                        director._content = input.Substring(secondDelim + 1);
                        director.BuildLeaf();
                        break;

                    case "CLOSE":
                        if (director == null)
                        {
                            Console.WriteLine("Error. Mode has not been set. For usage, type 'Help'");
                            break;
                        }

                        director.CloseBranch();
                        break;

                    case "PRINT":
                        if (director == null)
                        {
                            Console.WriteLine("Error. Mode has not been set. For usage, type 'Help'");
                            break;
                        }

                        director.Print();
                        break;

                    case "EXIT":
                        break;

                    default:
                        Console.WriteLine("Invalid input. For Usage, type 'Help'");
                        break;
                }
            } while (!selection.Equals("EXIT"));
        }
    }
}
