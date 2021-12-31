using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) {
            StartCoroutine(Waiter(other));
        }
    }

    IEnumerator Waiter(Collider other) {
        other.GetComponent<PlayerController>().StopMovement();
        yield return new WaitForSeconds(1f);
        other.transform.position = new Vector3(0f, 14f, 0f);
        other.GetComponent<PlayerController>().ContinueMovement();
    }
}
