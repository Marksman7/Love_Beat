using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Point_holder
{

    public int[] character_point_next = { 0, 0, 0, 0, 0 };


    public void Tally_up_points(int[] add_points)
    {
       for(int q = 0; q < character_point_next.Length; q++)
        {
            if(add_points.Length > q)
            {
                character_point_next[q] = character_point_next[q] + add_points[q];
            }
        }
    }
    
}
