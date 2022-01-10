using UnityEngine;

public class EndManager : MonoBehaviour
{
    private IngameManager gm;
    private PlayerController player;
    private void Awake()
    {
        gm = GameObject.Find("_GameManager").GetComponent<IngameManager>();
        player = GameObject.Find("PLAYER").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            Save();
            gm.uiManager.ShowEndPanel();
            if (player.CheckCoin() == 0) {
                gm.uiManager.HideCoinUI();
            }
        }
    }

    public void Save() {
        //Guardar nivel superado
        string getLevel = "Level" + gm.levelID + "Completed";
        PlayerPrefs.SetInt(getLevel, 1);
        //Guardar coleccionable
        string levelCoin = "Level" + gm.levelID + "Coin";
        PlayerPrefs.SetInt(levelCoin, player.CheckCoin());  //1SI, 0NO 
    }
}
