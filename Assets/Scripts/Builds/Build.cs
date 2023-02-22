using UnityEngine;

public abstract class Build : MonoBehaviour
{
    public float InCome => inCome;
    public float RentedPrice => rentedPrice;
    public float InComeInterval => inComeInterval;
    public float RentedPriceInterval => rentedPriceInterval;
    public float InitialCost => initialCost;

    [SerializeField] protected float inCome;
    [SerializeField] protected float rentedPrice;
    [SerializeField] protected float inComeInterval;
    [SerializeField] protected float rentedPriceInterval;
    [SerializeField] protected float initialCost;

    protected PlayerCashManager playerCashManager;
    protected void Initialize()
    {
        playerCashManager = FindObjectOfType<PlayerCashManager>();  
    }
}
