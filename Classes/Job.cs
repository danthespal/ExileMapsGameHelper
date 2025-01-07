using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExileMaps.Classes;

public class Job
{
    public string Name { get; }
    private readonly Action _action;
    private Task _task;

    public Job(string name, Action action)
    {
        Name = name;
        _action = action;
    }

    public void Start()
    {
        _task = Task.Run(_action);
    }

    public async Task WaitAsync()
    {
        if (_task != null)
        {
            await _task;
        }
    }

    public void Wait()
    {
        _task?.Wait();
    }

    public bool IsComplete => _task?.IsCompleted ?? false;
}
