using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRed
{
  class SaveJournal
  {
    public static string JournalSaver(string Groups, string Lessons)
    {

      return Groups + "\n;\n" + Lessons;
    }
  }
}
