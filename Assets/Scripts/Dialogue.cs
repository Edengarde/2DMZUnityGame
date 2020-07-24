using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue 
{
    public bool isDone;

    public bool isImportantDialogue;

    public string[] names;
    
    public Sprite[] portraits;

    public bool[] isImgRight;

    [TextArea(3,10)]
    public string[] sentences;
}
