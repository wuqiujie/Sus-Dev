using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTesting : MonoBehaviour
{
    private Grid[,] grid;
    [SerializeField]
    public GameObject[] house;
    public float roadLength;
    public int blockSize;
    public int numOfBlocks;
    public int gridCellSize;

    [SerializeField]
    public GameObject smoke;
    public GameObject holder;

    // Start is called before the first frame update
    void Start()
    {
        roadLength = 0f;
        blockSize = 4;
        numOfBlocks = 4;
        gridCellSize = 2;
        grid = new Grid[numOfBlocks, numOfBlocks];
        for(int i = 0; i < numOfBlocks; i++)
        {
            for (int j = 0; j < numOfBlocks; j++)
            {
                grid[i,j] = new Grid(new Vector3(blockSize * gridCellSize * i + roadLength*i, 0.5f, blockSize * gridCellSize * j + roadLength * j), blockSize, blockSize, gridCellSize);
            }
        }
        /*grid = new Grid(new Vector3(0,0.5f,0), 3, 3, 2f);*/
        for (int i = 0; i < 4; i++)
        {
            InstantiateHouse();
        }
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetMouseButtonDown(0))
        {
            InstantiateHouse();
        }*/
    }
    //store all the blank grid into a array
    public void InstantiateHouse()
    {
        if (grid[0, 0]._vacant.Count > 0)
        {
            for (int i = 0; i < numOfBlocks; i++)
            {
                for (int j = 0; j < numOfBlocks; j++)
                {
                    //randomize buildings
                    int index = Random.Range(0, house.Length - 1);
                    //randomize building spawning position
                    int x = grid[i, j]._vacant[grid[i, j]._vacant.Count - 1][0];
                    int z = grid[i, j]._vacant[grid[i, j]._vacant.Count - 1][1];
                    Vector3 pos = new Vector3(blockSize * gridCellSize * i + roadLength * i + x * grid[i, j]._cellSize, 2.5f, blockSize * gridCellSize * j + roadLength * j + z * grid[i, j]._cellSize);
                    Vector3 cellPos = new Vector3(x * grid[i, j]._cellSize, 0.5f, z * grid[i, j]._cellSize);
                    GameObject building = Instantiate(house[index], pos + new Vector3(grid[i, j]._cellSize / 2, 0, grid[i, j]._cellSize / 2), Quaternion.identity);
                    building.transform.SetParent(holder.transform);
                    StartCoroutine(InstatiateBuildings(building.transform, building.transform.position, 1f));
                    grid[i, j].SetValue(cellPos, 1);
                }
            }
        }
    }
    IEnumerator InstatiateBuildings(Transform t, Vector3 startPosition, float duration)
    {

        float time = 0;
        int acceleration = 2;
        Vector3 targetPosition = new Vector3(startPosition.x, 0.5f, startPosition.z);
        while (time + time * acceleration < duration)
        {
            t.position = Vector3.Lerp(startPosition, targetPosition, (time + time * acceleration )/ duration);
            time += Time.deltaTime;
            yield return null;

        }
        Smoke(startPosition);
        t.position = targetPosition;
    }
    public void Smoke(Vector3 Position)
    {
        Vector3 targetPos = new Vector3(Position.x, 0f, Position.z);
        GameObject smk = Instantiate(smoke, targetPos, Quaternion.identity);
        Destroy(smk, 1f);
    }
}
