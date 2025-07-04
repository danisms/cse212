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

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // create two int variables one for getting the index value of list one
        // the other for getting the index value of list two
        int index1 = 0;
        int index2 = 0;

        // create a dynamic array of int to store the result to be returned by the function.
        List<int> result = [];

        // loop over select list and while looping:
        // check if the value from select is 1 
        // if it is, check if the 1st int variable is less than list1 if it is,
        // get the index value using int variable one, and add it to result list.
        // increment the variable count;
        // do same if select value is 2, but using the 2nd variable and list2.
        foreach (var value in select)
        {
            if (value == 1)
            {
                if (index1 < list1.Length)
                {
                    result.Add(list1[index1]);
                }
                index1++;
            }
            else
            {
                if (index2 < list2.Length)
                {
                    result.Add(list2[index2]);
                }
                index2++;
            }
        }
        return result.ToArray();  // convert from list(dynamic array) to an array (fixed array)
    }
}