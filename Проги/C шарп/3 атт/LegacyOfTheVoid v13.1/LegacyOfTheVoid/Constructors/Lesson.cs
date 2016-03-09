namespace ProjectRed
{
  class Lesson
  {
    public int Type;
    public string Date;
    public string Theme;
    public bool State;

    public Lesson(string Date, string Theme, int Type, bool State)
    {
      this.Type = Type;
      this.Theme = Theme;
      this.Date = Date;
      this.State = State;
    }
  }
}
