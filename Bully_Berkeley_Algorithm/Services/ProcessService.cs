using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bully_Berkeley_Algorithm.Services
{
    public class ProcessService : IProcessService
    {
        public static List<Process> Processes = new List<Process>();
        public static string path = Path.Combine(Directory.GetCurrentDirectory(), "Process.txt");

        public static int Coordinator_id = 0;
        public void AddProcess(Process process)
        {
            throw new NotImplementedException();
        }

        public void Election()
        {
            foreach(var process in Processes.Where(p=>p.Is_Frozen==false))
            {
                process.Counter += 1;
            }
        }

        public void FreezeProcess(int process_id)
        {
           foreach(var process in Processes.Where(p => p.Process_id == process_id))
            {
                process.Is_Frozen = true;
                if (process.Is_Coordinator == true)
                {
                    SetCoordinator();
                    Election();
                }
            }
        }

        public void KillProcess(int process_id)
        {
            var process = Processes.Where(p => p.Process_id == process_id).FirstOrDefault();

            Processes.Remove(process);

            if (process.Is_Coordinator)
            {
                Election();
            }
        }

        public List<Process> LoadProcesses()
        {
            var processes = Processes.Where(p => p.Is_Frozen == false).ToList();

            if (processes.Count > 0)
                return processes;
            else
                return LoadProcessesFromFile(path);
        }

        

        public List<Process> LoadProcessesFromFile(string path)
        {
            
            var file = File.ReadAllLines(path, encoding: Encoding.UTF8);

            foreach(var line in file)
            {
                Process p = new Process();

                
                string[] processes = line.Split(",");

                int process_id = Convert.ToInt32(processes[0].Trim());

                p.Process_id = process_id;

                p.Name = processes[1].Split("_")[0].Trim();
                p.Counter = 0;

                p.Time = processes[2].Trim().Replace("am","").Replace("pm","");

                Processes.Add(p);
            }

            SetCoordinator();

            return Processes;
        }

        public void Reload()
        {
            var file = File.ReadAllLines(path, encoding: Encoding.UTF8);

            List<Process> New_Processes = new List<Process>();

            Election();
            foreach (var line in file)
            {
                Process p = new Process();


                string[] processes = line.Split(",");

                int process_id = Convert.ToInt32(processes[0].Trim());

                p.Process_id = process_id;

                p.Name = processes[1].Split("_")[0].Trim();
                p.Counter = 0;

                p.Time = processes[2].Trim().Replace("am", "").Replace("pm", "");

                New_Processes.Add(p);
            }

            var differences = New_Processes.Select(p=>p.Process_id).Except(Processes.Select(p=>p.Process_id));

            foreach(var difference in differences)
            {
                Processes.Add(New_Processes.Where(p => p.Process_id==difference).FirstOrDefault());
            }

            SetCoordinator();
            
            
        }

        public void SetCoordinator()
        {
            int max = Processes[0].Process_id;

            foreach(var item in Processes.Where(p=>p.Is_Frozen==false))
            {
                if (max < item.Process_id)
                {
                    max = item.Process_id;
                }
                item.Is_Coordinator = false;
            }

            var process = Processes.Where(p => p.Process_id == max).FirstOrDefault();

            process.Is_Coordinator = true;


            Coordinator_id = max;
        }

        public void SetTimeProcess(int process_id, string Time)
        {
           foreach(var process in Processes.Where(x => x.Process_id == process_id))
            {
                process.Time = Time; 
            }
        }


        public void UnFreezeProcess(int process_id)
        {
            Processes.Where(p => p.Process_id == process_id).FirstOrDefault().Is_Frozen = false;
            SetCoordinator();
            Election();
        }
    }
}                                                   
