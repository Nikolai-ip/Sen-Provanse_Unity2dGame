using UnityEngine;

public abstract class Build : MonoBehaviour
{
    public float InCome => inCome;
    public float RentCost => rentCost;
    public float InComeInterval => inComeInterval;
    public float RentCostInterval => rentInterval;
    public float InitialCost => initialCost;
    public int OccupiedHeight => occupiedHeight;
    public int OccupiedWidth => occupiedWidth;

    [SerializeField] protected float inCome;
    [SerializeField] protected float rentCost;
    [SerializeField] protected float inComeInterval;
    [SerializeField] protected float rentInterval;
    [SerializeField] protected float initialCost;
    [SerializeField] protected int occupiedHeight;
    [SerializeField] protected int occupiedWidth;

    protected void Initialize()
    {
    }
}