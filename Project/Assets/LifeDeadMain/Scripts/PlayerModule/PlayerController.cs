//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region 字段

    // 按键参数
    private float m_hor;  
      
    // Player预设体
    public GameObject m_PlayerPrefab;

    // Player出生位置
    public Vector3 m_playerStartPos;

    // Player出生角度
    public Quaternion m_playerStartRotation;

    // Player在游戏中的引用
    private GameObject m_player;

    // Player的脚本
    private PlayerBase m_playerScript;

    // 创建角色的名称
    private string m_playerName;

    #endregion

    #region Unity回调

    void Awake()
    {                          
        // 从上一场景中获取关卡角色数据
        GetUIData();

        // 加载Player资源
        LoadResourcesPlayer(m_playerName);

        // 设置Player出生位置
        m_playerStartPos = GameObject.Find("PlayerStartPos").transform.position;

        // 设置Player出生角度
        m_playerStartRotation = new Quaternion(0, 0.7f, 0, 0.7f);

        // 创建Player
        CreatePlayer();
        
                 
    }

	void Start ()
    {
        // 获取脚本组件
        m_playerScript = m_player.GetComponent<PlayerBase>();       
    }
	
	
	void Update ()
    {

        // 监听Player的动画
        m_hor = Input.GetAxis("Horizontal");

        if(m_hor>0)
        {
            m_playerScript.PlayerMove(m_hor);
            m_playerScript.RotateRight();
        }
        else if(m_hor<0)
        {
            m_playerScript.PlayerMove(-m_hor);
            m_playerScript.RotateLeft();
        }
        else
        {
            m_playerScript.PlayerMove(m_hor);
        }
        
              
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_playerScript.PlayerJump();
        }
    }

    #endregion

    #region 其他方法

    /// <summary>
    /// 从UI层中读取加载场景数据
    /// </summary>
    void GetUIData()
    {
        m_playerName = PlayerPrefs.GetString("name");
    }

    /// <summary>
    /// 加载Resources中角色
    /// </summary>
    void LoadResourcesPlayer(string name)
    {
        m_PlayerPrefab = Resources.Load<GameObject>(name);
    }

    /// <summary>
    /// 创建对应的角色
    /// </summary>
    void CreatePlayer()
    {
        m_player = Instantiate(m_PlayerPrefab, m_playerStartPos, new Quaternion(0, 0.7f, 0, 0.7f)) as GameObject;
    }

    #endregion  
}


