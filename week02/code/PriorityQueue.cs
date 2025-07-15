public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public int Length => _queue.Count;


    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++)
        {
            // NOTE: the index starts from 1 not 0 and _queue.Count was having '- 1'.
            // I removed the '- 1' so as to allow the loop get to the last value in the _queue.
            int currentHighestPriorityIndex = _queue[highPriorityIndex].Priority;
            int currentPriorityIndex = _queue[index].Priority;
            // make sure dequeue follows FIFO strategy by using only > and not >= in comparison
            if (currentPriorityIndex > currentHighestPriorityIndex)
            {
                highPriorityIndex = index;
            }
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);  // highest priority item from queue
        Console.WriteLine($"Removed From Queue: {value}");

        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}