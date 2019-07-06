using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [SerializeField][Range(0f,10f)]
    protected float moveSpeed, rotateSpeed, jumpForce;

    [SerializeField][Range(0f,90f)]
    protected float climbAngleLimit;

    [SerializeField]
    protected AnimationCurve rotationAccelerationCurve, movementAccelerationCurve;

    [HideInInspector]

    public Rigidbody rb;
    private bool isGrounded = false;

    //[HideInInspector]
    public float feetHeight= -0.5f;
    public bool IsGrouded {
        get { return isGrounded; }
    }

    public virtual void Jump(){
        if(isGrounded){
            Vector3 newVelocity = rb.velocity;
            newVelocity.y = jumpForce;
            rb.velocity = newVelocity;
        }
    }
    void Start(){
        climbAngleLimit= 1f-(climbAngleLimit/90f);
        StartCoroutine(UpdateIsGroundedFlag());
        rb = GetComponentInChildren<Rigidbody>();
    }
    public virtual void Walk(Vector2 direction){
        rb.AddTorque(transform.up * rotateSpeed * rotationAccelerationCurve.Evaluate(direction.x) * direction.y, ForceMode.VelocityChange);
        rb.AddForce(transform.forward * moveSpeed * movementAccelerationCurve.Evaluate(direction.y), ForceMode.Acceleration);
        Debug.Log("Im Adding Force");
    }

    private bool tempIsGrounded = false;
    private IEnumerator UpdateIsGroundedFlag(){
        //run forever
        while(true){
            //wait until the last call on the physics pipeline

            //[DANGER]if i need to use the "isgounded
            yield return new WaitForFixedUpdate();

            //move the tempValue of isgrounded into the main isgrounded
            //at the start of the next frame the new is grounded will be taken as the real flag
            isGrounded = tempIsGrounded;

            //set the fake is grounded as false
            tempIsGrounded = false;

            //if the collision never happens the is grounded is set to false releasing the character so he can jump
            //since this happens on the very end of the step, the IS grounded always take 1 frame to trully happen
            //but since its the LAST thing there will be no weirdness when i call it on the fixed update
        }
    }

    private void OnCollisionStay(Collision collisionInfo) {
        //For each collision point
        for (int i = 0; i < collisionInfo.contactCount && !isGrounded; i++)
            //check if the point's normal is looking up and 
            tempIsGrounded = ((Vector3.Dot(collisionInfo.contacts[i].normal, Vector3.up)>= climbAngleLimit)  &&  collisionInfo.contacts[i].point.y <= transform.position.y + feetHeight);
    }
}
