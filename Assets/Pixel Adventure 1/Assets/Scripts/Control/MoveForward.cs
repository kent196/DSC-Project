using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    public bool facingRight = true;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Shoot to direction
        Transform playerTransform = FindObjectOfType<PlayerController>().transform;
        rb.velocity = transform.right * speed * playerTransform.localScale.x * Time.fixedDeltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        RotateProjectile();
    }

    void RotateProjectile()
    {
        Transform playerTransform = FindObjectOfType<PlayerController>().transform;

        if (playerTransform.localScale.x < 0 && facingRight)
        {
            Flip();
        }
        else if (playerTransform.localScale.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);

        }
    }

}
