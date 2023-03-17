using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            Debug.Log("Eli boþ");
            // There is no kitchen object here
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                Debug.Log(player.GetKitchenObject());
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            //There is a KitchenObject here
            if (player.HasKitchenObject())
            {
                // Player is carrying something
            }
            else
            {
                // Player is carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
