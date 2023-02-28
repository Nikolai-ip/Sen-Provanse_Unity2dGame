using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGenerator : MonoBehaviour
{
    [SerializeField] private int _cellsRowAmount;
    [SerializeField] private int _cellsCollumsAmount;
    [SerializeField] private GameObject _cellPrefab;
    private Cells _cellsParent;
    private float _cellHeight;
    private float _cellWidth;
    private void Start()
    {
        _cellsParent = FindObjectOfType<Cells>(); 
        Clear();
        _cellHeight = _cellPrefab.transform.localScale.y;
        _cellWidth = _cellPrefab.transform.localScale.x;
        Generate();
        transform.position -= new Vector3(_cellsCollumsAmount / 2* _cellHeight, _cellsRowAmount / 2 * _cellWidth);
    }
    
    private void Generate()
    {
        for (int i = 0; i < _cellsRowAmount; i++)
        {
            for (int j = 0; j < _cellsCollumsAmount; j++)
            {             
                var cell = Instantiate(_cellPrefab, new Vector3(j*_cellWidth,i*_cellHeight), new Quaternion(),transform);
                cell.name = $"Cell {i} {j}";
                cell.transform.parent = _cellsParent.transform;
            }
        }
    }
    private void Clear()
    {
        foreach (var cell in _cellsParent.GetComponentsInChildren<Cell>())
        {
            Destroy(cell);
        }
    }
}
