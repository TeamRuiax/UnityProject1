using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;            // 카메라 타겟팅
    public float smoothing = 5f;        // 카메라가 따라가는 속도

    Vector3 offset;                     // 초기세팅
    Vector3 lookPos;
    void Start()
    {
        // 초기세팅 계산
        offset = transform.position - target.position;
    }
    void Update()
    {
        //if(transform.position.x-target.position.x>10||transform.position.x-target.position.x<-10)
        //{
        //          시야 제한 필요
        //}
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }
        Vector3 lookDir = lookPos;
        lookDir.y = target.position.y; // y축은 타겟의 y를 따라감
                      
        Vector3 targetCamPos = target.position + offset; // 카메라 베이스

        
        Debug.Log(lookDir);
        //transform.position = (targetCamPos + lookDir) / 2;
        // 캐릭터와 마우스위치의 중간값 = 카메라 위치
        transform.position = Vector3.Lerp(lookDir, targetCamPos, 0.8f);
    }
}
