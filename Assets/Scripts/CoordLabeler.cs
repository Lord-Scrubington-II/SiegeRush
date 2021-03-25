using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class CoordLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coords = new Vector2Int();

    void Awake()
    {
        label = this.GetComponent<TextMeshPro>();
        DisplayCoords();
    }

    // Update is called once per frame
    void Update()
    {

        if (!Application.isPlaying)
        {
            DisplayCoords();
        }
    }

    private void DisplayCoords()
    {
        coords.x = Mathf.RoundToInt(gameObject.transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coords.y = Mathf.RoundToInt(gameObject.transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"({coords.x}, {coords.y})";

        gameObject.transform.parent.name = coords.ToString();
    }
}
