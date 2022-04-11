using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes //Виды маршрутов: линейный и цикличный
    {
        linear,
        loop
    }

    [SerializeField] private PathTypes _pathTypes; //Определяет тип маршрута
    [SerializeField] private int _movementDirection; //Направление движения
    [SerializeField] private int _moveingTo; //Индекс точки к которой мы будем двигаться
    [SerializeField] List<Transform> _pathElements; //Лист из точек

    private void OnDrawGizmos()
    {
        if (_pathElements == null || _pathElements.Count < 2)
        {
            return;
        }

        for (int i = 1; i < _pathElements.Count; i++)
        {
            Gizmos.DrawLine(_pathElements[i - 1].position, _pathElements[i].position);
        }

        if(_pathTypes == PathTypes.loop)
        {
            Gizmos.DrawLine(_pathElements[0].position, _pathElements[_pathElements.Count - 1].position);
        }
    }

}
