using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAggro : EnemyStateBase
{
    public override void OnActivate()
    {
        Debug.Log("Grunt is Aggressive");
    }
    
    public override void OnDeactivate()
    {
        Debug.Log("Grunt is no longer Aggressive");
    }
}
