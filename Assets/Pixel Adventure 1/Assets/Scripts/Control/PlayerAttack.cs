using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject weaponPrefab;
    private float fireRate = 1.5f;
    private float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ThrowShuriken();
    }
    private void ThrowShuriken()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(weaponPrefab, transform.position, weaponPrefab.transform.rotation);

        }
        else if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(weaponPrefab, transform.position, weaponPrefab.transform.rotation);
        }
    }
}
