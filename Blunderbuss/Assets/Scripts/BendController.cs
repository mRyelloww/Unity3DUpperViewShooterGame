using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendController : MonoBehaviour
{
    public Transform bendSpawner;
    public Bend startingBend;
    Bend currentBend;


    public void Start() {
        if (startingBend != null){
            EquipBend(startingBend);
        }
    
    
    }
    public void EquipBend(Bend bendToEquip) { // Elindeki elementi checkliyor.Yoksa spawnlıyor ama dediğim gibi ben onu görünmez yaptım.
        if (bendToEquip != null && currentBend != null){
            Destroy(currentBend.gameObject);
        }
        currentBend = Instantiate(bendToEquip,bendSpawner.position,bendSpawner.rotation) as Bend;
        currentBend.transform.parent = bendSpawner; // Bend spawner Adam hareket ettiğinde transformu değişen bir şey olduğu için yeni rock spawn positionunu tekrardan ayarlıyorum.
        
    }
    public void Shoot() {
        if (currentBend != null)
        {
            currentBend.Shoot();
        }
    
    }


}
