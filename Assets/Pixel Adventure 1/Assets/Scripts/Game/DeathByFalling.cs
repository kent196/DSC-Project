using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByFalling : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public static event Action OnEnemyDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(other.gameObject.name);
            OnPlayerDeath?.Invoke();
            OnEnemyDeath?.Invoke();

        }
    }
}
