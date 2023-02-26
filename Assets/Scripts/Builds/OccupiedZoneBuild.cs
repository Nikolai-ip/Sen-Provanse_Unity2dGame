using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class OccupiedZoneBuild : OccupiedZone
{
    [SerializeField] private bool _isMovingMode = false; 
    public bool isCollisionWithOthersZones = false;
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
            foreach (var cell in _cells)
            {
                if (!cell.IsBusy)
                {
                    cell.SetOriginalColor();
                }

            }
            UpdateNeightborsCellsinList();
            isCollisionWithOthersZones = false;
            foreach (var cell in _cells)
            {
                if (cell.IsBusy)
                {
                    isCollisionWithOthersZones = true;
                }
                else
                {
                    cell.SetHightlightColor();
                }

            }
            await Task.Yield();
        }
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
}
