public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        // Don't insert (return) if value is in tree
        else if (value == Data)
        {
            return;
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            if (Left is null)
                return false;
            else
                return Left!.Contains(value);
        }
        else if (value > Data)
        {
            if (Right is null)
                return false;
            else
                return Right!.Contains(value);
        }
        else
        {
            return false;
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = 0;
        int rightHeight = 0;

        if (Left is not null)
        {
            leftHeight += Left.GetHeight();
        }
        if (Right is not null)
        {
            rightHeight += Right.GetHeight();
        }

        if (leftHeight > rightHeight)
            return 1 + leftHeight;
        else if (leftHeight < rightHeight)
            return 1 + rightHeight;
        else if (leftHeight == rightHeight)
            return 1 + leftHeight;
        else return 1;
    }
}