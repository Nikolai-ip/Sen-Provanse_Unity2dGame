using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private PathFinder _pathFinder;
    private bool _isMoving = false;
    [SerializeField] private float _speed;
    private float elapsedTime;
    private Cell _optimalCell;

    private void Start()
    {
        _pathFinder = GetComponent<PathFinder>();
        
    }
    private void Update()
    {
        if (!_isMoving)
        {
            _isMoving = true;
            StartCoroutine(Move());
        }
    }
    private IEnumerator Move()
    {
        var delay = new WaitForFixedUpdate();
        var originPos = transform.position;
        _optimalCell = _pathFinder.FindOptimalCell();
        var targetPos = _optimalCell.transform.position;
        while (elapsedTime / (1/_speed)<1) 
        {
            elapsedTime+= Time.deltaTime;
            transform.position = Vector3.Lerp(originPos, targetPos, elapsedTime/ (1 / _speed));
            yield return delay;
        }
        elapsedTime = 0;
        _isMoving = false;
    }
}
