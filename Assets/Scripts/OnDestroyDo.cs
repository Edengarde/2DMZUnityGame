using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyDo : MonoBehaviour
{
    public GameObject[] onGameObject;
    public GameObject[] offGameObject;

    //0 = Turn Off and Turn On stuff
    //1 = Just turn off stuff
    //2 = Just turn on stuff
    public bool destroyStuff;
    public bool createStuff;
    private void OnDestroy()
    {
        if (destroyStuff)
        {
            TurnOffGameObjects();
        }
        if (createStuff){
            TurnOnGameObjects();
        }
    }

    private void TurnOffGameObjects()
    {
        foreach (GameObject gameObjectOff in offGameObject)
        {
            gameObjectOff.gameObject.SetActive(false);
        }
    }

    private void TurnOnGameObjects()
    {
        foreach (GameObject gameObjectOn in onGameObject)
        {
            gameObjectOn.gameObject.SetActive(true);
        }
    }
}
