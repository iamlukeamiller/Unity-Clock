using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{

    // Set the standardized degrees per unity of time on the clock face
    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6f;
    const float degreesPerSecond = 6f;

    // Allow for each clock arm to be set
    public Transform hoursTransform, minutesTransform, secondsTransform;

    // Choose whether clock should operate in continuous or discrete mode
    public static bool continuous;
    public GameObject continuousToggle;

    void Awake() {

        // Set the time immediately on Awake() so the clock starts up at the current time
        DateTime time = DateTime.Now;

        hoursTransform.localRotation = Quaternion.Euler(0, time.Hour * degreesPerHour, 0);
        minutesTransform.localRotation = Quaternion.Euler(0, time.Minute * degreesPerMinute, 0);
        secondsTransform.localRotation = Quaternion.Euler(0, time.Second * degreesPerSecond, 0);

        // Get the toggle GameObject to allow it to set the continuous bool
        continuousToggle = GameObject.Find("Continuous Toggle");
    }

    private void Update() {

        // Set the continuous bool based on the current value of the toggle
        continuous = continuousToggle.GetComponent<Toggle>().isOn;

        // Determine if continuous or discrete mode should be used
        if (continuous) {
            UpdateContinuous();
        } else {
            UpdateDiscrete();
        }
    }

    // Method to set time in continuous mode using DateTime.Now.TimeOfDay
    void UpdateContinuous() {
        TimeSpan time = DateTime.Now.TimeOfDay;

        hoursTransform.localRotation = Quaternion.Euler(0, (float)time.TotalHours * degreesPerHour, 0);

        minutesTransform.localRotation = Quaternion.Euler(0, (float)time.TotalMinutes * degreesPerMinute, 0);

        secondsTransform.localRotation = Quaternion.Euler(0, (float)time.TotalSeconds * degreesPerSecond, 0);
    }

    // Method to set time in discrete mode using DateTime.Now
    void UpdateDiscrete() {
        DateTime time = DateTime.Now;

        hoursTransform.localRotation = Quaternion.Euler(0, time.Hour * degreesPerHour, 0);

        minutesTransform.localRotation = Quaternion.Euler(0, time.Minute * degreesPerMinute, 0);

        secondsTransform.localRotation = Quaternion.Euler(0, time.Second * degreesPerSecond, 0);
    }
}
