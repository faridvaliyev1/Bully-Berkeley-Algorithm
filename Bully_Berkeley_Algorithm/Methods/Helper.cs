using Bully_Berkeley_Algorithm.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bully_Berkeley_Algorithm.Methods
{
    public static class Helper
    {

        public static void Load()
        {
            ProcessService p = new ProcessService();

            var processes=p.LoadProcesses();

            foreach(var process in processes)
            {
                Console.Write(process.Process_id.ToString()+",");
                Console.Write(process.Name + "_" + process.Counter.ToString());
                if (process.Is_Coordinator)
                {
                    Console.Write(" (Coordinator) ");
                }
                Console.WriteLine();
            }
        }

        public static void KillProcess(string command)
        {
            try
            {
                int process_id = Convert.ToInt32(command.Split(" ")[1]);

                ProcessService p = new ProcessService();

                p.KillProcess(process_id);

                p.SetCoordinator();
            }
            catch(Exception e)
            {
                Console.WriteLine("Please write correct command");
            }
        }

        public static void Clock()
        {
            ProcessService p = new ProcessService();

            var processes = p.LoadProcesses();

            string Time = processes.Where(p => p.Is_Coordinator == true).FirstOrDefault().Time;

            foreach(var process in processes)
            {
                Console.Write(process.Name + "_" + process.Counter.ToString());

                Console.Write(" , " + Time);

                Console.WriteLine();
            }
            
        }

        public static void Freeze(string command)
        {
            try
            {
                int process_id = Convert.ToInt32(command.Split(" ")[1]);

                ProcessService p = new ProcessService();

                p.FreezeProcess(process_id);
            }
            catch(Exception e)
            {
                Console.WriteLine("Please enter correct command");
            }
        }

        public static void UnFreeze(string command)
        {
            try
            {
                int process_id = Convert.ToInt32(command.Split(" ")[1]);

                ProcessService p = new ProcessService();
                
                p.UnFreezeProcess(process_id);
            }
            catch(Exception e)
            {
                Console.WriteLine("Please write correct command");
            }
        }

        public static void Reload()
        {
            try
            {
                ProcessService p = new ProcessService();

                p.Reload();

                p.LoadProcesses();
            }
            catch(Exception e)
            {
                Console.WriteLine("Please write correct command");
            }
        }
        

        public static void ListofCommands()
        {
            Console.WriteLine("Please enter the commands below:");
            Console.WriteLine("1.List");
            Console.WriteLine("2.Clock");
            Console.WriteLine("3.Kill {Process_id}");
            Console.WriteLine("4.Set-time {Process_id}");
            Console.WriteLine("5.Freeze {Process_id}");
            Console.WriteLine("6.UnFreeze {Process_id}");
            Console.WriteLine("7.Reload");
            Console.WriteLine("8.Help");
            Console.WriteLine("9.Exit");
        }
    }
}
