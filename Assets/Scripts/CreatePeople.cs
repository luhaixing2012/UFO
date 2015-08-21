using UnityEngine;
using System.Collections;

public class CreatePeople : MonoBehaviour
{
    public float createTime = 5f;
    public float createDelay = 3f;
    public GameObject[] peoples;

    void Start()
    {
        InvokeRepeating("RepeatCreate",createTime,createDelay);
    }

    void RepeatCreate()
    {
        int peopleIndex = Random.Range(0, peoples.Length);

        Instantiate(peoples[peopleIndex], transform.position, transform.rotation);
    }
}
