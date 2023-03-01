using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSpawner : MonoBehaviour
{
    AudioSource Audation;
    public float[] Simplation = new float[512];

    public GameObject ChangeSizeObject;
    GameObject[] SampleSize = new GameObject[512];
    public float MaxSCale;

    public int spawn_sound_amount = 320;
    private bool spawn_available = true;


    public GameObject collectable;

    public GameObject unpleasnt_collectable;


    public bool activate_filler_spawner = false;

    // Start is called before the first frame update
    void Start()
    {
        Audation = GetComponent<AudioSource>();

        for (int i = 0; i < 512; i++)
        {
            GameObject StartCollectedObjetct = (GameObject)Instantiate(ChangeSizeObject);
            StartCollectedObjetct.transform.position = this.transform.position;
            StartCollectedObjetct.transform.parent = this.transform;
            StartCollectedObjetct.name = "MusicShifter" + 1;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            //StartCollectedObjetct.transform.position = Vector3.forward * 100;

            StartCollectedObjetct.transform.position = new Vector3(.1f, 0, 0);
            SampleSize[i] = StartCollectedObjetct;

        }

        Change_orientation();
    }

    void Change_orientation()
    {
        //this.transform.position = new Vector3(600, 200, -400);
        //this.transform.position = new Vector3(755, 155, 97);
        this.transform.SetPositionAndRotation(new Vector3(580, 170,  80), new Quaternion(1, 2, 3, 1));

        this.transform.localScale = new Vector3(.4f, 1, .4f);
    }

        // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();

        for (int a = 0; a < 512; a++)
        {
            if (SampleSize != null)
            {
                SampleSize[a].transform.localScale = new Vector3((Simplation[a] * MaxSCale) + 10, (Simplation[a] * MaxSCale) + 6, 10);

                if (activate_filler_spawner)
                {
                    spawning_unpleasnt(a);
                }
            }
        }
    }

    void GetSpectrumAudioSource()
    {
        Audation.GetSpectrumData(Simplation, 0, FFTWindow.Blackman);
    }

    void spawning_unpleasnt(int value)
    {
        if (SampleSize[value].transform.localScale.x > spawn_sound_amount && spawn_available == true)
        {
            spawn_available = false;
            Invoke("Spawn_is_available", .1f);
            //spawn badies/ goodies
            if(collectable != null)
            {
                Instantiate(collectable, transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            }

            //Debug.Log("Doingit");
        
        }
    }

    void Spawn_is_available()
    {
        spawn_available = true;
    }
}
