namespace Resampler
{
  public static class Logics
  {
    public static double SetY(int InY)
    {
      return 297 * InY / 985.0;
    }
    public static double SetX(int InX)
    {
      return 210 * InX / 761.0;
    }
  }
}
