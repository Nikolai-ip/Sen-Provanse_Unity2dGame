using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCashManager : MonoBehaviour
{
    [SerializeField] private float _currentCash;
    private static PlayerCashManager instance = null;
    [SerializeField] private UnityEvent<object> onCashCnaged;
    public float CurrentCash { get { return _currentCash; } }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            onCashCnaged.Invoke(_currentCash);
            return;
        }
        Destroy(gameObject);

    }

    public void AddCash(float cash)
    {
        _currentCash += cash;
        onCashCnaged.Invoke(_currentCash);
    }
}
