using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions.Must;

public class DialogueManagerImportant : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image portraitLeft;
    public Image portraitRight;
    public Canvas canvasDialogue;

    private Queue<string> names;
    private Queue<string> sentences;
    private Queue<Sprite> portraits;
    private Queue<bool> isPortraitRight;

    public GameObject dialogueObject;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        portraits = new Queue<Sprite>();
        names = new Queue<string>();
        isPortraitRight = new Queue<bool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                DisplayNextSentence();
            }
        }
        else
        {

        }
    }

    public void StartDialogue(Dialogue dialogue, GameObject dialogueObj)
    {
        dialogueObject = dialogueObj;
        isActive = true;
        portraitLeft.gameObject.SetActive(false);
        portraitRight.gameObject.SetActive(false);
        canvasDialogue.gameObject.SetActive(true);
        names.Clear();
        sentences.Clear();
        portraits.Clear();
        isPortraitRight.Clear();

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (bool LeftRight in dialogue.isImgRight)
        {
            isPortraitRight.Enqueue(LeftRight);
        }

        foreach (Sprite portrait in dialogue.portraits)
        {
            portraits.Enqueue(portrait);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (isPortraitRight.Dequeue())
        {
            portraitLeft.color = new Color(0.5f, 0.5f, 0.5f);
            portraitRight.gameObject.SetActive(true);
            portraitRight.sprite = portraits.Dequeue();
            portraitRight.color = new Color(1f, 1f, 1f);
        }
        else
        {
            portraitRight.color = new Color(0.5f, 0.5f, 0.5f);
            portraitLeft.gameObject.SetActive(true);
            portraitLeft.sprite = portraits.Dequeue();
            portraitLeft.color = new Color(1f, 1f, 1f);
        }
        nameText.text = names.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        isActive = false;
        canvasDialogue.gameObject.SetActive(false);
        Destroy(dialogueObject);
    }
}
