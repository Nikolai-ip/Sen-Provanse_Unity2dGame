using System.Collections;
using UnityEngine;

public class BuildCashManager : MonoBehaviour
{
    
    private Build _build;
    
    protected PlayerCashManager playerCashManager;


    private void Initialize()   
    {
        _build = GetComponent<Build>();
        playerCashManager = FindObjectOfType<PlayerCashManager>();
    }
    private void OnEnable()
    {
        if (playerCashManager == null || _build == null) { Initialize(); }
        StartCoroutine(InCome());
        StartCoroutine(Rent());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator InCome()
    {
        var interval = new WaitForSeconds(_build.InComeInterval);
        while (true)
        {
            yield return interval;
            playerCashManager.AddCash(_build.InCome);
        }
    }
    private IEnumerator Rent()
    {
        var interval = new WaitForSeconds(_build.RentCostInterval);
        while (true)
        {
            yield return interval;
            playerCashManager.AddCash(-1 * _build.RentCost);
        }
    }
}
