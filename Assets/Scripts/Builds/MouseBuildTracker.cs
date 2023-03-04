using System;
using Unity.VisualScripting;
using UnityEngine;

public class MouseBuildTracker : MonoBehaviour
{
    private bool _isMouseHover = false;
    private bool _isTracked = false;
    public bool buildIsModify = true;
    private CellMousePosition mousePosition;
    Cells _cells;
    [SerializeField] private OccupiedZoneBuild _builtZone;
    private BoxCollider2D _boxCollider;
    [SerializeField] private float dX;
    [SerializeField] private float dY;
    private Builder _builder;
    public event Action<Build> onBuildIsClicked;
    private Build _build;
    private BuildJournal _buildJournal;
    private UIBuildManager _uIBuildManager;
    private void Awake()
    {
        _cells = FindObjectOfType<Cells>();
        mousePosition = FindAnyObjectByType<CellMousePosition>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _builtZone = GetComponentInChildren<OccupiedZoneBuild>();
        _builder = GetComponent<Builder>();
        _build = GetComponent<Build>();
        _buildJournal = FindObjectOfType<BuildJournal>();
        _uIBuildManager = FindObjectOfType<UIBuildManager>();   
    }

    private void Update()
    {
        _isMouseHover = false;
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
                _isMouseHover = true;
            }
        }
    }
    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {

            if (CanStartMoveBuilding())
            {
                StartMoveTheBuilding();
                return;
            }
            if (CanPutBuild())
            {
                PutBuild();
                return;
            }
            if (!buildIsModify && _isMouseHover)
            {
                _uIBuildManager.ShowUI(_build);
                return;
            }
            _uIBuildManager.HideUi(_build);

        }
    }
    private bool CanStartMoveBuilding() => !_isTracked && buildIsModify && _isMouseHover;
    private bool CanPutBuild() => _isTracked && !_builtZone.IsCollisionWithOthersZones && buildIsModify && _isMouseHover;

    public void StartMoveTheBuilding()
    {
        _builtZone.TurnOff();
        _builtZone.MovingMode();
        _isTracked = true;  
        _cells.SetActiveCells(true);
    }
    private void PutBuild()
    {
        buildIsModify = false;
        _builtZone.TurnOn();
        _isTracked = false;
        _cells.SetActiveCells(false);
        _builder.StartBuilding();
        _buildJournal.Add(_build);
    }
    private void MoveTheBuilding()
    {
        Vector2 mouse = mousePosition.CurrentSelectedCellByMousePosition;
        transform.position = new Vector2(mouse.x+dX,mouse.y+dY);
    }


}
