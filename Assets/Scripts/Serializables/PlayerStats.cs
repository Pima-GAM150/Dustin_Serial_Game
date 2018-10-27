﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
public class PlayerStats
{
    public PlayerInventory inventory;
    public float Health;
    public float MaxHealth;
    public float Damage;
    public Weapon Weapon;
}
