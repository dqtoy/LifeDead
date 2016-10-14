using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    private Slider m_timeSlider;
    /// <summary>
    /// 沙漏
    /// </summary>
    private RectTransform m_hourglassImage;


    void Awake()
    {
        m_timeSlider = GetComponent<Slider>();
    }

    void Start ()
    {
        m_hourglassImage = this.transform.FindChild("HourGlass").GetComponent<RectTransform>();
    }
	
    public Slider GetTimeSlider()
    {
        return m_timeSlider;
    }
    void Update()
    {
        m_hourglassImage.transform.Rotate(new Vector3(0,0, 1),Space.Self);
    }
    public void SetTime(float time)
    {
        m_timeSlider.value = time;
    }
 
}
