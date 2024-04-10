using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

    [CreateAssetMenu(fileName ="Ammo", menuName = "Dev/Ammunition")]
public class BCAmmo : ScriptableObject
{

    public int dmg { get { return damage; } } //allows enemies to get the damage amount
    public int rnd { get { return rounds; } }
    public float sprd { get { return spread; } }
    public float rcol { get { return recoil; } }

    [SerializeField] protected int damage;
    [SerializeField] protected int rounds; //number of projectiles
    [SerializeField] protected float spread; //how much the rounds deviate
    [SerializeField] protected float recoil; //how long till they can fire again
    
}

