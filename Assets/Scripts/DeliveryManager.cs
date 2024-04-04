using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour{


    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted; 
    public event EventHandler OnRecipeSuccess; 
    public event EventHandler OnRecipeFailed; 

    public static DeliveryManager Instance { get; private set; }
    
    [SerializeField] private RecipeListSO recipeListSO;
    
    private List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingRecipesMax = 4;
    private int successfulRecipesAmount;


    private void Awake(){
        Instance = this;
        waitingRecipeSOList = new List<RecipeSO>();
    }

    private void Update(){
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f){
            spawnRecipeTimer += spawnRecipeTimerMax;

            if (waitingRecipeSOList.Count < waitingRecipesMax){
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                waitingRecipeSOList.Add(waitingRecipeSO);
                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject){
        for (int i = 0; i < waitingRecipeSOList.Count; i++){
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];
            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count){
                // 订单中的菜品与送上去的菜品由同样数量的物品组成
                bool plateContentsMatchesRecipe = true;
                foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList){
                    // 遍历订单中的菜品所组成的物品
                    bool ingredientFound = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList()){
                        // 遍历送上去的菜品所组成的物品
                        if (recipeKitchenObjectSO == plateKitchenObjectSO){
                            // 订单中的菜品与送上去的菜品由同样的物品组成
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound){
                        // 订单中的菜品与送上去的菜品由不同的物品组成
                        plateContentsMatchesRecipe = false;
                    }
                }

                if (plateContentsMatchesRecipe){
                    successfulRecipesAmount++;

                    waitingRecipeSOList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        // 遍历了所有订单，没有找到匹配的订单
        //Debug.Log("Player did not deliver a correct recipe!");
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
    }

   public List<RecipeSO> GetWaitingRecipeSOList(){
        return waitingRecipeSOList;
    } 

    public int GetSuccessfulRecipesAmount(){
        return successfulRecipesAmount;
    }
}