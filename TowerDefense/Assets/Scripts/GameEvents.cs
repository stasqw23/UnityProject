using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameEvents
{
    public static event System.Action<GameObject> RemoveEnemyFromGunsLists;
    public static event System.Action<int,GameObject,GameObject,GameObject> StartRoketEvent;
    public static event System.Action<int>ChangeGoldEvent;
    public static event System.Action<bool> PermissionEvent;
    public static event System.Action<int> ScoreEvent;
    public static event System.Action<int> HealthPointEvent;




    public static void Call_RemoveEnemyFromGunsLists(GameObject enemyWhichRemove)
    {
        RemoveEnemyFromGunsLists?.Invoke(enemyWhichRemove);
    }
    public static void CallStartRoketEvent(int roket, GameObject target,GameObject roketContainer, GameObject examination)
    {
        StartRoketEvent?.Invoke(roket, target, roketContainer, examination);
    }
    public static void CallChangeGoldEvent(int gold)
    {
        ChangeGoldEvent?.Invoke(gold);
    }
    public static void CallPermissionEvent(bool permission)
    {
        PermissionEvent?.Invoke(permission);
    } 
    public static void CallScoreEvent(int score)
    {
        ScoreEvent?.Invoke(score);
    } public static void CallHealthPointEvent(int hp)
    {
        HealthPointEvent?.Invoke(hp);
    } 
}
