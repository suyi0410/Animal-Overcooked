﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent{

	
	public static Player Instance{ get; private set ;}



	public event EventHandler OnPickUpSomething;
	public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
	public class OnSelectedCounterChangedEventArgs : EventArgs{
        public BaseCounter selectedCounter;
    }
   
	[SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
	[SerializeField] private LayerMask countersLayerMask;
	[SerializeField] private Transform kitchenObjectHoldPoint;
	    
	
	private bool isWalking;
	private Vector3 lastInteractDir; 
	private BaseCounter selectedCounter;
	private KitchenObject kitchenObject;

	private void Awake(){
		if (Instance != null){
            Debug.LogError("There is more than one Player instance");
        }
		Instance = this;
	}
	private void Start(){
		gameInput.OnInteractAction += GameInput_OnInteractAction;
		gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
	}
	
	private void GameInput_OnInteractAlternateAction(object sender, EventArgs e){
		if (!KitchenGameManager.Instance.IsGamePlaying()) return;

        if (selectedCounter != null){
            selectedCounter.InteractAlternate(this);
        }
    }

	private void GameInput_OnInteractAction(object sender, System.EventArgs e){
		if (!KitchenGameManager.Instance.IsGamePlaying()) return;

		if (selectedCounter != null){
            selectedCounter.Interact(this);
        }
	}


	private void Update(){
        HandleMovement();
        HandleInteractions();
    }
    
    public bool IsWalking(){
        return isWalking;
    }

    private void HandleInteractions(){
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
	  
		Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

		
	          
		if (moveDir != Vector3.zero){
			lastInteractDir = moveDir;
		}
	  
		float interactDistance = 2f;
		if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit,interactDistance, countersLayerMask)){
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter)){
                
                if (baseCounter != selectedCounter){
                    SetSelectedCounter(baseCounter);			
				} 
            } else{
				SetSelectedCounter(null);
				}
        } else{
				SetSelectedCounter(null);
			}
        
        Debug.Log(selectedCounter);
    }



		private void HandleMovement(){
		   
    
			Vector2 inputVector = gameInput.GetMovementVectorNormalized();
       
			Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        
			float moveDistance = moveSpeed * Time.deltaTime;  
			float playerRadius = .7f;
			float playerHeight = 2f;
			bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

			if (!canMove){
				//当不能向moveDir方向移动时
	
				// 尝试沿x轴移动
				Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized; // 归一化让速度和直接左右移动相同
				//canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
				canMove = (moveDir.x < -0.5f || moveDir.x > 0.5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
			
				if (canMove){
					 // 可以沿x轴移动
					moveDir = moveDirX;
				} 
				else{
					// 不能向x轴方向移动，尝试向z轴方向移动
					Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized; // 归一化让速度和直接左右移动相同
					 //canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
					canMove = (moveDir.z < -0.5f || moveDir.z > 0.5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

					if (canMove){
						// 可以向z轴方向移动
						moveDir = moveDirZ;
					} 
					else{
						// 不能朝任何方向移动
					}
			}
		}

		if (canMove){
			transform.position += moveDir * Time.deltaTime * moveSpeed;
		}
        isWalking = (inputVector != Vector2.zero);
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
	}

	private void SetSelectedCounter(BaseCounter selectedCounter){
        this.selectedCounter = selectedCounter;
        
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs{
            selectedCounter = selectedCounter
        });
    }
	public Transform GetKitchenObjectFollowTransform(){
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject){
        this.kitchenObject = kitchenObject;
		if (kitchenObject != null){
            OnPickUpSomething?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject(){
        return kitchenObject;
    }
    
    public void ClearKitchenObject(){
        kitchenObject = null;
    }
    
    public bool HasKitchenObject(){
        return kitchenObject != null;
    }
    
}



