using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    //����ʼ���е���������
    public List<WeaponController> StartingWeapons = new List<WeaponController>();

    //���������ĸ��ڵ�
    public Transform weaponParent;

    //��ǰ��������
    private List<WeaponController> m_WeaponSlots = new List<WeaponController>(9);

    //����ѡ���¼�
    private Action<WeaponController> OnWeaponSwitched;


    private void Start()
    {
        OnWeaponSwitched += OnWeaponSwitch;

        InitWeaponList();

        SwitchWeapon();
    }

    private void InitWeaponList()
    {
        foreach (WeaponController item in StartingWeapons)
        {
            AddWeapon(item);
        }
    }

    //������������б�
    private bool AddWeapon(WeaponController weaponItem)
    {
        //װ��δ�ﵽ���� ��ɼ����������
        if (m_WeaponSlots.Count <= m_WeaponSlots.Capacity)
        {
            WeaponController tempWeapon = Instantiate(weaponItem, weaponParent);
            //tempWeapon.transform.position  ������ʱ������Ĭ��ֵ  �����Ƿ�������ʾ TODO 
            tempWeapon.owner = this.gameObject; //���������ĳ�����Ϊ��ǰPlayer
            tempWeapon.ShowWeapon(false);

            m_WeaponSlots.Add(tempWeapon);

            return true;
        }
        return false;
    }

    //ѡ������
    private void SwitchWeapon()
    {
        SwitchToWeaponIndex(0); //TODO ��ʱѡ���һ������Ϊ�˲���
    }

    //��������ѡ������
    private void SwitchToWeaponIndex(int newWeaponIndex)
    {
        var curWeaponItem = GetWeaponAtSlotIndex(newWeaponIndex);
        if (curWeaponItem)
            OnWeaponSwitched?.Invoke(curWeaponItem); //����ѡ��
    }

    //����ѡ��
    private void OnWeaponSwitch(WeaponController newWeapon)
    {
        newWeapon.ShowWeapon(true);
    }

    //�ӵ�ǰ�����б����õ�����
    private WeaponController GetWeaponAtSlotIndex(int index)
    {
        if(index >= 0 && index < m_WeaponSlots.Count)
        {
            return m_WeaponSlots[index];
        }
        return null;
    }
}
