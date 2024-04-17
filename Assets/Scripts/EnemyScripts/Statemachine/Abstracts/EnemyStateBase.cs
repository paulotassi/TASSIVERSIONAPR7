using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStateBase : MonoBehaviour
{
    //An abstract class that is the bases for the states for enemies, please don't mess with this
    private void Awake()
    {

    }

    public abstract void OnActivate();
    public abstract void OnDeactivate();
}