using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask; // Hangi objeler projectile ile çarpışabilir.
    public LayerMask obstacleCollisionMask;
    float speed = 10;
    float damage = 1;

    public void ChangeSpeed(float newSpeed) { // Bend'de hız değişikliği yaparsam giden Rock'un(Taş'ın) hızını değiştirmeme yarayan fonksiyon.
        speed = newSpeed;
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance) {
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,moveDistance,collisionMask,QueryTriggerInteraction.Collide)){
            OnHitObject(hit);
        }
        else if (Physics.Raycast(ray, out hit, moveDistance, obstacleCollisionMask, QueryTriggerInteraction.Collide))
        {
            GameObject.Destroy(gameObject);
        }

    }

    void OnHitObject(RaycastHit hit) {
        //print(hit.collider.gameObject.name); //Attığımız mermiler enemyle çarpışınca consola çıktı ver.
        IDamagable damagableObject = hit.collider.GetComponent<IDamagable>();
        //print(damagableObject);
        if (damagableObject != null){

            damagableObject.TakeHit(damage , hit);
        }
        GameObject.Destroy(gameObject);    // Mermiyi yok ediyor.
    }




    /*
    void OnTriggerEnter(Collider triggerCollider)
    {
        switch (triggerCollider.tag)
        {
            case "Zombie":
                Destroy(triggerCollider.gameObject);
                Destroy(gameObject); break;

            case "Wall":
                Destroy(gameObject); break;
        }
    }*/
}
