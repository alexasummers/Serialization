using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public GameObject player;

    Sprite m_InSprite;

    SaveColor exportObj = new SaveColor();

    SaveColor importObj = new SaveColor();

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
                position.x = (Random.value - 0.5f) * s.x;
                position.y = (Random.value - 0.5f) * s.y;
                position.z = (Random.value - 0.5f) * s.z;
                player.transform.position = position;

                Texture2D tex = m_InSprite.texture;
                exportObj.x = tex.width;
                exportObj.y = tex.height;
                exportObj.bytes = ImageConversion.EncodeToPNG(tex);
                string text = JsonUtility.FromJson<SaveColor>(exportObj);
                File.WriteAllText(@"d:\test.json", text);
            }
        }
    }

    void Update() //checking for a refresh of the save trigger
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
    }
}
