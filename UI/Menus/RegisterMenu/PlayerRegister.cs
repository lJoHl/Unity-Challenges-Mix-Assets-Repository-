using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class PlayerRegister : MenuManager //Remember to write comments
{
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private TextMeshProUGUI requirements;

    private static string dataPath;


    [System.Serializable] class NameData
    {
        public string name;
    }


    // Are Save and Load Name Methods Necessary?, Could it be Remplaced by a static "name" variable?
    public void SaveName()
    {
        dataPath = Application.persistentDataPath + "/savename.json";

        NameData nameData = new();
        nameData.name = inputName.text;

        string json = JsonUtility.ToJson(nameData);
        File.WriteAllText(dataPath, json);
    }
    public void LoadName()
    {
        if (File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
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