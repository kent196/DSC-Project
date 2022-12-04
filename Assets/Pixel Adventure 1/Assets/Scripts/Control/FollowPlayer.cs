using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 cameraOffset;
    [Range(1, 10)] public float smoothFactor;

    [SerializeField] private Transform player;
    public Vector3 minValue, maxValue;

    private void Start()
    {

    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 playerPos = player.position + cameraOffset;
        Vector3 bounds = new Vector3(Mathf.Clamp(playerPos.x, minValue.x, maxValue.x), Mathf.Clamp(playerPos.y, minValue.y, maxValue.y), Mathf.Clamp(playerPos.z, minValue.z, maxValue.z));

        Vector3 smoothPos = Vector3.Lerp(transform.position, bounds, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPos;

    }

}
