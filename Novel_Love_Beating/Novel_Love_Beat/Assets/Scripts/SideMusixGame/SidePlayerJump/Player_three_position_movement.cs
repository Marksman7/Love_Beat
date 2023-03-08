using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_three_position_movement : MonoBehaviour
{


    private float[] move_set = {
        223, 246, 270
        };

    public float speed = 6;

    public bool in_motion = false;

    public float stay_on_target;

    // Start is called before the first frame update
    void Start()
    {
        stay_on_target = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(in_motion == true)
        {
            find_target_move();
            stop_moving();
            //Debug.Log("check");
        }
        else
        {
            move_actions();
        }
    }
    
    private void move_actions()
    {
        if(Input.GetKeyDown(KeyCode.Q) && this.gameObject.transform.position.y < move_set[2])
        {
            stay_on_target = move_set[2];
            in_motion = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && this.gameObject.transform.position.y != move_set[1])
        {
            stay_on_target = move_set[1];
            in_motion = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && this.gameObject.transform.position.y > move_set[0])
        {
            stay_on_target = move_set[0];
            in_motion = true;
        }
    }
    
    private void find_target_move()
    {
        if((stay_on_target + 1) > this.gameObject.transform.position.y && stay_on_target != move_set[0])
        {
            move_up();
        }
        else if((stay_on_target - 1) < this.gameObject.transform.position.y && stay_on_target != move_set[2])
        {
            move_down();
        }
    }

    private void move_up()
    {
        this.transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void move_down()
    {
        this.transform.Translate(0, -speed * Time.deltaTime, 0);
    }

    private void stop_moving()
    {
        if (move_set[0] == stay_on_target)
        {
            if(move_set[0] > this.gameObject.transform.position.y)
            {

                in_motion = false;
            }
        }
        else if (move_set[1] == stay_on_target)
        {
            if ((move_set[1] - 1) < this.gameObject.transform.position.y && (move_set[1] + 1)> this.gameObject.transform.position.y)
            {
                in_motion = false;
            }
        }
        else if (move_set[2] == stay_on_target)
        {
            if (move_set[2] < this.gameObject.transform.position.y)
            {
                
                in_motion = false;
            }
        }
    }
}
