using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bend : MonoBehaviour // Bükülen manasında mesela şu an earth büküyorum.Atacağım Rock'larda bu earth içerisinden çıkacak ama ben renderını hideladığım için gözükmüyor scenede.
{
    public Transform bendOutPosition;
    public Projectile projectile;
    public float msBetweenShots = 100;
    public float bendOutVelocity = 35;

    float nextShotTime;


    public void Shoot() {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Projectile newProjectile = Instantiate(projectile, bendOutPosition.position, bendOutPosition.rotation) as Projectile;
            newProjectile.ChangeSpeed(bendOutVelocity);
        }
        
    
    }

}
