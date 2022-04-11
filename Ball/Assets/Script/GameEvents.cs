using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    public static event System.Action<int> Score;
    public static event System.Action FastBrick;
    public static event System.Action SlowBrick;
    public static event System.Action<float> SpeedBulled;
    public static event System.Action<int> HP;
    public static event System.Action ThreeBoll;
  




    public static void CallScoreEvent(int AddScore)
    {   
            Score?.Invoke(AddScore);     
    }
    public static void CollFastBrickEvent()
    {
        FastBrick?.Invoke();
    }
    public static void CollSlowBrickEvent()
    {
        SlowBrick?.Invoke();

    }
    public static void CollsSpeedBulledEvent(float speed)
    {
        SpeedBulled?.Invoke(speed);
    }
    public static void CollThreeBollEvent()
    {
        ThreeBoll?.Invoke();

    }
    public static void CollHPEvent(int HelsPoint)
    {
        HP?.Invoke(HelsPoint);
    }


}
