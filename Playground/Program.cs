using Graphs;

AdjacentListGraph myALG = new AdjacentListGraph();

myALG.AddVertex(0);
myALG.AddVertex(1);
myALG.AddVertex(2);
myALG.AddVertex(3);
myALG.AddVertex(4);
myALG.AddVertex(5);
myALG.AddVertex(6);

myALG.AddEdge(3, 1);
myALG.AddEdge(3, 4);
myALG.AddEdge(4, 2);
myALG.AddEdge(4, 5);
myALG.AddEdge(1, 2);
myALG.AddEdge(1, 0);
myALG.AddEdge(0, 2);
myALG.AddEdge(6, 5);

myALG.ShowConnections();

/*
Answer:
0--> 1 2
1--> 3 2 0
2--> 4 1 0
3--> 1 4
5--> 4 5
6--> 5
*/