using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Point_Holder : MonoBehaviour
{
    public int[] character_points;

    static Character_Point_holder transfer_point_next;

    void Start()
    {
        transfer_point_next = new Character_Point_holder();
    }

    public void update_points(int char_num, int char_point)
    {
        character_points[char_num] = char_point;
    }

    private void update_points()
    {
        transfer_point_next.Tally_up_points(character_points);
    }

    public void Next_scene(int next_num, int char_num, int char_point)
    {
        update_points();
        SceneManager.LoadScene(next_num);
    }
}
