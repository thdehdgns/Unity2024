using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    // 카메라는 플레이어와 같은 거리를 유지하고싶다. 

    // 카메라의 위치 정보가 필요하다.
    
    public Vector3 offset;
    
    // 플레이어의 위치정보를 가지고오기위한 방법.
    public GameObject playerPosition;


    void Start()
    {
        offset = transform.position - playerPosition.transform.position;
        //각주
    }

    void Update()
    {
        //카메라의 위치를 offset 플레이어와 카메라에 거리를 저장했다.
        
        //카메라와 플레이어의 사이의 거리는 무조건 offset이 되어아햔다
        
        //플레이어의 이동을 구현함. 플레이어는 이 스크립트와 관계없이 이동.
        
        transform.position = playerPosition.transform.position + offset;
       
        // transform.position += offset; 이 코드는 위와같은 코드다.
        
        offset = transform.position - playerPosition.transform.position;

        
        
    }
}
