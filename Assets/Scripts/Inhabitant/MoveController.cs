using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private PathFinder _pathFinder;
    [SerializeField] private float _speed;
    private bool _isMoving = false;
    [SerializeField] private float _desiredDuration;
    private float elapsedTime;
    [SerializeField] private Cell _optimalCell;

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
        var originPos = transform.position;
        _optimalCell = _pathFinder.FindOptimalCell();
        var targetPos = _optimalCell.transform.position;
        while (elapsedTime / _desiredDuration<1) 
        {
            elapsedTime+= Time.deltaTime;
            transform.position = Vector3.Lerp(originPos, targetPos, elapsedTime/ _desiredDuration);
            yield return null;
        }
        elapsedTime = 0;
        _isMoving = false;
    }
}
