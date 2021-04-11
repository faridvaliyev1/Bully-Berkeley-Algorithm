using System.Collections.Generic;

namespace Bully_Berkeley_Algorithm.Services
{
    public interface IProcessService
    {
        List<Process> LoadProcessesFromFile(string path);

        void AddProcess(Process process);

        void KillProcess(int process_id);

        void SetTimeProcess(int process_id, string Time);

        void FreezeProcess(int process_id);

        void UnFreezeProcess(int process_id);

        List<Process> LoadProcesses();

        void SetCoordinator();

        void Election();

        void Reload();

    }
}
