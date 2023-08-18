using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float maxTime = 1f;
    private float time = 0f;
    public GameObject obstacle;

    public float height;



    void Update()
    {
        if(time > maxTime)
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(go, 10f);
            time = 0;
        }

        time += Time.deltaTime;
    }
}
