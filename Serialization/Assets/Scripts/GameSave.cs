using System.Collections;
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
        GetColor();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
            SetColor();
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

    void SetColor()
    {
        PlayerPrefs.SetString("StoredColor", ColorUtility.ToHtmlStringRGBA(color));
    }

    public Color GetColor()
    {
        var storedColorAsString = "#" + PlayerPrefs.GetString("StoredColor");
        Color result;
        ColorUtility.TryParseHtmlString(storedColorAsString, out result);
        return result;
    }
}
