using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    // ī�޶�� �÷��̾�� ���� �Ÿ��� �����ϰ�ʹ�. 

    // ī�޶��� ��ġ ������ �ʿ��ϴ�.
    
    public Vector3 offset;
    
    // �÷��̾��� ��ġ������ ������������� ���.
    public GameObject playerPosition;


    void Start()
    {
        offset = transform.position - playerPosition.transform.position;
        //����
    }

    void Update()
    {
        //ī�޶��� ��ġ�� offset �÷��̾�� ī�޶� �Ÿ��� �����ߴ�.
        
        //ī�޶�� �÷��̾��� ������ �Ÿ��� ������ offset�� �Ǿ���h��
        
        //�÷��̾��� �̵��� ������. �÷��̾�� �� ��ũ��Ʈ�� ������� �̵�.
        
        transform.position = playerPosition.transform.position + offset;
       
        // transform.position += offset; �� �ڵ�� ���Ͱ��� �ڵ��.
        
        offset = transform.position - playerPosition.transform.position;

        
        
    }
}
