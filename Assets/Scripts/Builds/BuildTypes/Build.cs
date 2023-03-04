using UnityEngine;

public abstract class Build : MonoBehaviour
{
    public string TypeName;
    public float InCome => inCome;
    public float RentCost => rentCost;
    public float InComeInterval => inComeInterval;
    public float RentCostInterval => rentInterval;
    public float InitialCost => initialCost;
    public int OccupiedHeight => occupiedHeight;
    public int OccupiedWidth => occupiedWidth;
    public float BuildingTime => buildingTime;

    [SerializeField] protected float inCome;
    [SerializeField] protected float rentCost;
    [SerializeField] protected float inComeInterval;
    [SerializeField] protected float rentInterval;
    [SerializeField] protected float initialCost;
    [SerializeField] protected int occupiedHeight;
    [SerializeField] protected int occupiedWidth;
    [SerializeField] protected float buildingTime;
    protected void Initialize()
    {

    }
    public void SetInhabitants()
    {

    }
}
