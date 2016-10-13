using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class SelectPlayer : MonoBehaviour
{
    #region 字段
    /// <summary>
    /// 向上按钮
    /// </summary>
    private Button m_upButton;
    /// <summary>
    /// 向下按钮
    /// </summary>
    private Button m_downButton;
    /// <summary>
    /// 开始按钮
    /// </summary>
    private Button m_startButton;
    /// <summary>
    /// 后退按钮
    /// </summary>
    private Button m_escButton;
    /// <summary>
    /// 人物介绍文本
    /// </summary>
    private Text m_introText;
    /// <summary>
    /// 存放玩家数组
    /// </summary>
    private GameObject[] m_Players;
    /// <summary>
    /// 存放玩家位置
    /// </summary>
    private Vector2 UpPos = new Vector2(-0.5f, 10);
    private Vector2 DownPos = new Vector2(-0.5f, -10);
    private Vector2 CenterPos = new Vector2(-0.5f, 0);
    /// <summary>
    /// 玩家下标
    /// </summary>
    private int index;
    /// <summary>
    /// 玩家路径
    /// </summary>
    private string KnightPath = "Knight";
    private string NinjaPath = "Ninja";
    private string GirlPath = "Girl";
    private string MummyPath = "Mummy";
    private string WizardPath = "Wizard";
    private string EyeMonterPath = "EyeMonter";
   /// <summary>
  /// 玩家朝向点
  /// </summary>
    private Transform m_lookAtPoint;
    /// <summary>
    /// 读取数据
    /// </summary>
    DataController m_dataController;
    /// <summary>
    /// 玩家锁
    /// </summary>
    private Image m_lockImage;
    /// <summary>
    /// 解锁人物数量
    /// </summary>
    int m_unLockPlayerCount;
    /// <summary>
    /// 人物介绍数组
    /// </summary>
    string[] m_introString=new string[6];
    /// <summary>
    /// 选择人物背景面板
    /// </summary>
    private Image m_changePanel;
    #endregion

    #region Unity回调
    void Awake()
    {
        // 获取更新数据
        m_dataController = DataController.GetDataInstance();
        m_dataController.LoadJsonData();
        m_unLockPlayerCount = m_dataController.GetUnLockPlayer();

        index = 0;
  
    }
    void Start()
    {
        m_introText = GameObject.Find("IntroText").GetComponent<Text>();
        m_introText.text = m_introString[0];
        m_lookAtPoint = GameObject.Find("LookAtPoint").GetComponent<Transform>();

        #region 初始化玩家
        m_Players = new GameObject[6];
        #region 加载玩家，移除刚体
        Object KnightPrefab = Resources.Load(KnightPath, typeof(GameObject));
        GameObject Knight = Instantiate(KnightPrefab) as GameObject;
        Knight.transform.rotation = m_lookAtPoint.rotation;
        Destroy(Knight.GetComponent<Rigidbody>());

        Object NinjaPrefab = Resources.Load(NinjaPath, typeof(GameObject));
        GameObject Ninja = Instantiate(NinjaPrefab) as GameObject;
        Ninja.transform.rotation = m_lookAtPoint.rotation;
        Destroy(Ninja.GetComponent<Rigidbody>());

        Object GirlPrefab = Resources.Load(GirlPath, typeof(GameObject));
        GameObject Girl = Instantiate(GirlPrefab) as GameObject;
        Girl.transform.rotation = m_lookAtPoint.rotation;
        Destroy(Girl.GetComponent<Rigidbody>());

        Object MummyPrefab = Resources.Load(MummyPath, typeof(GameObject));
        GameObject Mummy = Instantiate(MummyPrefab) as GameObject;
        Mummy.transform.rotation = m_lookAtPoint.rotation;
        Destroy(Mummy.GetComponent<Rigidbody>());

        Object WizardPrefab = Resources.Load(WizardPath, typeof(GameObject));
        GameObject Wizard = Instantiate(WizardPrefab) as GameObject;
        Wizard.transform.rotation = m_lookAtPoint.rotation;
        Destroy(Wizard.GetComponent<Rigidbody>());

        Object EyeMonterPrefab = Resources.Load(EyeMonterPath, typeof(GameObject));
        GameObject EyeMonter = Instantiate(EyeMonterPrefab) as GameObject;
        EyeMonter.transform.rotation = m_lookAtPoint.rotation;
        Destroy(EyeMonter.GetComponent<Rigidbody>());
        #endregion
    
        m_Players[0] = Girl;
        m_Players[1] = EyeMonter;
        m_Players[2] = Mummy;
        m_Players[3] = Knight;
        m_Players[4] = Ninja;
        m_Players[5] = Wizard;
        #endregion

        m_changePanel = GameObject.Find("ChangePanel").GetComponent<Image>();
        m_lockImage = GameObject.Find("Lock").GetComponent<Image>();
        // 初始化人物介绍
        for (int i = 0; i < m_introString.Length; i++)
        {
            m_introString[0] = "我是小女孩，没什么特别的";
            m_introString[1] = "我是独眼怪，可以发射射线";
            m_introString[2] = "我是木乃伊，我只有两条命";
            m_introString[3] = "我是雇佣兵，";
            m_introString[4] = "我是忍者，我有两段跳";
            m_introString[5] = "我是巫师，我会飞";   
        }
      
        #region Button按钮注册事件
        m_upButton = GameObject.Find("TurnLeftButton").GetComponent<Button>();
        m_upButton.onClick.AddListener(UpButtonAction);

        m_downButton = GameObject.Find("TurnRightButton").GetComponent<Button>();
        m_downButton.onClick.AddListener(DownButtonAction);

        m_startButton = GameObject.Find("StartButton").GetComponent<Button>();
        m_startButton.onClick.AddListener(StartButtonAction);


        m_escButton = GameObject.Find("EscButton").GetComponent<Button>();
        m_escButton.onClick.AddListener(EscButtonAction);
        #endregion
    
        // 初始化玩家位置
        for (int i = 1; i < m_Players.Length; i++)
        {
            m_Players[i].transform.position = UpPos;
        }
        m_Players[0].transform.position = CenterPos;
    }
    void Update()
    {
        GetPlayerName(index);
        SetPlayerState();
    }
    #endregion

    /// <summary>
    /// 上键点击事件
    /// </summary>
    public void UpButtonAction()
    {
        if (index < 1)
        {
            return;
        }

        index--;

        Tweener CenterMoveRight = m_Players[index + 1].transform.DOMove(UpPos, 0.5f);
        Tweener LeftMoveCenter = m_Players[index].transform.DOMove(CenterPos, 0.5f);
    }

    /// <summary>
    /// 下键点击事件
    /// </summary>
    public void DownButtonAction()
    {
        if (index > m_Players.Length - 2)
        {
            return;
        }

        index++;

        Tweener CenterMoveLeft = m_Players[index - 1].transform.DOMove(DownPos, 0.5f);

        Tweener RightMoveCenter = m_Players[index].transform.DOMove(CenterPos, 0.5f);
    }

    /// <summary>
    /// 开始按钮点击事件
    /// </summary>
    public void StartButtonAction()
    {
        PlayerPrefs.SetString("PlayerName", GetPlayerName(index));
        if (index <= m_unLockPlayerCount)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
        }
    }
    /// <summary>
    /// 后退按钮点击事件
    /// </summary>
    public void EscButtonAction()
    {
        SceneManager.LoadScene("SelectCustoms");
    }

    /// <summary>
    /// 获取玩家名字
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public string GetPlayerName(int index)
    {
        switch (index)
        {
            case 0:
                m_introText.text = m_introString[0];
                return "Girl";
            case 1:
                m_introText.text = m_introString[1];
                return "EyeMonter";
            case 2:
                m_introText.text = m_introString[2];
                return "Mummy";
            case 3:
                m_introText.text = m_introString[3];
                return "Knight";
            case 4:
                m_introText.text = m_introString[4];
                return "Ninja";
            case 5:
                m_introText.text = m_introString[5];
                return "Wizard";
        }
        return null;
    }
    /// <summary>
    /// 设置玩家背景状态
    /// </summary>
    public void SetPlayerState()
    {
        if (index <= m_unLockPlayerCount)
        {
            m_lockImage.gameObject.SetActive(false);
            m_changePanel.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            m_lockImage.gameObject.SetActive(true);
            m_changePanel.color = new Color32(170, 170, 170, 170);
        }
    }

}
