using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpawnSettings : MonoBehaviour
{
    [SerializeField] private InputField inputSpeed;
    [SerializeField] private InputField inputDistance;
    [SerializeField] private InputField inputWaitSeconds;
    [SerializeField] private GameObject prefCube;

    private void Start()
    {
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        GameObject spawnGameObject = Instantiate(prefCube, transform.position, transform.rotation);
        float speedCube = Single.TryParse(inputSpeed.text, out speedCube) ? speedCube : 1;
        spawnGameObject.AddComponent<CubeController>().SetSpeed(speedCube);
        
        float distance = Single.TryParse(inputDistance.text, out distance) ? distance : 1;
        Destroy(spawnGameObject , distance / speedCube);
        
        float waitSeconds = Single.TryParse(inputWaitSeconds.text, out waitSeconds) ? waitSeconds : 1;
        yield return new WaitForSecondsRealtime(waitSeconds);
        StartCoroutine(Loop());
    }
}