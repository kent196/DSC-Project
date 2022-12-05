using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private enum EnemyState { idle, hit }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyState();
    }

    private void UpdateEnemyState()
    {
        EnemyState state = EnemyState.idle;
        anim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

    }
}
