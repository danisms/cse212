using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // SOLUTION:
        // step 1: create a fixed array of size length to store the generated multiple number.
        // step 2: create a variable called currentMultiple to track and store the identity of the current last number in the fixed array;
        // step 3: using a for loop to produce the multiple number by adding number to the currentMultiple variable and update the multiple array and currentMultiple variable
        // finaly: return the array when the loop is completed.

        var multiples = new double[length];  // create a fixed array to hold number multiples
        multiples[0] = number;  // add number as the first element in the array
        var currentMultiple = number;  // variable to track the current last number just inserted in the list

        for (var i = 1; i < length; i++)
        {
            currentMultiple += number;  // update current multiple to be added in the multiple array
            multiples[i] = currentMultiple;  // add the current multiple updated to array
        }

        // this solution performance analize to the big O of n i.e O(n);

        return multiples; // return the produced number multiple array
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static List<int> RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // SOLUTION:
        // Define a list to hold the splitted left part of the data using a range of the amount.
        // Define another list to hold the splited right part of the data using a range of the amount.
        // Clear the original refferenced list i.e data
        // Add right list to cleared data, and then the left list too so as to rotate the list.
        // return the rearranged new list.

        var leftList = data.GetRange(0, data.Count - amount);  // get the left list range of data using the amount
        Debug.WriteLine($"Data: {string.Join(", ", data)}");  // for debugging purpose
        Debug.WriteLine($"Amount: {amount}");  // for debugging purpose
        Debug.WriteLine($"Left List: {string.Join(", ", leftList)}");  // for debugging purpose
        Debug.WriteLine($"Data Check: {string.Join(", ", data)}");  // for debugging purpose


        var rightList = data.GetRange(data.Count - amount, amount);  // get the right list range of data using the amount
        Debug.WriteLine($"Right List: {string.Join(", ", rightList)}");  // for debugging purpose

        data.Clear();  // clear data

        data.AddRange(rightList);
        data.AddRange(leftList);  // add left list to right list i.e rotating list
        Debug.WriteLine($"Rotated Right List: {string.Join(", ", data)}");  // for debugging purpose
        return data;
    }
}
