using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameKeeper : MonoBehaviour
{

    public static string username;
    private static Text nameText;

    private void Start()
    {
        nameText = GetComponent<Text>();
    }
    public static string KeepDaText()
    {
        return username = nameText.text;
    }
}