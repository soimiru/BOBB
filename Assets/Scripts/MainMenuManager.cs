using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public CamManager cuboprueba;
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetTrigger("HIN");
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
}
