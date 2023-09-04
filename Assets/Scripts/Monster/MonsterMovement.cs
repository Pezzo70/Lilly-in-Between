using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public Transform[] points;

    public float speed;
    public GameObject TextPanel;
    private GameObject _player;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        this.transform.position = points[Random.Range(0, points.Length - 1)].position;
    }

    void Update()
    {
        if (TextPanel.activeInHierarchy) return;
        transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, speed * Time.deltaTime);
    }


    public void SetPositionToRandomPoint()
    {
        this.transform.position = points[Random.Range(0, points.Length - 1)].position;
    }
}
