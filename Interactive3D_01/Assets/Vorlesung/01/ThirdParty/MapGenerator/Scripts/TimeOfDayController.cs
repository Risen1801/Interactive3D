using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeOfDayController : MonoBehaviour
{

    public Light sunLight;
    public Light moonLight;
    public Text dayTimeLabel;
    public float simulationSpeed = 1;
    private float dayProgress;

    private void Update()
    {
        dayProgress += simulationSpeed / 24 * Time.deltaTime;

        if (dayProgress > 1)
        {
            dayProgress = 0;
        }

        UpdateDayTime(dayProgress);

    }

    public void UpdateDayTime(float dayProgress)
    {
        float sunRotation = Mathf.Lerp(-90, 270, dayProgress);
        sunLight.transform.rotation = Quaternion.Euler(sunRotation, 280, 0);

        float moonRotation = sunRotation - 180;
        moonLight.transform.rotation = Quaternion.Euler(moonRotation, 280, 0);

        if (sunLight.transform.eulerAngles.x > 0 && sunLight.transform.eulerAngles.x < 180)
        {
            SwitchToNightSetting(false);
        }
        else 
        {
            SwitchToNightSetting(true);
        }

        UpdateTimeLabel(dayProgress);
    }

    private void UpdateTimeLabel(float dayProgress)
    {
        TimeSpan time = TimeSpan.FromSeconds(dayProgress * 60 * 60 * 24);
        dayTimeLabel.text = time.ToString("hh':'mm");
    }

    private void SwitchToNightSetting(bool isNight)
    {
        if (isNight) 
        {
            sunLight.shadows = LightShadows.None;
            moonLight.shadows = LightShadows.Soft;
        }
        else
        {
            sunLight.shadows = LightShadows.Soft;
            moonLight.shadows = LightShadows.None;
        }
    }

}
