using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue //Script for creating dialogue system
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;

    [TextArea(3,10)]
    public string choice;

    public string option1;
    public string option2;

    public GameObject nextScene1;
    public GameObject nextScene2;
}
