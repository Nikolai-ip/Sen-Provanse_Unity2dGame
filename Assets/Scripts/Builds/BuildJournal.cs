using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildJournal : MonoBehaviour
{
    private static BuildJournal _instance;
    [SerializeField] private List<Build> _builds = new List<Build>();
    public List<Build> Builds { get { return _builds; } }
    public event Action<Build> BuildListChanged;
    private void Start()
    {
        if (_instance==null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Add(Build build)
    {
        _builds.Add(build);
        BuildListChanged?.Invoke(build);
    }
}
