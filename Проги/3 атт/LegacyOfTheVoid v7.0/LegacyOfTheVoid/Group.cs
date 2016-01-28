namespace ProjectRed
{
  class Group
  {
    public string GroupNum;
    public char GroupLet;
    public string[] Studs;

    public Group(string GroupNum, char GroupLet, string[] Studs)
    {
      this.GroupLet = GroupLet;
      this.GroupNum = GroupNum;
      this.Studs = Studs;
    }
  }
}
