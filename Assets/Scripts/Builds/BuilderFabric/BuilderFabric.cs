using UnityEngine;

public class BuilderFabric : MonoBehaviour
{
    [SerializeField] private Build _build;
    private PlayerCashManager _cashManager;
    private void Start()
    {
        _cashManager = FindObjectOfType<PlayerCashManager>();
    }

    public void InstantiateBuild()
    {
        if ((_cashManager.CurrentCash - _build.InitialCost) >= 0)
        {
            var buld = Instantiate(_build);
            buld.GetComponent<MouseBuildTracking>().StartMoveTheBuilding();
        }
    }
}
