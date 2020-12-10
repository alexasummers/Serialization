﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public GameObject player;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        RestoreGame();
    }

    void RestoreGame()
    {
        string p = PlayerPrefs.GetString("PlayerLocation");
        if (p != null && p.Length > 0)
        {
            SavePosition s = JsonUtility.FromJson<SavePosition>(p);
            if (s != null)
            {
                Vector3 position = new Vector3();
                position.x = s.x;
                position.y = s.y;
                position.z = s.z;
                player.transform.position = position;
            }
        }

        string storedColorAsString = "#" + PlayerPrefs.GetString("StoredColor");
        Color result;
        ColorUtility.TryParseHtmlString(storedColorAsString, out result);
        player.GetComponent<MeshRenderer>().material.color = result;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }

    void SaveGame()
    {
        SavePosition s = new SavePosition();
        s.x = player.transform.position.x;
        s.y = player.transform.position.y;
        s.z = player.transform.position.z;

        string json = JsonUtility.ToJson(s);
        Debug.Log (json);
        PlayerPrefs.SetString("PlayerLocation", json);

        Color gameobj = player.GetComponent<MeshRenderer>().material.color;
        PlayerPrefs.SetString("StoredColor", ColorUtility.ToHtmlStringRGBA(gameobj)); // PlayerPrefs sends the information to the next scene
        
    }
}
