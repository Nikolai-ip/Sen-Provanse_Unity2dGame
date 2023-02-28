using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    private Cell[] _cells;
    private SpriteRenderer[] _cellSprites;
    private void Start()
    {
        _cells= GetComponentsInChildren<Cell>();
        _cellSprites = GetComponentsInChildren<SpriteRenderer>();
        SetActiveCells(false);
    }
    public void SetActiveCells(bool active)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cellSprites[i].enabled = active;
        }
    }
}
