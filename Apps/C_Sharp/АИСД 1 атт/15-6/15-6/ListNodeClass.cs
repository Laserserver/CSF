namespace _15_6
{
  class ListNodeClass
  {
    public double NodeValue;
    public ListNodeClass NodeNext;

    public ListNodeClass(double Info, ListNodeClass NewNode)
    {
      NodeValue = Info;
      NodeNext = NewNode;
    }
  }
}
