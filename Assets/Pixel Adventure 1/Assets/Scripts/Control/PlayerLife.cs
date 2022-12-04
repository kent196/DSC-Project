using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSFX;

    public PlayerHealth playerHealth;
    public DeathByFalling deathByFalling;



    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += Die;
        DeathByFalling.OnPlayerDeath += Die;
    }


    private void OnDisable()
    {
        DeathByFalling.OnPlayerDeath -= Die;
        PlayerHealth.OnPlayerDeath -= Die;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Trap"))
    //    {
    //        Die();
    //    }
    //}

    private void Die()
    {
        deathSFX.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
