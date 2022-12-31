using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float minX,maxX,minY,maxY;
    private Vector3 tempPos;
    private void Awake() {
        target = GameObject.FindWithTag("Player").transform;
    }
    private void LateUpdate() {
        FollowPlayer();
        
    }
    void FollowPlayer(){
        if(!target)
            return;
        tempPos = transform.position;
        tempPos.x = target.position.x;
        tempPos.y =target.position.y;

        if(tempPos.x < minX)
            tempPos.x = minX;
        if(tempPos.x > maxX)
            tempPos.x = maxX;
        if(tempPos.y < minY)
            tempPos.y = minY;
        if(tempPos.y > maxY)
            tempPos.y = maxY;
        
        transform.position = tempPos;

    }
}
