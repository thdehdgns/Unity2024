using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    // �̱���
    private static ShakeCamera instance;
    public static ShakeCamera Instance => instance;

    public ShakeCamera() 
    {
        instance = this;
    }

    // ī�޶� ��鸲 ���� ����
    private float shakeTime;       // ���Ÿ��� �ð�
    private float shakeIntensity;  // ��鸲 ����

    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntenisty = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntenisty;

        StopCoroutine(ShakeByPosition());
        StartCoroutine(ShakeByPosition());
    }

    private IEnumerator ShakeByPosition()
    {
        Vector3 startPos = transform.position;  // ���� ī�޶��� ��ġ ����

        while(shakeTime > 0.0f)  // ī�޶� ��鸮�� �ڵ� ������
        {
            transform.position = startPos + UnityEngine.Random.insideUnitSphere * shakeIntensity;

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPos; // ��鸲�� ������ ���� ��ġ��
    }

    private IEnumerator ShakeByRotation()
    {
        Vector3 startRot = transform.eulerAngles;

        float power = 10f;

        while (shakeTime > 0.0f)  // ī�޶� ��鸮�� �ڵ� ������
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
