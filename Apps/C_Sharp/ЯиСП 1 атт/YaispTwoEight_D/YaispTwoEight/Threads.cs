using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace YaispTwoEight
{
  public class _Threads
  {
    private ChangeUI _ui;
    private List<Thread> _threads;
    public _Threads(ChangeUI ui)
    {
      _ui = ui;
    }
    public void Run(int count)
    {
      _threads = new List<Thread>();
      for (int i = 0; i < count; i++)
      {
        var thread = new Thread(MultiThread);
        thread.IsBackground = true;
        _threads.Add(thread);
        _threads[i].Start();
      }
    }
    public void Abort()
    {
      foreach (Thread tr in _threads)
        tr.Abort();
      _threads.Clear();
    }
    public void MultiThread()
    {
        _ui();
    }
  }
}
