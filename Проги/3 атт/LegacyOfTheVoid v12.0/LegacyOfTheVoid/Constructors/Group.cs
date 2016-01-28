namespace ProjectRed
{
  class Group
  {
    public string GroupName;
    public string[] StudNames;

    public Group(string GroupName, string[] StudNames)
    {
      this.GroupName = GroupName;
      this.StudNames = StudNames;
    }
  }
}