using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    //회전기능 구현 


    public float rotateSpeed = 200f;

    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.IsplayerDeath) return;

        RotatePlayer();
    }

    private void RotatePlayer()
    {
        // a와 d키를 입력했을 때 회전하는 기능

        // 입력 구현, 회전 구현

        float horizontal = Input.GetAxis("Horizontal");  // -1 ~ 1 사이 값을 반환 해주는 기능

        float yaw = horizontal * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw, Space.World); // 절대 좌표와 상대좌표 
    }
}
