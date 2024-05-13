using System;
using UnityEngine;
using TMPro;

public class CameraStopwatch : MonoBehaviour
{
    private float currentTime;
    public TextMeshProUGUI currentTimeText;

    private void Update()
    {
        currentTime += Time.deltaTime;
        UpdateTimeUI(currentTime);
    }

    private void UpdateTimeUI(float timeInSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);
        currentTimeText.text = $"{time.Minutes:00}:{time.Seconds:00}.{time.Milliseconds:000}";
    }
}
