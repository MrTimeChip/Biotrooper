using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitStats
{
    public int Health { get; set; }
    public int Speed { get; set; }
    public int Damage { get; set; }
    public int JumpHeight { get; set; }


    // Update is called once per frame
    public void Update();

    public bool IsDeath();
}
