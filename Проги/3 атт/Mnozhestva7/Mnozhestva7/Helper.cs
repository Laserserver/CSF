using System.Collections.Generic;

namespace Mnozhestva7
{
  class Helper
  {
    public HashSet<int> New = new HashSet<int>();

    public Helper (int A, int B, int C, int D, int E)
    {
      this.New.Add(A);
      this.New.Add(B);
      this.New.Add(C);
      this.New.Add(D);
      this.New.Add(E);
    }
    public static HashSet<int> Func(HashSet<int> X1, HashSet<int> X2, HashSet<int> X3)
    {
      HashSet<int> Y1 = new HashSet<int>(X2);
      Y1.ExceptWith(X3);
      HashSet<int> Y2 = new HashSet<int>(X1);
      Y2.ExceptWith(X3);
      HashSet<int> Y = new HashSet<int>(Y1);
      Y.UnionWith(Y2);
      return Y;
    }
  }
}
