using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) {
            other.GetComponent<PlayerController>().CoinCollected(true);
            gameObject.SetActive(false);
        }
    }
}
