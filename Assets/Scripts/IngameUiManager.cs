using System.Collections;
using System.Collections.Generic;
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
        anim.SetTrigger("EndIN");
    }

    public void NextLevel() {
        string nextLevel = "Level" + (gm.levelID+1);
        SceneManager.LoadScene(nextLevel);
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
}
