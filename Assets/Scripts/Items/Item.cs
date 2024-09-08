using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string Name;
    public Sprite ItemSprite;

    public abstract void Use();  
}
