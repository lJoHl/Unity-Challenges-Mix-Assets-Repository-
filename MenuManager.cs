using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameObject canvas;



    protected void Awake()
    {
        canvas = GameObject.Find("Canvas");
    }


    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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


    public virtual void EscAction()
    {
       
    }
}
