using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUiManager : MonoBehaviour
{
    public void BackHome() {
        SceneManager.LoadSceneAsync("MainMenuScene");
    }
}
