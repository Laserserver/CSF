using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvWH
{
  public class OvWHNode
  {
    public OvWHNode node_Next;
    public int node_Data;

    public OvWHNode(OvWHNode Next, int Data)
    {
      node_Data = Data;
      node_Next = Next;
    }
  }

  public class OvWHList
  {
    public OvWHNode list_Head;
    public int list_Count;

    public OvWHList()
    {
      list_Head = null;
      list_Count = 0;
    }

    public void OvWHListAdd(int Data)
    {
      OvWHNode NewNode = new OvWHNode(list_Head, Data);
      list_Head = NewNode;
      list_Count++;
    }

    public void OvWHListAddSort(int Data)
    {
      if (list_Head != null)
      {
        if (list_Head.node_Data < Data)
        {
          OvWHNode NewNode = new OvWHNode(list_Head, Data);
          list_Head = NewNode;
        }
        else
        {
          OvWHNode TempNode = list_Head;

          while (TempNode.node_Next != null && TempNode.node_Next.node_Data >= Data)
            TempNode = TempNode.node_Next;
          OvWHNode NewNode = new OvWHNode(TempNode.node_Next, Data);
          TempNode.node_Next = NewNode;
        }
      }
      else
        list_Head = new OvWHNode(null, Data);
      list_Count++;
    }

    public string[] OvWhListPrint()
    {
      string[] Data = new string[list_Count];

      OvWHNode NewNode = list_Head;
      int i = 0;
      do
      {
        Data[i] = NewNode.node_Data.ToString();
        i++;
        NewNode = NewNode.node_Next;
      }
      while (NewNode != null);

      return Data;
    }
  }

  public class OvWHLogic
  {
    static int[] Numbers;
    static Random OvWHRnd = new Random();

    public static int[] OvWHGetNumbers(int Count)
    {
      Numbers = new int[Count];

      for (int i = 0; i < Count; i++)
        Numbers[i] = OvWHRnd.Next(0, 100);

      return Numbers;
    }

    public static OvWHList OvWHFillList()
    {
      OvWHList List = new OvWHList();

      for (int i = 0; i < Numbers.Length; i++)
        List.OvWHListAdd(Numbers[i]);
      return List;
    }

    public static OvWHList OvWHFillSortList()
    {
      OvWHList List = new OvWHList();

      for (int i = 0; i < Numbers.Length; i++)
        List.OvWHListAddSort(Numbers[i]);
      return List;
    }

  }
}
