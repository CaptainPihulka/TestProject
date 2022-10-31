using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float speedCube;

    private void FixedUpdate()
    {
        transform.position += transform.forward * speedCube;
    }

    public void SetSpeed(float inputSpeed)
    {
        speedCube = inputSpeed;
    }
}