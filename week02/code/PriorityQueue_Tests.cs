using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test ensures enqueue gets added at the back
    // Expected Result: [flashlight, calculator, staff, basket, laptop]
    // Defect(s) Found: None
    public void TestPriorityQueue_EnqueueAtTheBack()
    {
        var flashlight = new PriorityItem("Flashlight", 4);
        var calculator = new PriorityItem("Calculator", 6);
        var staff = new PriorityItem("Staff", 7);
        var basket = new PriorityItem("Basket", 3);
        var laptop = new PriorityItem("Laptop", 5);

        PriorityItem[] expectedResult = [flashlight, calculator, staff, basket, laptop];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(flashlight.Value, flashlight.Priority);
        priorityQueue.Enqueue(calculator.Value, calculator.Priority);
        priorityQueue.Enqueue(staff.Value, staff.Priority);
        priorityQueue.Enqueue(basket.Value, basket.Priority);
        priorityQueue.Enqueue(laptop.Value, laptop.Priority);

        int i = 0;
        while (i < expectedResult.Length)
        {
            var value = priorityQueue.CheckQueueIndex(i);
            Assert.AreEqual(expectedResult[i].Value, value);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Test ensures dequeue the item with the highest priority first
    // Expected Result: [staff, calculator, laptop, flashlight, basket]
    // Defect(s) Found: None
    public void TestPriorityQueue_HighPriorityDequeue()
    {
        //Same items but dequeue from the highest to lowest priority
        var flashlight = new PriorityItem("Flashlight", 4);
        var calculator = new PriorityItem("Calculator", 6);
        var staff = new PriorityItem("Staff", 7);
        var basket = new PriorityItem("Basket", 3);
        var laptop = new PriorityItem("Laptop", 5);

        PriorityItem[] expectedResult = [staff, calculator, laptop, flashlight, basket];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(flashlight.Value, flashlight.Priority);
        priorityQueue.Enqueue(calculator.Value, calculator.Priority);
        priorityQueue.Enqueue(staff.Value, staff.Priority);
        priorityQueue.Enqueue(basket.Value, basket.Priority);
        priorityQueue.Enqueue(laptop.Value, laptop.Priority);

        int i = 0;
        while (i < expectedResult.Length)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, value);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Test ensures dequeue the front most highest priority first if items have same priority
    // Expected Result: [basket, laptop, flashlight, calculator, staff]
    // Defect(s) Found: Dequeues the right most highest priority first (this is not a stack :D)
    public void TestPriorityQueue_FrontMostHighPriorityDequeue()
    {
        var flashlight = new PriorityItem("Flashlight", 6);
        var calculator = new PriorityItem("Calculator", 6);
        var staff = new PriorityItem("Staff", 6);
        var basket = new PriorityItem("Basket", 8);
        var laptop = new PriorityItem("Laptop", 8);

        PriorityItem[] expectedResult = [basket, laptop, flashlight, calculator, staff];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(flashlight.Value, flashlight.Priority);
        priorityQueue.Enqueue(calculator.Value, calculator.Priority);
        priorityQueue.Enqueue(staff.Value, staff.Priority);
        priorityQueue.Enqueue(basket.Value, basket.Priority);
        priorityQueue.Enqueue(laptop.Value, laptop.Priority);

        int i = 0;
        while (i < expectedResult.Length)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, value);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Test ensures exception is thrown if the queue is empty
    // Expected Result: A message that says "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Test ensures queue is empty after dequeue of all items
    // Expected Result: A message that says "The queue is empty."
    // Defect(s) Found: Exception should have thrown
    public void TestPriorityQueue_EmptyAfterDequeue()
    {
        var flashlight = new PriorityItem("Flashlight", 6);
        var calculator = new PriorityItem("Calculator", 6);
        var staff = new PriorityItem("Staff", 6);
        var basket = new PriorityItem("Basket", 8);
        var laptop = new PriorityItem("Laptop", 8);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(flashlight.Value, flashlight.Priority);
        priorityQueue.Enqueue(calculator.Value, calculator.Priority);
        priorityQueue.Enqueue(staff.Value, staff.Priority);
        priorityQueue.Enqueue(basket.Value, basket.Priority);
        priorityQueue.Enqueue(laptop.Value, laptop.Priority);

        //Count is the number of items in the PriorityQueue
        var count = 5;
        for (var i = 0; i < count; i++)
        {
            priorityQueue.Dequeue();
        }
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}