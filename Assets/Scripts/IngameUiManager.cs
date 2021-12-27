using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameUiManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject endPanel;
    public GameObject pausePanel;
    public GameObject gamePanel;
    [Header("References")]
    private IngameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("_GameManager").GetComponent<IngameManager>();
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
        endPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowEndPanel() {
        gamePanel.SetActive(false);
        pausePanel.SetActive(false);
        endPanel.SetActive(true);
    }

    public void NextLevel() {
        string nextLevel = "Level" + (gm.levelID+1);
        SceneManager.LoadScene(nextLevel);
    }
    public void BackToMenu(){
        SceneManager.LoadScene("MainMenuScene");
    }

    public void RestartLevel() {
        string thisLevel = "Level" + gm.levelID;
        SceneManager.LoadScene(thisLevel);
    }

    public void PauseGame() {
        Time.timeScale = 0;
        gamePanel.SetActive(false);
        pausePanel.SetActive(true);
        endPanel.SetActive(false);
    }

    public void DespauseGame() {
        Time.timeScale = 1;
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
        endPanel.SetActive(false);
    }
}
