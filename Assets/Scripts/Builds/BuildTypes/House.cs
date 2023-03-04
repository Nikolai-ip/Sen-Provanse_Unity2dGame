using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Build  
{
    private void Start()
    {
        Initialize();
        TypeName = GetType().Name;
    }
}
