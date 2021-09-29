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

    //武器显隐
    public void ShowWeapon(bool isShow)
    {
        WeaponRoot.SetActive(isShow);
        //是否显隐的标志位暂时不写   作用不明确
    }
      
}
