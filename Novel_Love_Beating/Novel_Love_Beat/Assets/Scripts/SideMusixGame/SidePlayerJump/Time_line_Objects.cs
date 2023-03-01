using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_line_Objects : MonoBehaviour
{
    public float speed = 4;


    // Update is called once per frame
    void Update()
    {
        Move_Left();
        out_of_bounds();
    }

    void Move_Left()
    {
        this.transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void out_of_bounds()
    {
        if (this.transform.position.x < 400)
        {
            destory_this();
        }
    }

    public void destory_this()
    {

        Destroy(this.gameObject);

    }
}
