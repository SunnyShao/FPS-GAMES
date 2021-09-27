using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour
{
    public static PlayerInputHandle _instance;
    [Tooltip("����ƶ�������")]
    public float lookSensitivity = 1f;


    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public float GetMouseLookHorizontalAxis()
    {
        return GetMouseLookAxis("Mouse X");
    }
    
    public float GetMouseLookVerticalAxis()
    {
        return GetMouseLookAxis("Mouse Y");
    }

    //��ȡ���ĳ��������ƶ�
    private float GetMouseLookAxis(string mouseInputName)
    {
        return Input.GetAxis(mouseInputName) * lookSensitivity * 0.05f;
    }
} 
