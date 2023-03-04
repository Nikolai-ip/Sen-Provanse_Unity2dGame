using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabric : Build
{
    private void Start()
    {
        Initialize();
        TypeName = GetType().Name;
    }
}
