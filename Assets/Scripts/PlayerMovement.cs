using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rigBody;
    MeshRenderer meshRenderer;
    float dirX;
    float speed = 25f;

    private void Awake()
    {
        rigBody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        //meshRenderer.material = meshRenderer.materials[PlayerPrefs.GetInt("PlayerMaterialIndex")];
        meshRenderer.material.CopyPropertiesFromMaterial(meshRenderer.materials[PlayerPrefs.GetInt("PlayerMaterialIndex")]);
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
