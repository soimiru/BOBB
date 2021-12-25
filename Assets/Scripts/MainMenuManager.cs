using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private GameObject levelSelector, mainMenu;

    private void Awake()
    {
        mainMenu = GameObject.Find("MainMenuPanel");
        levelSelector = GameObject.Find("LevelSelectorPanel");
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        levelSelector.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoLevelSelector() {
        mainMenu.SetActive(false);
        levelSelector.SetActive(true);
    }

    public void GoToLevel(string level) {
        SceneManager.LoadScene(level);
    }

    public void Customize(int index) {
        PlayerPrefs.SetInt("PlayerMaterialIndex", index);
    }
}
