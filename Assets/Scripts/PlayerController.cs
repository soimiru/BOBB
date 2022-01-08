using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rigBody;
    MeshRenderer meshRenderer;
    float dirX;
    float speed = 25f;

    [Header("Game")]
    private bool coin = false;

    private void Awake()
    {
        rigBody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        //meshRenderer.material = meshRenderer.materials[PlayerPrefs.GetInt("PlayerMaterialIndex")];
        meshRenderer.material.CopyPropertiesFromMaterial(meshRenderer.materials[PlayerPrefs.GetInt("PlayerMaterialIndex")]);
        coin = false;
    }

    void Update()
    {
        dirX = Input.acceleration.x * speed * 0.5f;
        transform.Rotate(new Vector3(10, 10, 0) * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y, transform.position.z);
    }
    void FixedUpdate()
    {
        rigBody.velocity = new Vector3(dirX, -5f, 0f);
    }

    public void CoinCollected() {
        coin = true;
    }

    public void StopMovement() {
        speed = 0f;
    }

    public void ContinueMovement(){
        speed = 25f;
    }


    public int CheckCoin() {
        if (coin)   //Si ha cogido la moneda, devuelve 1
        {
            return 1;
        }
        else {  //Si no, devuelve 0
            return 0;
        }
    }
}
