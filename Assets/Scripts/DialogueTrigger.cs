using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool collisionTriggerNeeded;

    public bool wasTriggered;

    public void TriggerDialogue()
    {
        if (dialogue.isImportantDialogue)
        {
            FindObjectOfType<DialogueManagerImportant>().StartDialogue(dialogue, gameObject);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            //StartCoroutine(DestroyDialogueObject());
            Destroy(gameObject);
        }
       
    }

    IEnumerator DestroyDialogueObject()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player" && collisionTriggerNeeded  && !wasTriggered)
        {
            TriggerDialogue();
            wasTriggered = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" && collisionTriggerNeeded && !wasTriggered)
        {
            TriggerDialogue();
            wasTriggered = true;
        }
    }

}
