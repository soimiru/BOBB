using System.Collections;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private GameObject coin;

    void Start()
    {
        coin = GameObject.Find("COIN");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) {
            Handheld.Vibrate();
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
