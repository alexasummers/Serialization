using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public GameObject player;
    public Color result;

    void Start()
    {
        RestoreGame();
    }

    void RestoreGame()
    {
        
        string storedColorAsString = "#" + PlayerPrefs.GetString("StoredColor");
        Debug.Log("This is storedColorAsString: " + storedColorAsString);
        ColorUtility.TryParseHtmlString(storedColorAsString, out result);
        Debug.Log("This is result: " + result);
        player.GetComponent<MeshRenderer>().material.color = Color.blue;

        
        string p = PlayerPrefs.GetString("PlayerLocation");
        if (p != null && p.Length > 0)
        {
            SavePosition s = JsonUtility.FromJson<SavePosition>(p);
            if (s != null)
            {
                Vector2 position = new Vector2();
                position.x = s.x;
                position.y = s.y;
                player.transform.position = position;
            }
        }
        // player.GetComponent<MeshRenderer>().material.SetColor("_Color", result);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }

    void SaveGame()
    {

        Color gameobj = player.GetComponent<MeshRenderer>().material.color;
        Debug.Log("This is gameobj before string: " + gameobj); //kosher
        PlayerPrefs.SetString("StoredColor", ColorUtility.ToHtmlStringRGBA(gameobj)); // PlayerPrefs sends the information to the next scene 
        Debug.Log("This is gameobj: " + gameobj); //kosher
        
        SavePosition s = new SavePosition();
        s.x = player.transform.position.x;
        s.y = player.transform.position.y;

        string json = JsonUtility.ToJson(s);
        Debug.Log (json);
        PlayerPrefs.SetString("PlayerLocation", json);

               
    }
}
