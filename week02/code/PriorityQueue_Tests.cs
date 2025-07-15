using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 4 company roles to queue and check if enqueue is being queued propertly
    // i.e. Each new role goes to the back of the queue.
    // Enqueue order: ("p.r.o", 5), ("secretary", 9), ("vice-president", 8), ("president", 10)
    // Expected Result: [("p.r.o", 5), ("secretary", 9), ("vice-president", 8), ("president", 10)]
    // Defect(s) Found: no defect found
    public void TestPriorityQueue_CheckEnqueue()
    {
        var priorityQueue = new PriorityQueue();
        // create roles
        var president = new PriorityItem("president", 10);
        var secretary = new PriorityItem("secretary", 9);
        var vicePresident = new PriorityItem("vice-president", 8);
        var pro = new PriorityItem("p.r.o", 5);

        List<PriorityItem> expectedResult = [pro, secretary, vicePresident, president];
        // add roles to priority queue
        priorityQueue.Enqueue(pro.Value, pro.Priority);
        priorityQueue.Enqueue(secretary.Value, secretary.Priority);
        priorityQueue.Enqueue(vicePresident.Value, vicePresident.Priority);
        priorityQueue.Enqueue(president.Value, president.Priority);


        // check enqueue
        Debug.WriteLine($"priorityQueue: {priorityQueue.ToString()}");

        // compare result
        Assert.AreEqual($"[{string.Join(", ", expectedResult)}]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Add 4 company roles in order of ranking to the priority queue and dequeue according to priority
    // i.e. from highest priority to lowest priority.
    // [("p.r.o", 5), ("secretary", 9), ("vice-president", 8), ("president", 10)]
    // Expected Result: [("president", 10), ("secretary", 9), ("vice-president", 8), ("p.r.o", 5)]
    // Defect(s) Found: The Dequeue method fail to remove item from the queue their by causing an infinit loop.
    // Also Assert failed due to expected result not matching i.e. The Dequeue Method is having an error.
    // Fail Message: Assert.AreEqual failed. Expected:<secretary>. Actual:<vice-president>.
    public void TestPriorityQueue_CheckDequeue()
    {
        var priorityQueue = new PriorityQueue();
        // create roles
        var president = new PriorityItem("president", 10);
        var secretary = new PriorityItem("secretary", 9);
        var vicePresident = new PriorityItem("vice-president", 8);
        var pro = new PriorityItem("p.r.o", 5);

        List<String> expectedResult = [president.Value, secretary.Value, vicePresident.Value, pro.Value];
        // add roles to priority queue
        priorityQueue.Enqueue(pro.Value, pro.Priority);
        priorityQueue.Enqueue(secretary.Value, secretary.Priority);
        priorityQueue.Enqueue(vicePresident.Value, vicePresident.Priority);
        priorityQueue.Enqueue(president.Value, president.Priority);


        // check enqueue
        Debug.WriteLine($"priorityQueue: {priorityQueue.ToString()}");

        // create variable to get actual result
        List<String> actualResult = [];

        // dequeue priority queue
        while (priorityQueue.Length > 0)
        {
            var dequeued = priorityQueue.Dequeue();
            actualResult.Add(dequeued);
            Debug.WriteLine($"Actual: {dequeued}");
        }
        Debug.WriteLine($"Current Priority Queue: {priorityQueue.ToString()}");

        // compare result
        for (int i = 0; i < expectedResult.Count - 1; i++)
        {
            Assert.AreEqual(expectedResult[i], actualResult[i]);
        }
    }

    [TestMethod]
    // Scenario: Add 5 company roles in order of ranking to the priority queue and dequeue in order of priority
    // i.e. from highest to lowest priority with same priority following FIFO queuing strategy.
    // [("staff-2", 2), ("secretary", 9), ("vice-president", 8), ("staff-1", 2), ("president", 10)]
    // Expected Result: [("president", 10), ("secretary", 9), ("vice-president", 8), ("p.r.o", 5), ("staff-2", 2), ("staff-1", 2)]
    // Defect(s) Found: The Dequeue method fail to remove item from the queue their by causing an infinit loop.
    //                  Also Assert failed due to expected result not matching i.e. The Dequeue Method is having an error.
    //                  Fail Message: Assert.AreEqual failed. Expected:<secretary>. Actual:<vice-president>.
    //                  Dequeuing did not follow the FIFO strategy.
    public void TestPriorityQueue_CheckDequeue_SameMultiplePriority()
    {
        var priorityQueue = new PriorityQueue();
        // create roles
        var president = new PriorityItem("president", 10);
        var secretary = new PriorityItem("secretary", 9);
        var vicePresident = new PriorityItem("vice-president", 8);
        var pro = new PriorityItem("p.r.o", 5);
        var staff1 = new PriorityItem("staff-1", 2);
        var staff2 = new PriorityItem("staff-2", 2);

        // add roles to priority queue
        priorityQueue.Enqueue(staff2.Value, staff2.Priority);
        priorityQueue.Enqueue(pro.Value, pro.Priority);
        priorityQueue.Enqueue(secretary.Value, secretary.Priority);
        priorityQueue.Enqueue(vicePresident.Value, vicePresident.Priority);
        priorityQueue.Enqueue(staff1.Value, staff1.Priority);
        priorityQueue.Enqueue(president.Value, president.Priority);

        // expected result output
        List<String> expectedResult = [president.Value, secretary.Value, vicePresident.Value, pro.Value, staff2.Value, staff1.Value];

        // check enqueue
        Debug.WriteLine($"priorityQueue: {priorityQueue.ToString()}");

        // create variable to get actual result
        List<String> actualResult = [];

        // dequeue priority queue
        while (priorityQueue.Length > 0)
        {
            var dequeued = priorityQueue.Dequeue();
            actualResult.Add(dequeued);
            Debug.WriteLine($"Actual: {dequeued}");
        }
        Debug.WriteLine($"Current Priority Queue: {priorityQueue.ToString()}");

        // compare result
        for (int i = 0; i < expectedResult.Count - 1; i++)
        {
            Assert.AreEqual(expectedResult[i], actualResult[i]);
        }
    }

    [TestMethod]
    // Scenario: Try to dequeue an empty priority queue. This should throw and exception.
    // Expected Result: An exception of type InvalidOperationException
    // Defect(s) Found: no defect found.
    public void TestPriorityQueue_CheckDequeue_Empty()
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
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

}