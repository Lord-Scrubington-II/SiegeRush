using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    private Node origin;
    private Node destination;
    private List<Node> path;

    /// <summary>
    /// Justification: because we may wish to use a pathfinding algorithm besides BFS at runtime.
    /// </summary>
    /// <param name="origin">The origin node.</param>
    /// <param name="destination">The desination node.</param>
    /// <returns>A list defining the node path.</returns>
    public delegate List<Node> PathFindingFunction(Node origin, Node destination);
    private PathFindingFunction PathFind;

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    private void Awake()
    {
        PathFind = BFS;
        gridManager = FindObjectOfType<GridManager>();
        
        if (gridManager != null)
        {
            grid = gridManager.Grid;
        }

    }

    private void Start()
    {
        // ExploreNeighbours();
        ChartPath();
    }

    private void ChartPath()
    {
        this.path = PathFind(origin, destination);
        foreach (Node node in path)
        {
            node.isPath = true;
        }
    }

    private void ExploreNeighbours()
    {
        List<Node> neighbours = new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = currentSearchNode.coordinates + direction;

            if(grid.ContainsKey(neighbourCoords))
            {
                neighbours.Add(grid[neighbourCoords]);

                // TODO: remove after testing
                /*
                grid[neighbourCoords].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
                */
            }
        }
    }

    private List<Node> BFS(Node origin, Node destination)
    {
        // this dictionary maps nodes to ther predecessors
        Dictionary<Node, Node> ParentLookupDict = new Dictionary<Node, Node>();

        // the BFS Queue performs BFS
        Queue<Node> BFSQueue = new Queue<Node>();
        BFSQueue.Enqueue(origin);

        // the reversed path buffer, which collects the path nodes in reverse order 
        Stack<Node> rPathBuffer = new Stack<Node>();

        // the path buffer, which represents the path from the origin to the destination
        List<Node> pathBuffer = new List<Node>();

        // BFS Time, Gamers
        while(BFSQueue.Count != 0)
        {
            Node currentNode = BFSQueue.Dequeue();

            // found the destination
            if (currentNode == destination)
            {
                while (currentNode != origin)
                {
                    rPathBuffer.Push(currentNode);
                    currentNode = ParentLookupDict[currentNode];
                }
                rPathBuffer.Push(currentNode); // this one is the origin itself. may or may not be needed.
                
                // flush the reversed path buffer into the path buffer
                while(rPathBuffer.Count > 0)
                {
                    pathBuffer.Add(rPathBuffer.Pop());
                }
                return pathBuffer;
            }
            else
            {
                // queue up new neighbours
                foreach (Node neighbour in currentNode.neighbours)
                {
                    if (!neighbour.isExplored && neighbour.isWalkable)
                    {
                        // assign neighbour its parent and enqueue it
                        ParentLookupDict[neighbour] = currentNode;
                        neighbour.isExplored = true;
                        BFSQueue.Enqueue(neighbour);
                    }
                }
            }
        }

        return pathBuffer;
    }
}
