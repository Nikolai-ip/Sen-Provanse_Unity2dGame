using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMousePosition : MonoBehaviour
{
    private Vector2 _currentSelectedCellByMousePosition;

    public Vector2 CurrentSelectedCellByMousePosition 
    {
        get => _currentSelectedCellByMousePosition;
        set
        {
            _currentSelectedCellByMousePosition = value;
            Debug.Log(_currentSelectedCellByMousePosition);
        }
    }

}
