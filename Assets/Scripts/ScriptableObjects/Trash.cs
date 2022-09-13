using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum trashTypes
{
    Verre, Plastique, Dechets, Carton, Cat
}

[CreateAssetMenu(fileName = "Trash",menuName = "ScriptableObject/Trash")]
public class Trash : ScriptableObject
{
    public int score = 100;

    public trashTypes type;
    public GameObject mesh;

}

