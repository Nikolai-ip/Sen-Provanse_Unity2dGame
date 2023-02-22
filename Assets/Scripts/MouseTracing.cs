using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class MouseTracing : MonoBehaviour
{
    private bool _isTrackeable = false;
    private bool _isTracked = false;
    private CellMousePosition mousePosition;
    [SerializeField] UnityEvent<bool> onTracked;
    private void OnMouseEnter()
    {
        _isTrackeable = true;
    }
    private void OnMouseExit()
    {
        _isTrackeable = false;
    }
    private void Start()
    {
        mousePosition = FindAnyObjectByType<CellMousePosition>();
    }
    private void Update()
    {
        CheckMouseClick();
        if (_isTracked)
        {
            transform.position = mousePosition.CurrentSelectedCellByMousePosition;
        }
    }
    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {

            if (_isTrackeable && !_isTracked)
            {
                _isTracked = true;
                onTracked.Invoke(_isTracked);
                return;
            }
            if (_isTracked)
            {
                _isTracked = false;
                onTracked.Invoke(_isTracked);
            }
        }
    }


}
