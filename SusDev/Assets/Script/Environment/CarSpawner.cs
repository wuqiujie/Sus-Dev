using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject cars;
    public int numOfCars;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while (count < numOfCars)
        {
            GameObject obj = Instantiate(carPrefab);
            obj.transform.SetParent(cars.transform);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<CarWaypointNavigator>()._currentWP = child.GetComponent<Waypoint>();
            obj.transform.position = child.position+ new Vector3(0,0.12f,0);

            yield return new WaitForSeconds(0.1f);

            count++;

        }
    }
}
