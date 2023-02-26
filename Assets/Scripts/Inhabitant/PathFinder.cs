using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private OccupiedZoneInhabitant _occupiedZoneInhabitant;
    public Cell target;
    private Dictionary<Cell, float> _cellsWeight = new Dictionary<Cell, float>();
    [SerializeField] private List<Cell> prevPath;
    private Cell _optimalCell = null;
    private void Start()
    {
        _occupiedZoneInhabitant = GetComponentInChildren<OccupiedZoneInhabitant>();
    }

    public Cell FindOptimalCell()
    {
        var neightborCells = _occupiedZoneInhabitant.GetUpdatedCells;
        _cellsWeight.Clear();
        SetWeghtForCells(neightborCells);
        if (_optimalCell!=target) 
            prevPath.Add(_optimalCell);
        _optimalCell = _cellsWeight.FirstOrDefault(x => x.Value == _cellsWeight.Min(cell => cell.Value)).Key;
        return _optimalCell;
    }
    private void SetWeghtForCells(List<Cell> neightborCells)
    {
        foreach (var cell in neightborCells)
        {
            if (!cell.IsBusy && !prevPath.Contains(cell))
            {
                float distanceToCell = Vector2.Distance(transform.position, cell.gameObject.transform.position);
                if (distanceToCell > 0)
                {
                    _cellsWeight.Add(cell, CalculateWeight(cell));
                }

            }
        }
    }
    private float CalculateWeight(Cell cell)
    {
        return Vector2.Distance(transform.position, cell.gameObject.transform.position) + Vector2.Distance(target.gameObject.transform.position, cell.gameObject.transform.position);
    }
}
