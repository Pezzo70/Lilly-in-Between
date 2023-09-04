using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovementMaze : MonoBehaviour
{

    public float speed;
    public Transform[] points;
    private bool goToA = true;


    void Update()
    {
        if (goToA)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, points[0].position, speed * Time.deltaTime);
            if (this.transform.position == points[0].position)
                goToA = false;
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, points[1].position, speed * Time.deltaTime);
            if (this.transform.position == points[1].position)
                goToA = true;
        }
    }
}
