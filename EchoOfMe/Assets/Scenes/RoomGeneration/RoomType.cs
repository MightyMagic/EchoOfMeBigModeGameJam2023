using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomScriptableObject", menuName = "Room")]
public class RoomType : ScriptableObject
{
    [Header("Properties")]
    public string roomName;
    public int roomWidth;
    public int roomLength;

    [Header("Decorations")]
    public GameObject[] furnitureSelection;
}
