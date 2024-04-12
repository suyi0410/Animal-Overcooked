using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter, IHasProgress{
        

        public static EventHandler OnAnyCut;

        new public static void ResetStaticData(){
            OnAnyCut = null;
        }

    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
        public event EventHandler OnCut;

        [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

        private int cuttingProgress;

        public override void Interact(Player player){
            if (!HasKitchenObject()){
                // 柜子上没有物品
                if (player.HasKitchenObject()){
                    // 角色有物品，放置物品
                    if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())){
                        player.GetKitchenObject().SetKitchenObjectParent(this);
                        cuttingProgress = 0;

                        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                        
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs{
                            progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                        });
                    }
                } else{
                    // 角色没有物品
                    }
            } else{
                // 柜子上有物品
                if (player.HasKitchenObject()){
                    // 角色有物品
                    if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)){
		  // 角色拿的是盘子
		  // PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
		  if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
		  {
				GetKitchenObject().DestroySelf();
		  }
                        
                    }
                    
                } else{
                    // 角色没有物品，拾取物品
                    GetKitchenObject().SetKitchenObjectParent(player);
                    }
            }
        }
        public override void InteractAlternate(Player player){
            if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())){
                // 柜子上有物品，开始切菜
                cuttingProgress++;

                OnCut?.Invoke(this, EventArgs.Empty);
                OnAnyCut?.Invoke(this, EventArgs.Empty);

                CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    
                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs{
                        progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                    });

                if (cuttingProgress >= GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO()).cuttingProgressMax){
                    KitchenObjectSO cutKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
                    
                    GetKitchenObject().DestroySelf();
                    
                    KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
                }               
            }
        }

       private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO){
            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
            return cuttingRecipeSO != null;
        }

        private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO){
             CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
                if (cuttingRecipeSO != null){
                    return cuttingRecipeSO.output;
                } else{
                    return null;
                }
         }

         private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO){
            foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray){
                if (cuttingRecipeSO.input == inputKitchenObjectSO){
                    return cuttingRecipeSO;
                }
            }
            return null;
         }
    
}
