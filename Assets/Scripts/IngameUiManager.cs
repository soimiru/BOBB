using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameUiManager : MonoBehaviour
{
    [Header("References")]
    private IngameManager gm;
    private Animator anim;
    [Header("Countdown")]
    public int coundownTime;
    public Text countdownText;
    

    private void Awake()
    {
        gm = GameObject.Find("_GameManager").GetComponent<IngameManager>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountdownToStart()
    {
        while (coundownTime > 0)
        {
            countdownText.text = coundownTime.ToString();
            yield return new WaitForSeconds(1f);    //Espera unos segundos
            coundownTime--;
        }
        countdownText.text = "GO!";

        gm.BeginGame();
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
    }

    public void ShowEndPanel() {
        Time.timeScale = 0;
        anim.SetTrigger("EndIN");
    }

    public void NextLevel() {
        if (gm.levelID < 10)
        {
            string nextLevel = "Level" + (gm.levelID + 1);
            SceneManager.LoadScene(nextLevel);
        }
        else {
            string nextLevel = "TheEnd";
            SceneManager.LoadScene(nextLevel);
        }
        
    }
    public void BackToMenu(){
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("MainMenuScene");
    }

    public void RestartLevel() {
        Time.timeScale = 1;
        string thisLevel = "Level" + gm.levelID;
        SceneManager.LoadScene(thisLevel);
    }

    public void PauseGame() {
        Time.timeScale = 0;
    }

    public void DespauseGame() {
        Time.timeScale = 1;
    }

    public void HideCoinUI() { 
        Image coinImage = GameObject.Find("CoinImage").GetComponent<Image>();
        coinImage.gameObject.SetActive(false);
    }
}
