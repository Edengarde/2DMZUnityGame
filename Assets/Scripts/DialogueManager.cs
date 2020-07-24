using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image portraitImg;
    public Canvas canvasDialogue;
 
    private Queue<string> names;
    private Queue<string> sentences;
    private Queue<Sprite> portraits;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        portraits = new Queue<Sprite>();
        names = new Queue<string>();
    }

    //Inicializa el dialogo
    public void StartDialogue (Dialogue dialogue)
    {
        canvasDialogue.gameObject.SetActive(true);
        names.Clear();
        sentences.Clear();
        portraits.Clear();

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (Sprite portrait in dialogue.portraits)
        {
            portraits.Enqueue(portrait);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        portraitImg.sprite = portraits.Dequeue();
        nameText.text = names.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
        StartCoroutine(DialogueTimer());
    }
    IEnumerator DialogueTimer()
    {
        yield return new WaitForSeconds(2.5f);
        DisplayNextSentence();
    }

    IEnumerator TypeSentence (string sentence)
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
        canvasDialogue.gameObject.SetActive(false);
    }
}
