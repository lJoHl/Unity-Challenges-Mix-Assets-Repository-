using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AssingTexts : MenuManager  //Remember to write comments
{
    [SerializeField] private TextMeshProUGUI questionField;
    [SerializeField] private TextMeshProUGUI messageField;
    [SerializeField] private TextMeshProUGUI option1Field;
    [SerializeField] private TextMeshProUGUI option2Field;

    [SerializeField] private string question;
    [SerializeField] private string message;
    [SerializeField] private string option1;
    [SerializeField] private string option2;


    private void Start()
    {
        questionField.text = $"{question}?";
        messageField.text = $"[{message}]";
        option1Field.text = option1;
        option2Field.text = option2;
    }


    public override void EscAction()
    {
        transform.parent.GetComponent<MenuManager>().SetEscLock(false);

        ChangeActiveState(gameObject);
    }
}
