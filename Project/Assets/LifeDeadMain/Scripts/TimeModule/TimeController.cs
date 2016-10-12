//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    // 总时间
    public float m_totalTime;
    // 时间显示器UI

    private GameObject m_timeUI;
    private Slider m_timeSlider;
    private TimeSlider m_timeSliderScript;

    // 当前时间
    public float m_currentTime;

    // 剩余时间
    float m_surplusTime;

    void Awake()
    {
        m_timeUI = GameObject.FindWithTag("TimeSlider");

        m_timeSliderScript = m_timeUI.GetComponent<TimeSlider>();        
    }

    void Start()
    {
        m_timeSlider = m_timeSliderScript.GetTimeSlider();
        m_timeSlider.maxValue = m_totalTime;
        m_timeSlider.minValue = 0;
        m_currentTime = 0f;
    }


    void Update()
    {
        m_currentTime += Time.deltaTime;

        m_surplusTime = m_totalTime - m_currentTime;

        m_timeSliderScript.SetTime(m_surplusTime);
    }
}
