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
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        else
        {
            Console.WriteLine($"dublicate value ({value} found. Not inserted)");
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value < Data)
        {
            // Search to the left
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
        else
        {
            return true;
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int left = 0;
        int right = 0;

        if (Left is not null)
        {
            left = 1 + Left.GetHeight();
        }

        if (Right is not null)
        {
            right = 1 + Right.GetHeight();
        }

        if (Left is null && Right is null)
        {
            return 1 + Math.Max(left, right);  // return the tree height plus 1 to get full height
        }
        else
        {
            return Math.Max(left, right);  // return the current max height found between left and right
        }
    }
}