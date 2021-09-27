using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public static PlayerCharacterController _instance;

    [Header("��������")]

    [Tooltip("�ƶ��ٶ�")]
    [Range(0.5f, 10)]
    public float playerMoveSpeed = 5f;
    [Tooltip("�����½����ٶ�")]
    public float gravityDownForce = 20f;
    [Tooltip("�ڵ������ƶ����(�ٶ�)")]
    public float playerMoveSharpnessOnGround = 15f;

    [Header("������")]
    public Camera playerCamera;
    [Tooltip("������ƶ��ٶ�")]
    public float cameraRotationSpeed = 200f;

    private CharacterController characterController;

    //�������
    private float targetCharacterHeight = 1.8f;
    //�������ĽǶ�ֵ
    private float cameraVerticalAngle = 0f;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        playerCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        characterController.enableOverlapRecovery = true;
    }


    private void Update()
    {
        HandleCharacterMovement();
    }

    //����������ز���
    private void HandleCharacterMovement()
    {
        //Ϊʲô������������ƶ���ʱ�������� transform.Rotate ������ playerCamera.transform.Rotate�� �������������������ת����ô�����ͬ���Ľ�ɫʲô������ᱩ¶����(����ǹе֮���)
        transform.Rotate(new Vector3(0f, PlayerInputHandle._instance.GetMouseLookHorizontalAxis() * cameraRotationSpeed, 0f));
        //������������ƶ�
        cameraVerticalAngle += PlayerInputHandle._instance.GetMouseLookVerticalAxis() * cameraRotationSpeed;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);
        playerCamera.transform.localEulerAngles = new Vector3(-cameraVerticalAngle, 0, 0);

        //�ƶ�
        if (characterController.isGrounded)
        {
            characterController.Move(transform.TransformVector(Vector3.forward * Input.GetAxis("Vertical")) * Time.deltaTime * playerMoveSpeed);
            characterController.Move(transform.TransformVector(Vector3.right * Input.GetAxis("Horizontal")) * Time.deltaTime * playerMoveSpeed);
        }
        else
        {
            characterController.Move(Vector3.down * gravityDownForce * Time.deltaTime);
        }
    }
}
