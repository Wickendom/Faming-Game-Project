using UnityEngine;

[CreateAssetMenu(fileName = "Seed",menuName = "Item/Seeds")]
public class Seed : Item, IConsumable
{
    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
