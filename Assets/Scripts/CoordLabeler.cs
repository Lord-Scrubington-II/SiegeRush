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
    [SerializeField] Color exploredColour = Color.yellow;
    [SerializeField] Color pathColour = new Color(255, 120, 0); //orange

    TextMeshPro label;
    Vector2Int coords = new Vector2Int();
    GridManager gridManager;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = this.GetComponent<TextMeshPro>();
        label.enabled = true;
        
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
        if (gridManager == null) { return; }

        Node node = gridManager.FindNodeAt(coords);

        if (node != null)
        {
            if (!node.isWalkable)
            {
                label.color = notDeployableColour;
            }
            else if (node.isPath)
            {
                label.color = pathColour;
            }
            else if (node.isExplored)
            {
                label.color = exploredColour;
            }
            else
            {
                label.color = defaultColour;
            }
        }
    }

    private void DisplayCoords()
    {
        coords.x = Mathf.RoundToInt(gameObject.transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coords.y = Mathf.RoundToInt(gameObject.transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"({coords.x}, {coords.y})";

        if (!(gameObject.scene.name == gameObject.transform.parent.name)) gameObject.transform.parent.name = coords.ToString();
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }
}
