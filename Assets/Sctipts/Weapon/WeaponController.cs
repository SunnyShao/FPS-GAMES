using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Tooltip("�����ĸ��ڵ㣬����������������")]
    public GameObject WeaponRoot;

    //�����ĳ������
    public GameObject owner;

    //��������   ��һֱ���ÿ���ֱ����  .gameobject����Ķ���  ���������� TODO
    public GameObject sourcePerfab;

    //��������
    public void ShowWeapon(bool isShow)
    {
        WeaponRoot.SetActive(isShow);
        //�Ƿ������ı�־λ��ʱ��д   ���ò���ȷ
    }
      
}
