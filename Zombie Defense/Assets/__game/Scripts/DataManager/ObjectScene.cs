using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScene : MonoBehaviour
{

}
[Serializable]
public class ObjectFormData
{
    public bool activeSelf;

    public void Load(ObjectScene objectScene)
    {
        objectScene.gameObject.SetActive(activeSelf);
    }

    public void Save(ObjectScene objectScene)
    {
        activeSelf = objectScene.gameObject.activeSelf;
    }
    
}

public class ListObject
{
    public List<ObjectFormData> objects;
}

