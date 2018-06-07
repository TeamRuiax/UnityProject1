using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Rigidbody rb;
    public float speed = 4;

    Vector3 lookPos; // 보고있는 포지션 값

	void Start ()
    {
        rb = GetComponent<Rigidbody>();	
	}
	void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,100))
        {
            lookPos = hit.point;
        }
        Vector3 lookDir = lookPos - transform.position; // 현재 보고있는 위치와 내 위치를 뺀값 
        //ex) [내 캐릭터]x값 100에 위치에서 [마우스]x값100을 가리키면 100-100 = 결국 0 나자신을 가리키는것
        lookDir.y = 0; // y축은 고정
        transform.LookAt(transform.position + lookDir, Vector3.up);
    }

	void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        rb.AddForce(move * speed/Time.deltaTime);

    }
}
