using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text appleText;
    [SerializeField] private AudioSource colectSFX;

    private int apples = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            colectSFX.Play();
            Destroy(collision.gameObject);
            apples++;
            appleText.text = "Apples: " + apples;
        }
    }
}
