using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    private IngameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("_GameManager").GetComponent<IngameManager>();
    }
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
        if (other.gameObject.tag.Equals("Player")) {
            gm.uiManager.ShowEndPanel();
        }
    }
}
