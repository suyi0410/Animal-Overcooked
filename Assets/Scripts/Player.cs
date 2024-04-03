using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;
    
    private void Update(){
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
       
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        
		float moveDistance = moveSpeed * Time.deltaTime;  
		float playerRadius = .7f;
		float playerHeight = 2f;
		bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

		if (!canMove){
			// 当不能向moveDir方向移动时
	
			// 尝试沿x轴移动
			Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized; // 归一化让速度和直接左右移动相同
			canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

			if (canMove){
				 // 可以沿x轴移动
				moveDir = moveDirX;
			} 
			else{
				// 不能向x轴方向移动，尝试向z轴方向移动
				 Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized; // 归一化让速度和直接左右移动相同
				 canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

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
    
    public bool IsWalking(){
        return isWalking;
    }
}
