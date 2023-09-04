using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public bool Enabled { get => this.gameObject.activeSelf; set => this.gameObject.SetActive(value); }

    private GameObject timer;
    public Coroutine coroutine;

    public float phaseTime;
    public float currentTime;
    public bool isTimerActive;

    private TextMeshProUGUI textMesh;

    public Death death;

    void Start()
    {
        currentTime = phaseTime;
        timer = this.transform.parent.gameObject;
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled && isTimerActive)
        {
            currentTime -= Time.deltaTime;
            textMesh.text = Math.Round(currentTime).ToString() + " seg";
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            EventManager.ChangeScene.Invoke(null);
        }

        int time = (int)Math.Round(currentTime);

        if (time == 90 || time == 45 || time == 20)
        {
            death.Trigger();
        }
    }

    public void StartTimer() => isTimerActive = true;


    public void StopTimer() => isTimerActive = false;


    public void ResetTimer() => currentTime = phaseTime;

}
