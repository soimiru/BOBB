using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public CamManager cuboprueba;
    public GameObject gridLevels;
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetTrigger("HIN");
    }

    // Start is called before the first frame update
    void Start()
    {
        CheckPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Cam() {
        cuboprueba.OpenCamera();
    }

    public void Cam1()
    {
        cuboprueba.TakeSnapshot();
    }


    public void GoToLevel(string level) {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void Customize(int index) {
        PlayerPrefs.SetInt("PlayerMaterialIndex", index);
    }

    public void CheckPlayerPrefs() {
        string getLevel = "";
        string levelCoin = "";
        int lastLevelCompleted = 0;

        for (int i = 1; i < 11; i++)
        {
            GameObject level = GameObject.Find("LevelUIElement" + i);   //Cogemos cada elemento del grid
            Image[] listChildren = level.GetComponentsInChildren<Image>(true);  //Cogemos la lista de sus hijos, para acceder al candado, tick y moneda
            
            //Nombres en playerprefs
            getLevel = "Level" + i + "Completed";   
            levelCoin = "Level" + i + "Coin";

            //LÓGICA NIVELES
            int lvl = PlayerPrefs.GetInt(getLevel, 0);
            if (lvl == 1)
            {
                //alfa del tick a 1
                listChildren[3].color = new Color(0.1411765f, 0.6745098f, 0.9019608f, 1f);
                lastLevelCompleted = i; //Marca el último nivel completado
                listChildren[6].gameObject.SetActive(false);
            }
            else {
                if (lastLevelCompleted == i - 1) {
                    //Quitar el candado si el nivel anterior es el último completado
                    listChildren[6].gameObject.SetActive(false);
                }
                //alfa del tick a 0
                listChildren[3].color = new Color(0.1411765f, 0.6745098f, 0.9019608f, 0f);
            }

            //LÓGICA MONEDAS
            int cn = PlayerPrefs.GetInt(levelCoin, 0);
            if (cn == 1)
            {
                //Alfa de la moneda a 1
                listChildren[5].color = new Color(0.945098f, 0.6755089f, 0.2196078f, 1f);
            }
            else {
                //Alfa de la moneda a 0
                listChildren[5].color = new Color(0.945098f, 0.6755089f, 0.2196078f, 0f);
            }
        }

    }
}
