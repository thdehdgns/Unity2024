using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    PlayerMove playerMove;
    public bool IsplayerDeath = false;
    Animator animator;
   
    public enum PlayerState { Idle, Run, Death}

    PlayerState playerstate;

    private void Awake()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsplayerDeath == true) return;
        SetPlayerState();
        playerMove.Move(transform);

    }

    private void SetPlayerState()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (v != 0 || h != 0)
        {
            playerstate = PlayerState.Run;
        }
        else
        {
            playerstate = PlayerState.Idle;
        }
    }
    
    
    // �ѹ��� �����ϸ� �Ǵ� ����� ������
    void Initialize()
    {
        // Animator Ŭ������ ������ �� �� �ְ� ��.
        playerstate = PlayerState.Idle;
        playerMove = new PlayerMove();
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayerDeath()
    {
        //if (animator == null) return;

        if (IsplayerDeath == true) return;

        animator?.SetTrigger("Death");
        IsplayerDeath = true;
    }

    public void PlayerMove()
    {
        animator.SetBool("IsRun", true);
    }

    public void PlayerIdle()
    {
        animator.SetBool("Isrun", false);
    }

    private void SetPlayerAnimation()
    {
        if (playerstate == PlayerState.Idle)
        {
            PlayerIdle();
        }
        else if (playerstate == PlayerState.Run)
        {
            PlayerMove();
        }
    }
    //���� ���� ���¸� �Ǻ����ִ� �Լ�  
}