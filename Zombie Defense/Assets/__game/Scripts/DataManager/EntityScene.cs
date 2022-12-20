using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityScene: MonoBehaviour
{
    public int cost;
    public bool lockState;
    public int level;
}
[Serializable]
public class EntityFormData
{
    public bool activeSelf;
    public bool lockState;
    public int level;
    public int cost;
}

public class ListEntity
{
    public List<EntityFormData> Entities;
}


