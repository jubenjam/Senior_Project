using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    float xStart = 0f;
    float yStart = 0f;
    public Rigidbody2D Object;
    // Start is called before the first frame update
    void Start()
    {
        xStart = transform.position.x;
        yStart = transform.position.y;
    }

    public void Reset()
    {
        transform.position = new Vector3(xStart, yStart, 0);
        transform.rotation = Quaternion.identity;
        Object.velocity = new Vector2(0,0);
        Object.angularVelocity = 0;
    }

}
