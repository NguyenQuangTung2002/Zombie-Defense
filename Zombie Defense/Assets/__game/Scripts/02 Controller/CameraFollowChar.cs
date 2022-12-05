using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowChar : CameraController
{
    private Vector3 cameraOffset;
    public static CameraFollowChar Instance;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (Character.Instance != null)
        {
            cameraOffset = transform.position - Character.Instance.transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Character.Instance != null)
        {
            transform.position = Character.Instance.transform.position + cameraOffset;
        }
    }
}
