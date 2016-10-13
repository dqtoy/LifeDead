//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour
{
	#region 字段
	// 移动速度
	protected float m_speed = 3;
   
    // 刚体组件
    private Rigidbody m_rig;

    // 动画组件
    protected Animator m_ant;

    // 是否正在跳

    protected bool m_isJump;

    // 方向
    protected int m_direction;   

    #endregion

    #region Unity回调
    void Awake()
    {       
        m_rig = GetComponent<Rigidbody>();
        m_ant = GetComponent<Animator>();
    }

    void Start()
    {
        m_isJump = false;
        m_direction = 1;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Down"))
        {
            m_isJump = false;           
            m_ant.SetBool("ant_drop", false);
        }

        if (other.gameObject.tag.Equals("Left"))
        {
            m_isJump = false;         
            m_ant.SetBool("ant_drop", false);
        }

        if (other.gameObject.tag.Equals("Right"))
        {
            m_isJump = false;           
            m_ant.SetBool("ant_drop", false);
        }

        if (other.gameObject.tag.Equals("Up"))
        {          
            m_isJump = true;          
            m_ant.SetBool("ant_drop", false);
        }
    }

    void OnCollisionStay(Collision other)
    {      
        if (other.gameObject.tag.Equals("Up"))
        {           
            m_isJump = true;
            m_ant.SetBool("ant_drop", false);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag.Equals("Up"))
        {          
            m_isJump = false;          
            m_ant.SetBool("ant_drop", false);
        }
    }

    #endregion

    #region 通用方法

    /// <summary>
    /// 移动
    /// </summary>
    /// <param name="hor"></param>
    public void PlayerMove(float hor)
    {       
        m_ant.SetFloat("ant_speed", m_speed * hor);
        transform.position += transform.forward * hor * m_speed * Time.deltaTime;        
    }

    /// <summary>
    /// 向右转身
    /// </summary>
    public void RotateRight()
    {

        // 向右转向  
        // 设置Player的旋转角度为0

        transform.rotation = new Quaternion(0,0.7f,0,0.7f);
        m_direction = 1;
        //Quaternion.AngleAxis();                                                  
    }

    /// <summary>
    /// 向左转身
    /// </summary>
    public void RotateLeft()
    {
        // 向左转向
        // 设置Player的旋转角度为180
        transform.rotation = new Quaternion(0, 0.7f, 0, -0.7f);
        m_direction = -1;
    }

	/// <summary>
	/// Playr死亡
	/// </summary>
	public void PlayerDead()
	{
		print ("Player死亡");
	}

    #endregion

	#region 虚方法

	/// <summary>
	/// 跳跃
	/// </summary>
	public virtual void PlayerJump ()
	{

		if (m_isJump) {
			m_ant.SetBool ("ant_drop", true);	
			m_rig.velocity = Vector3.zero;
			m_rig.velocity += transform.up * 7;
			m_isJump = false;
		}        
	}


	/// <summary>
	/// 长者隐身
	/// </summary>
	public virtual void Hide ()
	{

	}

	/// <summary>
	/// 武士扔飞刀
	/// </summary>
	public virtual void FlyKnife ()
	{

	}

	/// <summary>
	/// 独眼怪发激光
	/// </summary>
	public virtual void ShootLase ()
	{

	}

	/// <summary>
	/// 木乃伊复活
	/// </summary>
	public virtual void Rebirth ()
	{

	}

	#endregion
}





