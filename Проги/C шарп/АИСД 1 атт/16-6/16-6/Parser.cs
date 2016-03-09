namespace _16_6
{
  class Parser
  {
    public static LoTVTeamListClass ParseList(string Input)
    {
      string[] Arr = Input.Replace("\r", "").Split('\n');
      LoTVTeamListClass AllTeams = new LoTVTeamListClass();
      for (int i = 0; i < 16; i++)
      {
        LoTVPlayerListClass Players = new LoTVPlayerListClass();
        for (int k = 0; k < 11; k++)        
          Players.LoTVPlayerListAdd(Arr[2 * k + 1 + 23 * i], int.Parse(Arr[2 * k + 2 + 23 * i]));
        AllTeams.LoTVTeamsListAdd(Players, Arr[23 * i]);
        AllTeams.list_Head.LoTVGetTeamRating();
      }
      return AllTeams;
    }
  }
}
