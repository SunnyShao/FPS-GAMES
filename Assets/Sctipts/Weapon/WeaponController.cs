using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Tooltip("武器的父节点，用来控制显隐武器")]
    public GameObject WeaponRoot;

    //武器的持有玩家
    public GameObject owner;

    //武器本身   我一直觉得可以直接用  .gameobject代替的东西  后续测试下 TODO
    public GameObject sourcePerfab;

    //枪口特效
    public GameObject muzzleParticle;

    //枪口特效父节点
    public Transform muzzleTrans;

    //两次射击时间间隔
    private float weaponShotsInterval = 0.1f;

    //上次射击时间
    private float lastShootTime = -1;

    //武器显隐
    public void ShowWeapon(bool isShow)
    {
        WeaponRoot.SetActive(isShow);
        //是否显隐的标志位暂时不写   作用不明确
    }
      

    //攻击输入
    public void HandleShootInputs(bool inputHold)
    {
        if(inputHold)
        {
            TryShoot();
        }
    }

    //射击
    private void TryShoot()
    {
        if (lastShootTime + weaponShotsInterval < Time.time) //间隔一段时间发射子弹
        {
            HandleShoot();
            lastShootTime = Time.time;
        }
    }

    //射击反馈
    private void HandleShoot()
    {
        if(muzzleParticle)
        {
            GameObject shotParticle =  Instantiate(muzzleParticle, muzzleTrans);
            Destroy(shotParticle, 2f);
        }
    }


}
