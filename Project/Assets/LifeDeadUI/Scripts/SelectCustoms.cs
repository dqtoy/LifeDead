using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class SelectCustoms : MonoBehaviour
{
    private Image[] imageArray;

    private Button m_buttonRight;
    private Button m_buttonLeft;

    private string[] m_levelName;

    private  Vector3 LeftPos=new Vector2(-300,300);
    private Vector3 RightPos=new Vector2(1000,300);
    private Vector3 CenterPos=new Vector2(360,300);
   private int index;
   public  int m_levelSum;

    private Button[] m_switchButton;
    #region 初始化
    void InitImageArray()
    {
        imageArray[0].transform.position = CenterPos;

        for (int i = 1; i < 11; i++)
        {
            imageArray[i].rectTransform.position = RightPos;
        }
    }
    #endregion
    void Awake()
    {
        m_levelName = new string[m_levelSum];

        imageArray = new Image[m_levelSum];
        m_switchButton = new Button[m_levelSum];
        for (int i = 0; i < m_levelSum;i++)
        {
            imageArray[i]= GameObject.Find("customs"+i).GetComponent<Image>();
            m_switchButton[i]=GameObject.Find("customs" + i).GetComponent<Button>();
            m_switchButton[i].onClick.AddListener(SwitchLevel);
        }

        index = 0;
        InitImageArray();
        SetLevleName();
        #region 点击事件注册
        m_buttonRight = GameObject.Find("ButtonRight").GetComponent<Button>();
        m_buttonRight.onClick.AddListener(RightButtonAction);
        m_buttonLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        m_buttonLeft.onClick.AddListener(LeftButtonAction);
        #endregion

    }
    #region 向右点击事件
    public void RightButtonAction()
    {
        if (index < 1)
        {
            return;
        }

        index--;

        Tweener CenterMoveRight = imageArray[index + 1].transform.DOMove(RightPos, 0.5f);
        Tweener LeftMoveCenter = imageArray[index].transform.DOMove(CenterPos, 0.5f);
    }
    #endregion
    #region 向左点击事件
    public void LeftButtonAction()
    {
        if (index > imageArray.Length - 2)
        {
            return;
        }

        index++;

        Tweener CenterMoveLeft = imageArray[index - 1].transform.DOMove(LeftPos, 0.5f);

        Tweener RightMoveCenter = imageArray[index].transform.DOMove(CenterPos, 0.5f);
    }
    #endregion
    #region 切换关卡
    public void SwitchLevel()
    {
        PlayerPrefs.SetString("CurrentLevel", m_levelName[index]);
        SceneManager.LoadScene(2);
        //print(index);
    }
    #endregion
    #region 设置关卡名称
    void SetLevleName()
    {
        m_levelName[0] = "Level01Animation";
        m_levelName[1] = "Mission1";
        m_levelName[2] = "Mission2";
        m_levelName[3] = "Mission3";
        m_levelName[4] = "Mission4";
        m_levelName[4] = "Mission5";
        m_levelName[6] = "Mission6";
        m_levelName[7] = "Mission7";
        m_levelName[8] = "Mission8";
        m_levelName[9] = "Mission9";
        m_levelName[10] = "Mission10";
    }
    #endregion

}
