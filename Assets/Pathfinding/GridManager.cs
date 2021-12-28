using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    private Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };


    public Dictionary<Vector2Int, Node> Grid { get => grid; private set => grid = value; }

    private void Awake()
    {
        PreProcessGrid();
    }

    public Node FindNodeAt(Vector2Int coords)
    {
        try
        {
            return grid[coords];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
        
    }

    private void PreProcessGrid()
    {

        // instantiate & index the Nodes
        for(int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                Node newNode = new Node(coordinates, true);
                grid.Add(coordinates, newNode);

                //Debug.Log($"This node is at {Grid[coordinates].coordinates}; is walkable: {Grid[coordinates].isWalkable}");
            }
        }

        // index neighbours
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                foreach (Vector2Int dir in directions)
                {
                    Vector2Int coordinates = new Vector2Int(x, y);
                    Vector2Int neighbourCoords = coordinates + dir;
                    Node currentNode = grid[coordinates];
                    Node neighbour = grid[neighbourCoords];

                    if (validPoint(neighbourCoords) && neighbour.isWalkable)
                    {
                        currentNode.neighbours.Add(neighbour);
                    }
                }
            }
        }
    }

    private bool validPoint(Vector2Int cell)
    {
        if(cell.x < 0 || cell.y < 0 || cell.x >= gridSize.x || cell.y >= gridSize.y)
        {
            return false;
        } return true;
    }
}
