using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();

    // Start is called before the first frame update
    void Start()
    {
        PrintWaypointNames();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrintWaypointNames()
    {
        foreach(var waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }
}
