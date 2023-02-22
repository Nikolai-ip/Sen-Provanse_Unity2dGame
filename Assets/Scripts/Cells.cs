using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    private Cell[] _cells;
    private void Start()
    {
        _cells= GetComponentsInChildren<Cell>();
        foreach (var cell in _cells)
        {
            cell.gameObject.SetActive(false);
        }
    }
    public void SetActiveObject(bool active)
    {
        foreach (var cell in _cells)
        {
            cell.gameObject.SetActive(active);
        }
    }
}
