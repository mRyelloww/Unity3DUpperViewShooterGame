using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AdamControllerScript : MonoBehaviour
{

    Rigidbody myRigidBody;
    Animator animator;
    Vector3 velocity;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }
    public void FixedUpdate() {
        myRigidBody.MovePosition(myRigidBody.position + velocity * Time.fixedDeltaTime);



    }
    public void Move(Vector3 _velocity) {
        velocity = _velocity;

    }
    public void LookAt(Vector3 lookPoint)
    {
        transform.LookAt(new Vector3(lookPoint.x, transform.position.y, lookPoint.z));
    }
    public void Animate(Vector3 direction) {
        float animationSpeedPercent = 100 * direction.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent);
    }

    void OnTriggerEnter(Collider triggerCollider) // Yerdeki kutuyu pick-up meselesi.
    {
        if (triggerCollider.tag == "Box")
        {
            Destroy(triggerCollider.gameObject);
        }
    }

}
