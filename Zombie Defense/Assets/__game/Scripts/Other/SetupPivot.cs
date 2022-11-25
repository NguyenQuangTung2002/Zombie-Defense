using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SetupPivot : MonoBehaviour
{
    public Vector3 medium;
    private void Awake()
    {
        
        var childs = GetComponentsInChildren<Transform>();
        Debug.Log(childs.Length);
        Vector3[] lastPositions = new Vector3[childs.Length];

        for (int i = 0; i < childs.Length; i++)
        {
            medium +=  childs[i].position;
            lastPositions[i] = childs[i].position;
        }

        medium /= childs.Length;
        transform.position = medium;
        
        Debug.Log(transform.position);
        
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].position = lastPositions[i];
        }

        DOTween.Init();
    }

    public void Setup()
    {
        var childs = GetComponentsInChildren<Transform>();
        Debug.Log(childs.Length);
        Vector3[] lastPositions = new Vector3[childs.Length];

        for (int i = 0; i < childs.Length; i++)
        {
            medium +=  childs[i].position;
            lastPositions[i] = childs[i].position;
        }

        medium /= childs.Length;
        transform.position = medium;
        
        Debug.Log(transform.position);
        
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].position = lastPositions[i];
        }
    }
    
    // Update is called once per frame
    void Start()
    {
       
    }
}
