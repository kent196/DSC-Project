using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static event Action OnEnemyDamaged;
    public static event Action OnEnemyDeath;
    private Animator anim;
    public HealthBar healthBar;
    public int health, maxHealth;
    public GameObject dmgPopUp;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int dmg)
    {
        if (dmgPopUp)
        {
            var go = Instantiate(dmgPopUp, transform.position, Quaternion.identity, transform);
            go.GetComponent<TextMesh>().text = dmg.ToString();
        }
        Debug.Log("Enemy current health " + health);
        anim.Play("Enemy_Hit");
        health -= dmg;
        healthBar.SetHealth(health);
        OnEnemyDamaged?.Invoke();
        if (health < 1)
        {
            OnEnemyDeath?.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            OnEnemyDeath?.Invoke();

        }
    }
}
