using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuildManager : MonoBehaviour
{
    [SerializeField]private InfoCard _infoCard;

    void Awake()
    {
        _infoCard = FindObjectOfType<InfoCard>();
    }

    public void ShowUI(Build build)
    {
        _infoCard.ShowCard(build);
    }
    public void HideUi(Build build)
    {
        _infoCard.HideCard(build);
    }
}
