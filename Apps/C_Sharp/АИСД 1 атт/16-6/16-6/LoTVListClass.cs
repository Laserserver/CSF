namespace _16_6
{
  class LoTVTeamNodeClass
  {
    public string team_Name;
    public int team_Rating;
    public LoTVPlayerListClass node_Team;
    public LoTVTeamNodeClass node_NextNode;

    public LoTVTeamNodeClass(string Name, LoTVPlayerListClass Team, LoTVTeamNodeClass NextNode)
    {
      team_Name = Name;
      node_NextNode = NextNode;
      node_Team = Team;
    }

    public void LoTVGetTeamRating()
    {
      if (node_Team != null)
      {
        team_Rating = 0;
        LoTVPlayerNodeClass Player = node_Team.list_Head;
        do
        {
          team_Rating += Player.player_Rating;
          Player = Player.player_NextNode;
        }
        while (Player != null);
      }
    }
  }

  class LoTVTeamListClass
  {
    public LoTVTeamNodeClass list_Head;
    public LoTVTeamListClass()
    {
      list_Head = null;
    }

    public void LoTVTeamsListAdd(LoTVPlayerListClass Team, string TeamName)
    {
      LoTVTeamNodeClass NewNode = new LoTVTeamNodeClass(TeamName, Team, list_Head);
      list_Head = NewNode;
    }

    public string[] LoTVTeamNamesReturn(out int[] Ratings)
    {
      string[] Names = new string[16];
      Ratings = new int[16];
      int i = 0;
      LoTVTeamNodeClass NewHead = list_Head;
      if (NewHead != null)
        do
        {
          Names[i] = NewHead.team_Name;
          Ratings[i] = NewHead.team_Rating;
          NewHead = NewHead.node_NextNode;
          i++;
        }
        while (NewHead != null);
      return Names;
    }

    public LoTVTeamNodeClass LoTVTakeTeam()
    {

      LoTVTeamNodeClass Node = list_Head;
      LoTVTeamNodeClass MaxNode = new LoTVTeamNodeClass(null, null, null);
      MaxNode.team_Rating = int.MinValue;

            int j = 10;
            int k = j;
            k++;


      do
      {
        if (Node.team_Rating >= MaxNode.team_Rating)
          MaxNode = Node;
        Node = Node.node_NextNode;
      }
      while (Node != null);

      bool ok = false;
      if (list_Head == MaxNode)
      {
        list_Head = list_Head.node_NextNode;
        ok = true;
      }
      else
      {
        Node = list_Head;
        do
        {
          ok = (Node.node_NextNode != null) && (Node.node_NextNode == MaxNode);
          if (!ok)
            Node = Node.node_NextNode;
        }
        while (!ok && (Node != null));
        if (ok)
          Node.node_NextNode = Node.node_NextNode.node_NextNode;
      }
      return MaxNode;
    }
  }

  class LoTVPlayerNodeClass
  {
    public string player_Name;
    public int player_Rating;
    public LoTVPlayerNodeClass player_NextNode;

    public LoTVPlayerNodeClass(string Name, int Rating, LoTVPlayerNodeClass NextNode)
    {
      player_Name = Name;
      player_Rating = Rating;
      player_NextNode = NextNode;
    }
  }

  class LoTVPlayerListClass
  {
    public LoTVPlayerNodeClass list_Head;
    public LoTVPlayerListClass()
    {
      list_Head = null;
    }

    public void LoTVPlayerListAdd(string Name, int Rating)
    {
      LoTVPlayerNodeClass Player = new LoTVPlayerNodeClass(Name, Rating, list_Head);
      list_Head = Player;
    }
  }

  class LoTVListSorter
  {
    public static LoTVTeamListClass Sorter(LoTVTeamListClass OldList)
    {
      LoTVTeamListClass NewList = new LoTVTeamListClass();

      do
      {
        LoTVTeamNodeClass Team = OldList.LoTVTakeTeam();
        NewList.LoTVTeamsListAdd(Team.node_Team, Team.team_Name);
        NewList.list_Head.team_Rating = Team.team_Rating;
      }
      while (OldList.list_Head != null);
      return NewList;
    }
  }
}