using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public List<Node> neighbours;

    public Node(Vector2Int coordinates, bool walkable)
    {
        this.coordinates = coordinates;
        this.isWalkable = walkable;
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() == typeof(Node))
        {
            Node that = (Node)obj;
            if (this.coordinates == that.coordinates
                && this.isWalkable == that.isWalkable
                && this.isExplored == that.isExplored
                && this.isPath == that.isPath
                && this.neighbours.Equals(that.neighbours))
            {
                return true;
            }
        }
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
