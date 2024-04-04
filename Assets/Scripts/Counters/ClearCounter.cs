using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
   

    

    public override void Interact(Player player){
        if (!HasKitchenObject()){

            if (player.HasKitchenObject()){

                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {

            }
        } else {
                if (player.HasKitchenObject()){

                    if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)){
		                  // 角色拿的是盘子
		                  // PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
		                  if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())){
				                GetKitchenObject().DestroySelf();
		                  }
                    }else {
		                  // 角色拿的不是盘子，而是别的东西
		                  if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
		                  {
				                if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()) )
				                {
					                 player.GetKitchenObject().DestroySelf();
				                }
		                  }
                    }
                 } else {
                    GetKitchenObject().SetKitchenObjectParent(player);
                }
        }
     }  
}