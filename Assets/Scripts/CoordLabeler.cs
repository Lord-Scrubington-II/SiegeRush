using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This class provides debug tools for viewing the backend coordinates of certain tiles.
/// Move this script to the Editor folder before building the game.
/// </summary>
[ExecuteInEditMode] [RequireComponent(typeof(TextMeshPro))]
public class CoordLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColour = Color.white;
    [SerializeField] Color notDeployableColour = Color.grey;

    TextMeshPro label;
    Vector2Int coords = new Vector2Int();
    WayPoint waypoint;

    void Awake()
    {
        label = this.GetComponent<TextMeshPro>();
        label.enabled = true;
        waypoint = this.GetComponentInParent<WayPoint>();
        DisplayCoords();
    }

    // Update is called once per frame
    void Update()
    {

        if (!Application.isPlaying)
        {
            DisplayCoords();
        }

        ColourLabelByContext();
        ToggleLabels();
    }

    private void ColourLabelByContext()
    {
        if (waypoint == null || !waypoint.CanDeployHere)
        {
            label.color = notDeployableColour;
        } 
        else
        {
            label.color = defaultColour;
        }
    }

    private void DisplayCoords()
    {
        coords.x = Mathf.RoundToInt(gameObject.transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coords.y = Mathf.RoundToInt(gameObject.transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"({coords.x}, {coords.y})";

        if(!(gameObject.scene.name == gameObject.transform.parent.name)) gameObject.transform.parent.name = coords.ToString();
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }
}
