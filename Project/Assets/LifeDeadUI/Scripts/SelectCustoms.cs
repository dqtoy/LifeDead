using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class SelectCustoms : MonoBehaviour
{
    #region 字段
    /// <summary>
    /// 关卡图片数组
    /// </summary>
    private Image[] imageArray;
    /// <summary>
    /// 左右点击按钮
    /// </summary>
    private Button m_buttonRight;
    private Button m_buttonLeft;
    /// <summary>
    /// 管卡名字数组
    /// </summary>
    private string[] m_levelName;
    /// <summary>
    /// 选择关卡数组
    /// </summary>
    private Button[] m_switchButton;
    /// <summary>
    /// 初始位置
    /// </summary>
    private RectTransform LeftPos;
    private RectTransform RightPos;
    private RectTransform CenterPos;

    private int index;
    public int m_levelSum;
    /// <summary>
    /// 读取数据
    /// </summary>
    DataController m_dataController;

    // 解锁关卡数量
    int m_levelCurrentCount;
    /// <summary>
    /// 锁子图片
    /// </summary>
    private Image m_lockImage;
    #endregion

    void Awake()
    {
        // 获取更新数据
        m_dataController = DataController.GetDataInstance();
        m_dataController.LoadJsonData();
        m_levelCurrentCount = m_dataController.GetlevelCurrent();

        m_levelName = new string[m_levelSum];
        imageArray = new Image[m_levelSum];
        m_switchButton = new Button[m_levelSum];

        index = 0;

        SetLevleName();
    }

    void Start()
    {
        // 位置初始化
        LeftPos = GameObject.Find("LeftPos").GetComponent<RectTransform>();
        RightPos = GameObject.Find("RightPos").GetComponent<RectTransform>();
        CenterPos = GameObject.Find("CenterPos").GetComponent<RectTransform>();

        #region 点击事件注册
        m_buttonRight = GameObject.Find("ButtonRight").GetComponent<Button>();
        m_buttonRight.onClick.AddListener(RightButtonAction);

        m_buttonLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        m_buttonLeft.onClick.AddListener(LeftButtonAction);
        #endregion

        #region 遍历关卡数量，注册关卡点击事件
        for (int i = 0; i < m_levelSum; i++)
        {
            imageArray[i] = GameObject.Find("customs" + i).GetComponent<Image>();
            m_switchButton[i] = GameObject.Find("customs" + i).GetComponent<Button>();
            if (i <= m_levelCurrentCount)
            {
                m_lockImage = imageArray[i].GetComponentsInChildren<Image>()[1];
                m_lockImage.gameObject.SetActive(false);
                m_switchButton[i].onClick.AddListener(SwitchLevel);
            }
        }
        imageArray[0].rectTransform.position = CenterPos.position;
        #endregion
    }

    /// <summary>
    /// 向右点击事件
    /// </summary>
    public void RightButtonAction()
    {
        if (index < 1)
        {
            return;
        }

        index--;
        
        Tweener CenterMoveRight = imageArray[index + 1].rectTransform.DOMove(RightPos.position, 0.5f);
        Tweener LeftMoveCenter = imageArray[index].rectTransform.DOMove(CenterPos.position, 0.5f);
    }

    /// <summary>
    /// 向左点击事件
    /// </summary>
    public void LeftButtonAction()
    {
        if (index > imageArray.Length - 2)
        {
            return;
        }

        index++;

        Tweener CenterMoveLeft = imageArray[index - 1].rectTransform.DOMove(LeftPos.position, 0.5f);
        Tweener RightMoveCenter = imageArray[index].rectTransform.DOMove(CenterPos.position, 0.5f);
    }

    /// <summary>
    /// 切换关卡
    /// </summary>
    public void SwitchLevel()
    {
        PlayerPrefs.SetString("CurrentLevel", m_levelName[index]);

        //if (index == 0)
        //{
        //    SceneManager.LoadScene("Level01Animation");
        //}
        //else
        //{
            SceneManager.LoadScene(2);
        //}
    }

    /// <summary>
    /// 设置关卡名称
    /// </summary>
    void SetLevleName()
    {
        //m_levelName[0] = "Level01Animation";
        m_levelName[0] = "Mission1";
        m_levelName[1] = "Mission2";
        m_levelName[2] = "Mission3";
        m_levelName[3] = "Mission4";
        m_levelName[4] = "Mission5";
        m_levelName[5] = "Mission6";
        m_levelName[6] = "Mission7";
        m_levelName[7] = "Mission8";
        m_levelName[8] = "Mission9";
        m_levelName[9] = "Mission10";
    }

}
