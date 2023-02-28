
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Builder : MonoBehaviour
{
    private Build _build;
    private BuildCashController _cashBuildController;
    private PlayerCashManager _cashManager;
    [SerializeField] private List<Sprite> _sprites;
    private SpriteRenderer _sp;
    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        _cashManager = FindObjectOfType<PlayerCashManager>();   
        _build = GetComponent<Build>();
        _cashBuildController = GetComponent<BuildCashController>();
        _cashBuildController.enabled = false;
    }
    public void StartBuilding()
    {
        _cashManager.AddCash(-_build.InitialCost);
        StartCoroutine(Building());
    }
    private IEnumerator Building()
    {
        var delay = new WaitForFixedUpdate();
        float time = 0;
        int spriteIndex = 0;
        while (true)
        {
            time += Time.deltaTime;
            if (time > _build.BuildingTime) 
            { 
                FinishBuild(); 
                yield break; 
            }
            spriteIndex = Mathf.CeilToInt(time/(_build.BuildingTime/_sprites.Count))-1;
            _sp.sprite = _sprites[spriteIndex];
            yield return delay;
        }
        
    }
    private void FinishBuild()
    {
        _cashBuildController.enabled = true;
    }
}
