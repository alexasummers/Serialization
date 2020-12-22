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
        Debug.Log(PlayerPrefs.GetString("StoredColor")); //kosher
        string storedColorAsString = "#" + PlayerPrefs.GetString("StoredColor");
        Debug.Log("This is storedColorAsString: " + storedColorAsString); //kosher
        ColorUtility.TryParseHtmlString(storedColorAsString, out result); //kosher
        Debug.Log("This is result: " + result); //kosher
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

    void SaveGame() //debugged
    {

        Color gameobj = player.GetComponent<MeshRenderer>().material.color;
        Debug.Log("This is gameobj before string: " + gameobj); //kosher
        PlayerPrefs.SetString("StoredColor", ColorUtility.ToHtmlStringRGBA(gameobj)); // kosher 
        Debug.Log("This is gameobj: " + gameobj); //kosher
        Debug.Log("This is storedColor: " + ColorUtility.ToHtmlStringRGBA(gameobj)); //kosher

        SavePosition s = new SavePosition();
        s.x = player.transform.position.x;
        s.y = player.transform.position.y;

        string json = JsonUtility.ToJson(s);
        Debug.Log (json);
        PlayerPrefs.SetString("PlayerLocation", json);

               
    }
}
