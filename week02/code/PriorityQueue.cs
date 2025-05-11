public class PriorityQueue
{
    private List<PriorityItem> _queue = new();
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
        //Removed minus 1 from the ...; index < _queue.Count - 1;... condition to get the last item
        for (int index = 1; index < _queue.Count; index++)
        {
            // Removed equal sign from ...Priority >= _queue... 
            // to get the front most item with highest priority 
            // (if both items have the same highest priority)
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = index;
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        //Add a .RemoveAt() to remove item from the queue;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }
    //Add new method to check queue and return value at specified index (used in EnqueueAtTheBack Test)
    public string CheckQueueIndex(int index)
    {
        var value = _queue[index].Value;
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