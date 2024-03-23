using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    // 싱글톤
    private static ShakeCamera instance;
    public static ShakeCamera Instance => instance;

    public ShakeCamera() 
    {
        instance = this;
    }

    // 카메라 흔들림 제어 변수
    private float shakeTime;       // 흔들거리는 시간
    private float shakeIntensity;  // 흔들림 강도

    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntenisty = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntenisty;

        StopCoroutine(ShakeByPosition());
        StartCoroutine(ShakeByPosition());
    }

    private IEnumerator ShakeByPosition()
    {
        Vector3 startPos = transform.position;  // 현재 카메라의 위치 저장

        while(shakeTime > 0.0f)  // 카메라가 흔들리는 코드 구현부
        {
            transform.position = startPos + UnityEngine.Random.insideUnitSphere * shakeIntensity;

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPos; // 흔들림이 끝나면 원래 위치로
    }

    private IEnumerator ShakeByRotation()
    {
        Vector3 startRot = transform.eulerAngles;

        float power = 10f;

        while (shakeTime > 0.0f)  // 카메라가 흔들리는 코드 구현부
        {
            float x = 0;
            float y = 0;
            float z = UnityEngine.Random.Range(-1f, 1f);
            transform.rotation = Quaternion.Euler(startRot + new Vector3(x, y, z) * shakeIntensity * power);

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.rotation = Quaternion.Euler(startRot);
    }
}
