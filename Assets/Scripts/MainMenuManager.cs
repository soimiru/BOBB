using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public CamManager cuboprueba;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
