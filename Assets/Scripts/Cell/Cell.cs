using System;
using UnityEngine;


public class Cell : MonoBehaviour
{
    private CellMousePosition mousePosition;
    [SerializeField] private bool isBusy = false;
    [SerializeField] private Color _originColor;
    [SerializeField] private Color _hightlightColor;
    [SerializeField] private Color _occupiedColor;
    private SpriteRenderer _sp;
    public bool IsBusy 
    { set 
        { 
            isBusy = value;
            SetCellIsOccupied(isBusy);
        }
        get { return isBusy; }
    }  
    private void Start()
    {
        mousePosition = GetComponentInParent<CellMousePosition>();
        _sp = GetComponent<SpriteRenderer>();   
    }
    private void OnMouseEnter()
    {
        mousePosition.CurrentSelectedCellByMousePosition = transform.position;
    }
    private void SetCellIsOccupied(bool isOccupied)
    {
        ChangeColor(isOccupied);
    }
    private void ChangeColor(bool isOccupied)
    {
        if (_sp != null) { _sp.color = isOccupied ? _occupiedColor : _originColor; }
      
    }   
    public void SetHightlightColor()
    {
        _sp.color = _hightlightColor;
    }
     public void SetOriginalColor()
    {
        _sp.color = _originColor;

    }

}
