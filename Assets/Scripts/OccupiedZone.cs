using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class OccupiedZone : MonoBehaviour 
{
    [SerializeField] protected List<Cell> _cells = new List<Cell>();
    public List<Cell> GetUpdatedCells { get { UpdateNeightborsCellsinList(); return _cells; } }  

    protected BoxCollider2D _zoneCollider;

    protected void UpdateNeightborsCellsinList()
    {
        _cells.Clear();
        foreach (var cellCollider in TakeNeightborsCells())
        {
            if (cellCollider.TryGetComponent(out Cell cell))
            {
                _cells.Add(cell);
            }
        }
    }
    protected List<Collider2D> TakeNeightborsCells()
    {
        List<Collider2D> cellsCollider = new List<Collider2D>();
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(LayerMask.GetMask("Cell"));
        _zoneCollider.OverlapCollider(contactFilter2D.NoFilter(), cellsCollider);
        return cellsCollider;
    }

}
