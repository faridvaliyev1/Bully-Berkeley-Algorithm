using Bully_Berkeley_Algorithm.Methods;
using Bully_Berkeley_Algorithm.Services;
using System;
using System.IO;

namespace Bully_Berkeley_Algorithm
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Helper.ListofCommands();
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Exit")
                {
                    break;
                }

                switch (command.Trim())
                {
                    case "List":
                        Helper.Load();
                        break;
                    case "Clock":
                        Helper.Clock();
                        break;
                    case string com when com.Contains("Kill"):
                        Helper.KillProcess(com);
                        break;
                    case string com when com.Contains("Freeze"):
                        Helper.Freeze(com);
                        break;
                    case string com when com.Contains("Unfreeze"):
                        Helper.UnFreeze(com);
                        break;
                    case "Reload":
                        Helper.Reload();
                        break;
                    default:
                        Helper.ListofCommands();
                        break;
                    
                }
            }
        }
    }
}
