using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class SelectPlayer : MonoBehaviour
{
    private Button m_upButton;
    private Button m_downButton;
    private Button m_startButton;

    private Text m_introText;

    public GameObject[] m_Players;
    private Vector2 UpPos = new Vector2(-0.5f, 10);
    private Vector2 DownPos = new Vector2(-0.5f, -10);
    private Vector2 CenterPos = new Vector2(-0.5f, 0);
    private int index;
    #region 初始化
    void Init()
    {
        m_Players[0].transform.position = CenterPos;
        for (int i = 1; i < m_Players.Length; i++)
        {
            m_Players[i].transform.position = UpPos;
        }
    }
    #endregion

    void Awake()
    {
        #region Button按钮注册事件
        m_upButton = GameObject.Find("TurnLeftButton").GetComponent<Button>();
        m_upButton.onClick.AddListener(UpButtonAction);

        m_downButton = GameObject.Find("TurnRightButton").GetComponent<Button>();
        m_downButton.onClick.AddListener(DownButtonAction);

        m_startButton = GameObject.Find("StartButton").GetComponent<Button>();
        m_startButton.onClick.AddListener(StartButtonAction);
        #endregion
        m_introText = GameObject.Find("IntroText").GetComponent<Text>();

        m_Players = new GameObject[m_Players.Length];
       
        for (int i = 0; i < m_Players.Length; i++)
        {
            m_Players[0] = GameObject.Find("Alien");
            m_Players[1] = GameObject.Find("Knight");
            m_Players[2] = GameObject.Find("Ninja");
            m_Players[3] = GameObject.Find("Girl");
            m_Players[4] = GameObject.Find("Mummy");
            m_Players[5] = GameObject.Find("Wizard");
            m_Players[6] = GameObject.Find("EyeMonter");
        }
        index = 0;
        Init();
    }

    #region 左键点击事件
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
    #endregion
    #region 右键点击事件
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
    #endregion
    #region 开始按钮点击事件
    public void StartButtonAction()
    {
        PlayerPrefs.SetString("PlayerName", GetPlayerName(index));

        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
    }
    #endregion
    #region 获取玩家名字
    public string GetPlayerName(int index)
    {
        switch (index)
        {
            case 0:
                return "Alien";
            case 1:
                return "Knight";
            case 2:
                return "Ninja";
            case 3:
                return "Girl";
            case 4:
                return "Mummy";
            case 5:
                return "Wizard";
            case 6:
                return "EyeMonter";
        }
        return null;
    }
    #endregion

}
