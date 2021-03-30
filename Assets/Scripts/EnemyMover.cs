using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0.0f, 5.0f)] float speed = 1.0f;

    Enemy thisEnemy;

    // OnEnable is called whenever this component is enabled
    void OnEnable()
    {
        DiscoverPath();
        ResetPosition();
        StartCoroutine(TracePath());
    }

    private void Start()
    {
        thisEnemy = gameObject.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DiscoverPath()
    {
        path.Clear();

        //This ensures that waypoitns are discovered in the order they are declared in hierarchy
        GameObject waypointGroup = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform childInHierarchy in waypointGroup.transform)
        {
            WayPoint waypoint = childInHierarchy.GetComponent<WayPoint>();

            if(waypoint != null) path.Add(waypoint);
        }
    }

    private IEnumerator TracePath()
    {
        foreach(var waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            //smooth movement between waypoints with linear interpolation
            while(travelPercent < 1.0f)
            {
                travelPercent += Time.deltaTime * speed;
                gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        //end-of-path directives
        thisEnemy.StealGold();
        this.gameObject.SetActive(false);
    }

    void ResetPosition()
    {
        transform.position = path[0].transform.position;
    }
}
