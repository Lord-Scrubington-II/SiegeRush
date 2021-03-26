using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject ballistaPrefab;
    [SerializeField] bool canDeployHere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (canDeployHere)
        {
            GameObject.Instantiate(ballistaPrefab, gameObject.transform.position, Quaternion.identity);
            canDeployHere = false;
        }    
    }
}
