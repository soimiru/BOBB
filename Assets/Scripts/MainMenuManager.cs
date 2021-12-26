using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("PANELES")]
    public GameObject mainMenuPanel;
    public GameObject levelSelectorPanel;
    public GameObject customizePanel;

    public CamManager cuboprueba;
    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(true);
        levelSelectorPanel.SetActive(false);
        customizePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        levelSelectorPanel.SetActive(false);
        customizePanel.SetActive(false);
    }

    public void GoToLevelSelector() {
        mainMenuPanel.SetActive(false);
        levelSelectorPanel.SetActive(true);
        customizePanel.SetActive(false);
    }

    public void GoToCustomize()
    {
        mainMenuPanel.SetActive(false);
        levelSelectorPanel.SetActive(false);
        customizePanel.SetActive(true);
    }

    public void Cam() {
        cuboprueba.OpenCamera();
    }

    public void Cam1()
    {
        cuboprueba.TakeSnapshot();
    }


    public void GoToLevel(string level) {
        SceneManager.LoadScene(level);
    }

    public void Customize(int index) {
        Debug.Log("Color cambiado a: " + index);
        PlayerPrefs.SetInt("PlayerMaterialIndex", index);
    }
}
