using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter{

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

    public override void Interact(Player player){
        if (!HasKitchenObject()){
            // 柜子上没有物品
            if (player.HasKitchenObject()){
                // 角色有物品，放置物品
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())){
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
            } else{
                // 角色没有物品
                }
        } else{
            // 柜子上有物品
            if (player.HasKitchenObject()){
                // 角色有物品
            } else{
                // 角色没有物品，拾取物品
                GetKitchenObject().SetKitchenObjectParent(player);
                }
        }
    }
        public override void InteractAlternate(Player player){
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())){
            // 柜子上有物品，开始切菜
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

        private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO){
            foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray){
                if (cuttingRecipeSO.input == inputKitchenObjectSO){
                    return true;
                }
            }
            return false;
        }

        private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO){
            foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray){
                if (cuttingRecipeSO.input == inputKitchenObjectSO){
                    return cuttingRecipeSO.output;
                }
            }
            return null;
        }

}
