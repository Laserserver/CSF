namespace _15_30
{
  struct LoTVData
  {
    public object node_Element;
    public bool node_IsSign;
    public LoTVData(object Element, bool IsSign)
    {
      node_IsSign = IsSign;
      node_Element = Element;
    }
  }
    /// <summary>
    /// Сас
    /// </summary>
  class LoTVStackNode
  {
    public LoTVData node_Data;
    public LoTVStackNode node_Next;

    public LoTVStackNode(LoTVData Data, LoTVStackNode NewNode)
    {
      node_Data = Data;
      node_Next = NewNode;
    }
  }

  class LoTVStack
  {
    LoTVStackNode stack_Head;
    public double stack_Sum;
    public LoTVStack()
    {
      stack_Head = null;
    }

    public void LoTVPush(LoTVData Data)
    {
      LoTVStackNode NewNode = new LoTVStackNode(Data, stack_Head);
      stack_Head = NewNode;
    }

    public LoTVData LoTVTake()
    {
      LoTVData Data = stack_Head.node_Data;
      stack_Head = stack_Head.node_Next;
      return Data;
    }

    public void LoTVFillStack(string Input)
    {
      int _temp = 0;
      LoTVStackNode NewNode;
      string[] Mass = Input.Split(' ');
      for (int i = Mass.Length - 1; i >= 0; i--)
      {
        if (int.TryParse(Mass[i], out _temp))
          NewNode = new LoTVStackNode(new LoTVData(_temp, false), stack_Head);
        else
          NewNode = new LoTVStackNode(new LoTVData(Mass[i][0], true), stack_Head);
        stack_Head = NewNode;
      }
    }

    public void LoTVGetResult()
    {
      double _result = 0;
      int _tempA = 0;
      LoTVData _tempData;
      _tempData = LoTVTake();
      _result = int.Parse(_tempData.node_Element.ToString());
      _tempData = LoTVTake();
      _tempA = int.Parse(_tempData.node_Element.ToString());

      do
      {
        _tempData = LoTVTake();
        if (_tempData.node_IsSign)
        {
          switch (_tempData.node_Element.ToString()[0])
          {
            case '+':
              _result += _tempA;
              break;
            case '-':
              _result -= _tempA;
              break;
            case '/':
              _result /= _tempA;
              break;
            case '*':
              _result *= _tempA;
              break;
          }
        }
        else
          _tempA = int.Parse(_tempData.node_Element.ToString());
      }
      while (stack_Head != null);
      stack_Sum = _result;
    }
  }
}
