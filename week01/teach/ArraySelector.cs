public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static List<int> ListSelector(int[] list1, int[] list2, int[] select)
    {
        var results = new List<int>();
        int array1index = 0;
        int array2index = 0;
        foreach (int num in select)
        {
            if (num == 1)
            {
                results.Add(list1[array1index]);
                array1index++;
            }
            if (num == 2)
            {
                results.Add(list2[array2index]);
                array2index++;
            }
        }
        return results;
    }
}