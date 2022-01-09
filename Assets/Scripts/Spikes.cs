using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = GameObject.Find("COIN");
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
        coin.SetActive(true);
        other.GetComponent<PlayerController>().CoinCollected(false);
        yield return new WaitForSeconds(0.2f);
        other.transform.position = new Vector3(0f, 13f, 0f);
        other.GetComponent<PlayerController>().ContinueMovement();
        
    }
}
