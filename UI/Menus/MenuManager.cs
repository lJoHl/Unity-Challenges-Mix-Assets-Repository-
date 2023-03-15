using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour    //Remember to write comments
{
    private GameObject canvas;

    private bool escLock;



    protected void Awake()
    {
        canvas = GameObject.Find("Canvas");
    }


    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & escLock == false)
            EscAction();
    }


    public void OpenMenu(GameObject menu)
    {
        Instantiate(menu, canvas.transform);
    }

    public void CloseMenu() //Remove this method?  CloseMenu(gameobject) can be used instead
    {
        Destroy(gameObject);
    }

    protected void CloseMenu(GameObject menu)
    {
        Destroy(menu);
    }


    public void ChangeActiveState(GameObject menu)
    {
        menu.SetActive(!menu.activeInHierarchy ? true : false);
    }


    public void ChangeScene(string sceneName)
    {
        if (int.TryParse(sceneName, out int sceneNo))   
            SceneManager.LoadScene(sceneNo);            
        else                                            
            SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void SetEscLock(bool value)
    {
        escLock = value;
    }

    public virtual void EscAction()
    {
       
    }
}
