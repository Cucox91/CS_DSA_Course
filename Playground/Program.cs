using StackAndQueues;

MySSQueue ssq = new MySSQueue();
ssq.Push(1);
ssq.Push(2);
ssq.Push(3);
ssq.Push(4);
Console.WriteLine(ssq.Pop());
ssq.Push(5);
Console.WriteLine(ssq.Pop());
Console.WriteLine(ssq.Pop());
Console.WriteLine(ssq.Pop());
Console.WriteLine(ssq.Pop());

// Console.WriteLine(ssq.Peek());

// Console.WriteLine(ssq.Empty());
