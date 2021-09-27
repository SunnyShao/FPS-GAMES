using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public static PlayerCharacterController _instance;

    [Header("主角属性")]

    [Tooltip("移动速度")]
    [Range(0.5f, 10)]
    public float playerMoveSpeed = 5f;
    [Tooltip("空中下降的速度")]
    public float gravityDownForce = 20f;
    [Tooltip("在地面上移动锐度(速度)")]
    public float playerMoveSharpnessOnGround = 15f;

    [Header("相机相关")]
    public Camera playerCamera;
    [Tooltip("摄像机移动速度")]
    public float cameraRotationSpeed = 200f;

    private CharacterController characterController;

    //主角身高
    private float targetCharacterHeight = 1.8f;
    //相机纵向的角度值
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

    //控制主角相关操作
    private void HandleCharacterMovement()
    {
        //为什么控制鼠标左右移动的时候，这里用 transform.Rotate 而不是 playerCamera.transform.Rotate？ 如果这里控制了相机的旋转，那么和相机同级的角色什么的物体会暴露出来(比如枪械之类的)
        transform.Rotate(new Vector3(0f, PlayerInputHandle._instance.GetMouseLookHorizontalAxis() * cameraRotationSpeed, 0f));
        //控制相机上下移动
        cameraVerticalAngle += PlayerInputHandle._instance.GetMouseLookVerticalAxis() * cameraRotationSpeed;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);
        playerCamera.transform.localEulerAngles = new Vector3(-cameraVerticalAngle, 0, 0);

        //移动
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
