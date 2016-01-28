using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRed
{
  class ParseJournal
  {
    public static void SplitJournal(string Input, out string StudList, out string LessonList, out string JournalData)
    {
      string[] Arr = Input.Split(';');
      StudList = Arr[0];
      LessonList = Arr[1].Remove(0, 1); //Собссно, удаляет \n из начала строки
      JournalData = Arr[2].Remove(0, 1);
    }

    public static void ParseJournalData(string Input)
    {

    }
  }
}
