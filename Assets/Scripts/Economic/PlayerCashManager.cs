using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCashManager : MonoBehaviour
{
    [SerializeField] private float _currentCash;

    public void AddCash(float cash)
    {
        _currentCash += cash;
    }
}
