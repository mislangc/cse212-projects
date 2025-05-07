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

        // Make a new list to store the multiple values
        var result = new double[length];

        //Define a constant multiplier starting at 1
        var multiplier = 1;

        //Loop for getting the number and multiplying it to the multiplier. Length variable will be the amount this loop will repeat.
        for (int i = 0; i < length; i++)
        {
            //After multiplying, add 1 to the multiplier
            var value = number * multiplier++;

            //Store the product in a variable called value and add it to the list at index i
            result[i] = value;
        }

        //Return the list of multipliers after the specified length is supplied
        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Get the values being rotated to the front of the list
        List<int> values = data.GetRange(data.Count - amount, amount);

        //Get the values to be adjusted to the right
        List<int> initValues = data.GetRange(0, data.Count - amount);

        //Delete all the items in the list
        data.Clear();

        //Insert the rotated values at the beginning of the list
        data.InsertRange(0, values);

        //Insert the rest of the values at the end of the last added values
        data.InsertRange(amount, initValues);

        return;
    }
}
