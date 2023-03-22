using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineSpawner : MonoBehaviour
{

    public GameObject[] Collectables;

    private int[] spawn_set = {
        223, 246, 270
        };

    public int[] spawned_object_type_num;

    public float[] time_line;

    public int[] spawn_on_line;

    private int time_track_counter = 0;

    private float time_tracker = 0;

    public float show_time_tracker = 0; //this is here for people to come pare the times

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_counter();

        if(time_track_counter < time_line.Length)
        {

            Time_line_tracker();
        }

        show_time_tracker = time_tracker; // delette this whe final comes
    }

    void time_counter()
    {
        time_tracker = time_tracker + (Time.deltaTime);
    }

    void Time_line_tracker()
    {
        if(time_tracker >= time_line[time_track_counter])
        {
            spawn_object();
            time_track_counter = time_track_counter + 1;
        }
    }

    void spawn_object()
    {
        Instantiate(Collectables[spawned_object_type_num[time_track_counter]], transform.TransformPoint(700, spawn_set[spawn_on_line[time_track_counter] - 1], -600), new Quaternion(0, 0, 0, 0));
    }



    

}
