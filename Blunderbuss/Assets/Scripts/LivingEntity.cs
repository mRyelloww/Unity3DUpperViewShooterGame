using System.Collections;
using UnityEngine;

public class LivingEntity : MonoBehaviour , IDamagable {


    public float startingHealth;
    protected float health; // protected çünkü Inspector'da gözükmesine veya enemy ve Adam dışında birinin erişimine gerek yok.
    protected bool dead;

    public HealthBar healthBar;

    public virtual void Start(){
        health = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        print(health);
    } 

    public void TakeHit(float damage , RaycastHit hit) {

        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0 && !dead){ // Ölmemişsek ve can 0 veya altında değilse ölmeliyiz.
            Die();
        }
        print(health);
    }

    public void Die() { // Ölme metodu
        dead = true;
        GameObject.Destroy(gameObject);
    
    }

}
