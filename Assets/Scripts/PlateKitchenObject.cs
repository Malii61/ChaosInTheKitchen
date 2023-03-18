using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedArgs> OnIngredientAdded;
    public class OnIngredientAddedArgs : EventArgs
    {
        public KitchenObjectsSO kitchenObjectSO;
    }
    [SerializeField] private List<KitchenObjectsSO> validKitchenObjectsSOList;
    private List<KitchenObjectsSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectsSO>();
    }
    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {
        if (!validKitchenObjectsSOList.Contains(kitchenObjectsSO) || kitchenObjectSOList.Contains(kitchenObjectsSO))
        {
            //Not a valid ingredient or Already hast this type
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectsSO);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedArgs
            {
                kitchenObjectSO = kitchenObjectsSO
            });
            return true;
        }
    }
    public List<KitchenObjectsSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
