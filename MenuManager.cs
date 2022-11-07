using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
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

    public void CloseMenu()
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
        if (int.TryParse(sceneName, out int sceneNo))   //gameSelectorMenu Branch
            SceneManager.LoadScene(sceneNo);            //gameSelectorMenu Branch
        else                                            //gameSelectorMenu Branch
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
