using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{   public GameObject player;

    // Start is called before the first frame update
    void Start() //restore state of the object
    {
        RestoreGame();
    }
    void RestoreGame() {

    }
 
    void Update() //checking for a refresh of the save trigger
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            SaveGame();
        }
    }

    void SaveGame(){

    }
}
