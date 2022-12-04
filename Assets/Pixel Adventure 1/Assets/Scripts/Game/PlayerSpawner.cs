using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawn();
    }

    private void PlayerSpawn()
    {
        Instantiate(playerPrefab);
    }
}
