namespace _04_UnitTesting_01_Minimum
{
    public class Tools
    {
        public static int FindMin(int[] nums)
        {
            if (nums.Length == 0)
            {
                throw new ArgumentException("Empty set");
            }

            int min = int.MaxValue;

            foreach (int i in nums)
            {
                if (min > i)
                {
                    min = i;
                }
            }

            return min;
        }
    }
}
