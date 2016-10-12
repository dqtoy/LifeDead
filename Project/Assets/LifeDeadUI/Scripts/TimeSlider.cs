using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    private Slider m_timeSlider;

    void Awake()
    {
        m_timeSlider = GetComponent<Slider>();
    }

    void Start ()
    {
        
    }
	
    public Slider GetTimeSlider()
    {
        return m_timeSlider;
    }

    public void SetTime(float time)
    {
        m_timeSlider.value = time;
    }

}
