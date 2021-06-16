using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : LivingEntity
{
    NavMeshAgent pathfinder;
    public Transform Player;
    public override void Start()
    {
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag ("Adam").transform;
        StartCoroutine(UpdatePath());
        
    }

    void Update()
    {
        //transform.LookAt(new Vector3(Player.position.x, 1.5f , Player.position.z)); // Burayı aktif edince Enemy Adam'a devamlı bir bakış sergiliyor fakat yaklaşınca secdeye iniyor.Sebebiyle çok uğraşmadım.
    }

    IEnumerator UpdatePath() {
        float refreshRate = .20f;

        while (Player != null)
        {
            Vector3 playerPosition = new Vector3(Player.position.x,0,Player.position.z);
            if (!dead)
            {
                pathfinder.SetDestination(Player.position);
            }
            yield return new WaitForSeconds(refreshRate);
        }

    }
}
