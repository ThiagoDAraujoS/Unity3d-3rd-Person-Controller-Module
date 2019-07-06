using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof (BaseMovement))]
public class BaseMovementEditor : Editor
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    void OnSceneGUI(){
        BaseMovement o = target as BaseMovement;

        if(o == null || o.rb == null)
            return;
        
        Handles.color = Color.blue;
        Vector3 pos = Vector3.up * o.feetHeight + o.rb.position;
        //Vector3 pos = Vector3.zero + o.transform.position;
        o.feetHeight = Handles.ScaleValueHandle(o.feetHeight, pos, Quaternion.Euler(90f, 0f, 0f),3.5f,Handles.RectangleHandleCap,0.1f);
    }
}
