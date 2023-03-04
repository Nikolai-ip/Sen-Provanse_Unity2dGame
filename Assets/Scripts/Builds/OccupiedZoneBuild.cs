using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class OccupiedZoneBuild : OccupiedZone
{
    [SerializeField] private bool _isMovingMode = false; 
    private bool isCollisionWithOthersZones = false;
    public bool IsCollisionWithOthersZones { get { return isCollisionWithOthersZones; } private set { isCollisionWithOthersZones = value;} } 
    public void TurnOn()
    {
        _cells.Clear();
        _zoneCollider.enabled = true;
        OccupieZone();
        _zoneCollider.enabled = false;
        _isMovingMode = false;
    }
    public void TurnOff()
    {
        _zoneCollider.enabled = false;
        foreach (var cell in _cells)
        {
            cell.IsBusy = false;
        }
        _cells.Clear();
    }

    private void Awake()
    {
        _zoneCollider = GetComponent<BoxCollider2D>();
        TurnOff();
    }
    public void MovingMode()
    {
        _isMovingMode = true;
        _zoneCollider.enabled = true;
        CheckNeightborsCells();
    }
    private async void CheckNeightborsCells()
    {
        while (_isMovingMode)
        {
            SetCellsOriginalColor();
            UpdateNeightborsCellsinList();
            SetCellsHighlightColor();
            IsCollisionWithOthersZones = CheckCollisionWithOthersZones();
            await Task.Yield();
        }
    }

    private bool CheckCollisionWithOthersZones()
    {
        foreach (var cell in _cells)
            if (cell.IsBusy)
                return true;
        return false;
    }
    private void OccupieZone()
    {
        foreach (var cellCollider in TakeNeightborsCells())
        {
            if (cellCollider.TryGetComponent(out Cell cell))
            {
                _cells.Add(cell);
                cell.IsBusy = true;
            }
        }
    }
    private void SetCellsOriginalColor()
    {
        foreach (var cell in _cells)
            if (!cell.IsBusy)
                cell.SetOriginalColor();
    }
    private void SetCellsHighlightColor()
    {
        foreach (var cell in _cells)
            if (!cell.IsBusy)
                cell.SetHightlightColor();

    }
}
