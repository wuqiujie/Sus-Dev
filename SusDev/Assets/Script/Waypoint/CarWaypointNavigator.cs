using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWaypointNavigator : MonoBehaviour
{
    CarNavController _controller;
    public Waypoint _currentWP;
/*    int direction;*/
    private void Awake()
    {
        _controller = GetComponent<CarNavController>();
    }
    private void Start()
    {
/*        direction = Mathf.RoundToInt(Random.Range(0f, 1f));*/
        _controller.SetDestination(_currentWP.GetPosition());
    }
    // Update is called once per frame
    void Update()
    {
        if (_controller._reachedDestination)
        {
            bool shouldBranch = false;
            if (_currentWP.branches != null && _currentWP.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= _currentWP.branchRatio ? true : false;
            }

            if (shouldBranch)
            {
                _currentWP = _currentWP.branches[Random.Range(0, _currentWP.branches.Count - 1)];
            }
            else
            {
                _currentWP = _currentWP._nextWP;
            }
            _controller.SetDestination(_currentWP.GetPosition());
        }
    }
}
