using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedZoneInhabitant : OccupiedZone
{
    private void Awake()
    {
        _zoneCollider = GetComponent<BoxCollider2D>();
    }
}
