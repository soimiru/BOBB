using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rigBody;
    MaterialsList matList;
    Material material;
    float dirX;
    float speed = 25f;

    private void Awake()
    {
        rigBody = GetComponent<Rigidbody>();
        material = GetComponent<Material>();
        matList = new MaterialsList();
    }
    void Start()
    {
        
    }

    void Update()
    {
        dirX = Input.acceleration.x * speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y, transform.position.z);
    }
    void FixedUpdate()
    {
        rigBody.velocity = new Vector3(dirX, -5f, 0f);
    }
}
