using Trees;

BST myBst = new BST();

myBst.Insert(50);
myBst.Insert(30);
myBst.Insert(70);
myBst.Insert(20);
myBst.Insert(40);
myBst.Insert(60);
myBst.Insert(80);
myBst.Insert(10);
myBst.Insert(35);
myBst.Insert(65);

Console.WriteLine("Pre Order");
myBst.TraversePreOrder();

Console.WriteLine("In Order");
myBst.TraverseInOrder();

Console.WriteLine("Post Order");
myBst.TraversePostOrder();

// Console.WriteLine("Find " + myBst.LookupNode(50).Value);
// Console.WriteLine("Find " + myBst.LookupNode(60).Value);
// Console.WriteLine("Find " + myBst.LookupNode(80).Value);

// var result = myBst.LookupNode(100);
// var stringVal = result != null ? result.Value.ToString() : "NULL";
// Console.WriteLine("Find " + stringVal);



myBst.Remove(10);
myBst.Remove(30);
myBst.Remove(50);

Console.WriteLine("After Removals:");

Console.WriteLine("Pre Order");
myBst.TraversePreOrder();

Console.WriteLine("In Order");
myBst.TraverseInOrder();

Console.WriteLine("Post Order");
myBst.TraversePostOrder();

