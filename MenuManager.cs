using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    protected void EscAction()
    {
       
    }
}
