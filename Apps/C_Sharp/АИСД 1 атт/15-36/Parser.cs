namespace _15_36
{
    class Parser
    {
        public static int[] Parse(string Input)
        {
            string[] Arr = Input.Replace("\r", "").Split('\n');
            int[] Out = new int[int.Parse(Arr[0])];
            for (int i = 0; i < Out.Length; i++)
                Out[i] = int.Parse(Arr[i + 1]);
            return Out;
        }
    }
}
