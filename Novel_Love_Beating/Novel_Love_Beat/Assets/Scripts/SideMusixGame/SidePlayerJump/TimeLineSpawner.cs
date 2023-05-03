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

    private AudioSource audio_source;

    public float wait_to_start_music = 4.0f;

    // Start is called before the first frame update
    void Start()
    {

        if(GetComponent<AudioSource>() != null)
        {
            audio_source = GetComponent<AudioSource>();
            Invoke("Play_and_loop", wait_to_start_music);
        }
        else
        {
            Debug.Log("Does not have anything in the debug output");
        }
    }

    void Play_and_loop()
    {
        audio_source.Play();
        audio_source.loop = true;
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
        if (spawn_on_line.Length > time_track_counter && time_line.Length > time_track_counter && spawned_object_type_num.Length > time_track_counter)
        {
            Debug.Log(spawn_on_line[time_track_counter] + " = " + spawn_set[spawn_on_line[time_track_counter] - 1]);
            Instantiate(Collectables[spawned_object_type_num[time_track_counter]], transform.TransformDirection(700, spawn_set[spawn_on_line[time_track_counter] - 1], -600), new Quaternion(0, 0, 0, 0));

        }
        else
        {
            Debug.Log("THere is no more");
        }
    }



    

}
