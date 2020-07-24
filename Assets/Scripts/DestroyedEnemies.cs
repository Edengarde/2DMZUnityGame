using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedEnemies : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public GameObject[] enemies;

    private bool dialogueCalled;

    //False si necesitas que solo los enemigos sean destruidos para iniciar el dialogo
    //True si necesitas que sean destruidos y ademas que el jugador toque un dialogo
    public bool eDestroyedAndCollider;  
    // Update is called once per frame
    void FixedUpdate()
    {
        if(dialogueCalled == false)
        {
            CheckGameObjects();
        }
    }


    private void CheckGameObjects()
    {
        bool unlockDialogue = false;
        //Revisa si todavia existe un enemigo vivo en la lista de enemigos y si es asi no te deja activar el dialogo
        foreach(GameObject enemy in enemies)
        {
            if (!enemy)
            {
                unlockDialogue = true;
            }
            else
            {
                unlockDialogue = false;
            }
        }

        if (eDestroyedAndCollider == false)
        {
            //Debug.Log(typeOfDialogueUnlock);
            if (unlockDialogue)
            {
                dialogueCalled = true;
                dialogueTrigger.TriggerDialogue();
            }
        }
        else if(eDestroyedAndCollider == true)
        {
            //Debug.Log(typeOfDialogueUnlock);
            if (unlockDialogue)
            {
                dialogueCalled = true;
                dialogueTrigger.collisionTriggerNeeded = true;
            }
        }
       

    }
}
