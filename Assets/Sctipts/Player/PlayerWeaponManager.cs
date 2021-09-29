using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    //玩家最开始持有的武器队列
    public List<WeaponController> StartingWeapons = new List<WeaponController>();

    //挂载武器的父节点
    public Transform weaponParent;

    //当前的武器池
    private List<WeaponController> m_WeaponSlots = new List<WeaponController>(9);

    //武器选择事件
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

    //添加新武器到列表
    private bool AddWeapon(WeaponController weaponItem)
    {
        //装备未达到上限 则可继续添加武器
        if (m_WeaponSlots.Count <= m_WeaponSlots.Capacity)
        {
            WeaponController tempWeapon = Instantiate(weaponItem, weaponParent);
            //tempWeapon.transform.position  这里暂时不设置默认值  看看是否正常显示 TODO 
            tempWeapon.owner = this.gameObject; //设置武器的持有者为当前Player
            tempWeapon.ShowWeapon(false);

            m_WeaponSlots.Add(tempWeapon);

            return true;
        }
        return false;
    }

    //选择武器
    private void SwitchWeapon()
    {
        SwitchToWeaponIndex(0); //TODO 临时选择第一个武器为了测试
    }

    //根据索引选择武器
    private void SwitchToWeaponIndex(int newWeaponIndex)
    {
        var curWeaponItem = GetWeaponAtSlotIndex(newWeaponIndex);
        if (curWeaponItem)
            OnWeaponSwitched?.Invoke(curWeaponItem); //武器选择
    }

    //武器选择
    private void OnWeaponSwitch(WeaponController newWeapon)
    {
        newWeapon.ShowWeapon(true);
    }

    //从当前武器列表中拿到武器
    private WeaponController GetWeaponAtSlotIndex(int index)
    {
        if(index >= 0 && index < m_WeaponSlots.Count)
        {
            return m_WeaponSlots[index];
        }
        return null;
    }
}
