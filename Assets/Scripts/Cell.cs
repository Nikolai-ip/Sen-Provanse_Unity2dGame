using UnityEngine;


public class Cell : MonoBehaviour
{
    private CellMousePosition mousePosition;
    private void Start()
    {
        mousePosition = GetComponentInParent<CellMousePosition>();  
    }
    private void OnMouseEnter()
    {
        mousePosition.CurrentSelectedCellByMousePosition = transform.position;
    }
}
