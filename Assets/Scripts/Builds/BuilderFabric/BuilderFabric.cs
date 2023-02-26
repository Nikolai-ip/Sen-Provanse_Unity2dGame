using UnityEngine;

public class BuilderFabric : MonoBehaviour
{
    [SerializeField] private Build _build;
    public void InstantiateBuild()
    {
        
        var buld = Instantiate(_build);
        buld.GetComponent<MouseBuildTracking>().StartMoveTheBuilding();
    }
}
