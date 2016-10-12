//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class EyeMonsterScript : PlayerBase
{
    // 线条组件
    LineRenderer EyeLine;

    // 攻击射线
    Ray shootRay;

    // 眼睛位置对象
    Transform EyePosTransform;

    // 射线碰撞器
    RaycastHit shootHit;

    // 碰撞层
    int shootMask;

    // 范围
    float range;

    // 计时器
    float Timer;
    float sumTimer;

    void Start ()
    {
        EyeLine = transform.GetComponent<LineRenderer>();
        EyePosTransform = transform.FindChild("EyePos");
        shootMask = LayerMask.GetMask("Stuff");

        range = 10;
        Timer = 0;
        sumTimer = 0.02f;
    }
	
	
	void Update ()
    {
        Timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && Timer >= sumTimer)
        {
            //开始射击           
            this.ShootLase();
        }

        if (Timer > sumTimer)
        {
            EyeLine.enabled = false;
        }
    }

    /// <summary>
    /// 重写父类方法 实现独眼怪发射激光的功能
    /// </summary>   
    public override void ShootLase()
    {
        //base.ShootLase();

        Timer = 0;

        //画线
        EyeLine.enabled = true;

        EyeLine.SetPosition(0, EyePosTransform.position);

        shootRay.origin = EyePosTransform.position;
        
        shootRay.direction = new Vector3(this.m_direction * 0.8f, -0.5f,0); 

    
        if (Physics.Raycast(shootRay, out shootHit, range, shootMask))
        {
            EyeLine.SetPosition(1, shootHit.point);

            GameObject obj = shootHit.collider.gameObject;
            if (obj.tag == "Monster")
            {
                print("射中了怪物");
            }
        }
        else
        {
            EyeLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
