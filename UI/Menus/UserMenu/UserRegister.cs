using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class UserRegister : MenuManager
{
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private TextMeshProUGUI requirements;


    [System.Serializable] class NameData
    {
        public string name;
    }


    public void SaveName()
    {
        NameData nameData = new NameData();

        nameData.name = inputName.text;

        string json = JsonUtility.ToJson(nameData);

        File.WriteAllText(Application.persistentDataPath + "/savename.json", json);
    }
    
    public void LoadName()
    {
        if (File.Exists(Application.persistentDataPath + "/savename.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savename.json");
            NameData nameData = JsonUtility.FromJson<NameData>(json);

            inputName.text = nameData.name;
        }
    }




    public void ConfirmName(string menuName)
    {
        requirements.text = CheckRequirements();

        if (requirements.text == null)
            ChangeScene(menuName);
    }


    private string CheckRequirements()
    {
        return inputName.text.Length < 1 ? "Name must has at least one digit" : null;
    }


    public override void EscAction()
    {
        CloseMenu();
    }
}