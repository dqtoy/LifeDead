using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    private Slider m_timeSlider;

    void Start ()
    {
        m_timeSlider = GameObject.FindWithTag("TimeSlider").GetComponent<Slider>();
    }
	

    public void SetTime(float time)
    {
        m_timeSlider.value = time;
    }

}
