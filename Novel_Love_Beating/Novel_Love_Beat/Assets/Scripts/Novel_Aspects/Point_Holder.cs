using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Point_Holder : MonoBehaviour
{
    public int[] character_points;


    public void update_points(int char_num, int char_point)
    {
        character_points[char_num] = char_point;
    }

    public void Next_scene(int next_num, int char_num, int char_point)
    {
        
        SceneManager.LoadScene(next_num);
    }
}
