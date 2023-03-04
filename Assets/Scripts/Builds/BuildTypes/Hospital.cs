using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : Build
{
    private void Start()
    {
        Initialize();
        TypeName = GetType().Name;
    }
}
