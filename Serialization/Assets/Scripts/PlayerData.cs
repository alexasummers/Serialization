using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public float[] position;

    public float[] color;

    public PlayerData(Player player)
    {
        // position = new float[3];
        // position[0] = player.transform.position.x;
        // position[1] = player.transform.position.y;
        // position[2] = player.transform.position.z;

        color = new float[4];
        color[0] = player.color.r;
        color[1] = player.color.g;
        color[2] = player.color.b;
        color[3] = player.color.a;
    }
}
