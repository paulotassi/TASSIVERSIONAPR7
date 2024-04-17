using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{
    //This script is for the most basic enemies, they look for the player. If they see the player, then they move towards the player and hits them with melee

    public enum GSEnum { Aggro, Passive }

    private EnemyStateBase state;
    private Dictionary<GSEnum, EnemyStateBase> StateDic = new Dictionary<GSEnum, EnemyStateBase>();

    public float hp {  get { return health; } }

    private void Awake()
    {
        StateDic.Add(GSEnum.Aggro, GetComponent<GAggro>());
        StateDic.Add(GSEnum.Passive, GetComponent<GPassive>());
    }

    private void Start()
    {
        ChangeState(GSEnum.Passive);
        health = 35;
    }

    public void ChangeState(GSEnum newstate)
    {
        if (state != null)
        {
            state.OnDeactivate();
            state.enabled = false;
        }
        state = StateDic[newstate];
        state.enabled = true;
        state.OnActivate();
    }
}
