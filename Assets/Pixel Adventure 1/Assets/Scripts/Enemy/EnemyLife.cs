using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;


    public EnemyHealth enemyHealth;



    private void OnEnable()
    {
        EnemyHealth.OnEnemyDeath += Die;
    }


    private void OnDisable()
    {
        EnemyHealth.OnEnemyDeath -= Die;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Die()
    {
        Destroy(gameObject, 0.5f);
        anim.SetTrigger("enemy_death");
    }
}
