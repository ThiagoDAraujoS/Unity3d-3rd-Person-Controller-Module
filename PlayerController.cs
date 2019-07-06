using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private UnityEventVector2 OnWalkAxis;

    public float Horizontal { 
        get{ 
            return Input.GetAxis("Horizontal");
        }
    }
    public float Vertical{
        get{
            return Input.GetAxis("Vertical");
        }
    }
    public Vector2 LeftAxis{
        get {   return new Vector2(Horizontal, Vertical);
        }
    }

    void Update(){
        if(LeftAxis != Vector2.zero)
            OnWalkAxis?.Invoke(LeftAxis);
    }
}
[System.Serializable]
public class UnityEventVector2 : UnityEvent<Vector2>{}
//public class UnityEventFloat : UnityEvent<float>{}