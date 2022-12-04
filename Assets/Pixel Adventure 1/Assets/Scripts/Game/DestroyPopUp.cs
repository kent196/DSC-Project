using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPopUp : MonoBehaviour
{
    public float destroyTimer = 1f;
    public Vector3 offset = new Vector3(0, 2, 0);
    // Start is called before the first frame update
    void Start()
    {
        transform.position += offset;
        Destroy(gameObject, destroyTimer);
    }

    // private void Update()
    // {
    //     if (Input.GetAxis("Horizontal") != 0)
    //     {
    //         Flip(Input.GetAxis("Horizontal"));
    //     }
    // }
    // private void Flip(float check)
    // {

    //     Vector3 currentScale = gameObject.transform.localScale;
    //     if (check > 0)
    //     {
    //         currentScale.x = 1;
    //     }
    //     else if (check < 0)
    //     {
    //         currentScale.x = -1;

    //     }
    //     gameObject.transform.localScale = currentScale;
    // }


}
