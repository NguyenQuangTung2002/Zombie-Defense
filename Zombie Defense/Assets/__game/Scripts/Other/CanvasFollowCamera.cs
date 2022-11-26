using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollowCamera : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    

    // Update is called once per frame
    void Update()
    {
        rectTransform.rotation = Quaternion.LookRotation(Character.Instance.transform.position +
            Vector3.up-CameraFollowChar.Instance.transform.position);
    }
}
