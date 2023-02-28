using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class MouseBuildTracking : MonoBehaviour
{
    private bool _isTrackeable = false;
    private bool _isTracked = false;
    private CellMousePosition mousePosition;
    Cells _cells;
    [SerializeField] private OccupiedZoneBuild _builtZone;
    private BoxCollider2D _boxCollider;
    [SerializeField] private float dX;
    [SerializeField] private float dY;
    private Builder _builder;

    private void Awake()
    {
        _cells = FindObjectOfType<Cells>();
        mousePosition = FindAnyObjectByType<CellMousePosition>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _builtZone = GetComponentInChildren<OccupiedZoneBuild>();
        _builder= GetComponent<Builder>();
    }

    private void Update()
    {
        _isTrackeable = false;
        CheckMouseHover();
        CheckMouseClick();
        if (_isTracked)
        {
            MoveTheBuilding();
        }
    }
    private void CheckMouseHover()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,int.MaxValue,LayerMask.GetMask("Build"));
        if (hit.collider != null)
        {
            if (hit.collider == _boxCollider)
            {
                _isTrackeable = true;
            }
        }
    }
    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {

            if (_isTrackeable && !_isTracked)
            {
                StartMoveTheBuilding();
                return;
            }
            if (_isTracked && !_builtZone.isCollisionWithOthersZones)
            {
                PutBuild();
            }
        }
    }
    public void StartMoveTheBuilding()
    {
        _builtZone.TurnOff();
        _builtZone.MovingMode();
        _isTracked = true;  
        _cells.SetActiveCells(true);
    }
    private void PutBuild()
    {
        _builtZone.TurnOn();
        _isTracked = false;
        _cells.SetActiveCells(false);
        _builder.StartBuilding();
    }
    private void MoveTheBuilding()
    {
        Vector2 mouse = mousePosition.CurrentSelectedCellByMousePosition;
        transform.position = new Vector2(mouse.x+dX,mouse.y+dY);
    }


}
