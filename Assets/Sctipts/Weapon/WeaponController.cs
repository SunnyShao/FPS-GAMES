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

    //ǹ����Ч
    public GameObject muzzleParticle;

    //ǹ����Ч���ڵ�
    public Transform muzzleTrans;

    //�������ʱ����
    private float weaponShotsInterval = 0.1f;

    //�ϴ����ʱ��
    private float lastShootTime = -1;

    //��������
    public void ShowWeapon(bool isShow)
    {
        WeaponRoot.SetActive(isShow);
        //�Ƿ������ı�־λ��ʱ��д   ���ò���ȷ
    }
      

    //��������
    public void HandleShootInputs(bool inputHold)
    {
        if(inputHold)
        {
            TryShoot();
        }
    }

    //���
    private void TryShoot()
    {
        if (lastShootTime + weaponShotsInterval < Time.time) //���һ��ʱ�䷢���ӵ�
        {
            HandleShoot();
            lastShootTime = Time.time;
        }
    }

    //�������
    private void HandleShoot()
    {
        if(muzzleParticle)
        {
            GameObject shotParticle =  Instantiate(muzzleParticle, muzzleTrans);
            Destroy(shotParticle, 2f);
        }
    }


}
