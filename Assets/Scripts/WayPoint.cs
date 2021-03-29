using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Tower ballistaPrefab;
    [SerializeField] private bool canDeployHere;

    public bool CanDeployHere { get => canDeployHere; set => canDeployHere = value; }

    // Start is called before the first frame update
    void Start()
    {
        //treasury = FindObjectOfType<Treasury>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (canDeployHere)
        {
            bool built = ballistaPrefab.BuildTower(ballistaPrefab, transform.position);
            canDeployHere = !built;
        }    
    }
}
