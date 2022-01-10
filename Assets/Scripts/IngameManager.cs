using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public int levelID;
    public IngameUiManager uiManager;
    public PlayerController player;

    public void BeginGame() {
        GameObject.Find("START").GetComponentInChildren<Animator>().SetTrigger("OpenDoor");
    }
    
}
