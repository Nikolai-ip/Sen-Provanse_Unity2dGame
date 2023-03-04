using UnityEngine;

public class BuildInfoController : MonoBehaviour
{
    [SerializeField] private InfoCard _infoBuildCard;
    private void Start()
    {
        MouseBuildTracker mouseBuildTracker = GetComponent<MouseBuildTracker>();
        _infoBuildCard = Instantiate(_infoBuildCard);
        _infoBuildCard.transform.SetParent(GameObject.FindWithTag("BuildInfoPoint").transform, false);
        _infoBuildCard.gameObject.SetActive(false);
    }

    [System.Obsolete]
    private void ShowInfoCard()
    {
        if (!_infoBuildCard.gameObject.active)
            _infoBuildCard.gameObject.SetActive(true);
        else
            _infoBuildCard.gameObject.SetActive(false);
    }
}
