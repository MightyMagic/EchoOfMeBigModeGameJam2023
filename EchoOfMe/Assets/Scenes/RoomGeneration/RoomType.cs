using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomScriptableObject", menuName = "Room")]
public class RoomType : ScriptableObject
{
    [Header("Properties")]
    public string roomName;
    public int roomWidth;
    public int roomLength;

    [Header("Decorations")]
    public Furniture[] furniture;
}

[System.Serializable]
public class Furniture
{
    public int chance = 80;
    public GameObject prefab;
}