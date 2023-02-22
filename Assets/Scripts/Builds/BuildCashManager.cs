using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCashManager : MonoBehaviour
{
    private Build _build;
    private void Start()
    {
        _build = GetComponent<Build>();
    }
}
