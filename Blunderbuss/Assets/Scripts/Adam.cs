using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof (AdamControllerScript))]
[RequireComponent(typeof(BendController))]

public class Adam : LivingEntity
{
    Camera viewCamera;
    float moveSpeed = 7;
    AdamControllerScript controller;
    BendController bendController;

    public override void Start()
    {
        base.Start(); // Bunu yapmamızın sebebi Living Entity deki startın okunmasını sağlamak.Start metodunu overridelamadan ve bu line'ı yazmadan yaparsak Living Entitiy'deki Start metodu çağırılmaz.
        controller = GetComponent<AdamControllerScript> ();
        bendController = GetComponent<BendController>();
        viewCamera = Camera.main;
    }

    void Update()
    {
        // Movement girdi.
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0 ,Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 moveVelocity = direction * moveSpeed;
        controller.Move(moveVelocity);

        // Look girdi.
        Ray ray;
        ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
        if (ground.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }
        controller.Animate(direction);

        // Attack girdi.
        if (Input.GetMouseButton(0)){
            bendController.Shoot();
        }
        
    }
}
