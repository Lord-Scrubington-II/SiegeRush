using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0.0f, 5.0f)] float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TracePath());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TracePath()
    {
        foreach(var waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1.0f)
            {
                travelPercent += Time.deltaTime * speed;
                gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
