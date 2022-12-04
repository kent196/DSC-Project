using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;
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
        anim.Play("Player_Hit");
        health -= dmg;
        healthBar.SetHealth(health);
        OnPlayerDamaged?.Invoke();
        if (health < 1)
        {
            Debug.Log("You're DEAD");
            OnPlayerDeath?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            OnPlayerDeath?.Invoke();

        }
    }

}
