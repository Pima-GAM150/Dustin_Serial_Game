﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
public class PlayerStats
{
    public PlayerInventory inventory;
    public int Health;
    public int Damage;
    public GameObject Weapon;
}