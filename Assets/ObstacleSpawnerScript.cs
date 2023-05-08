using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using Unity.Jobs;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public AssetReference obstacleSpawner; // obstaclePrefab;
    public float obstaclespeed = 10f; //5f;
    public float spawnInterval = 1f;
    public int maxObstaclesOnScreen = 3;

    private List<GameObject> rocks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    public IEnumerator SpawnObstacle()
    {
        while (true)
        {
           // float randomInterval = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(spawnInterval);

          //  if (rocks.Count < maxObstaclesOnScreen)
           // {
                var spawnPosition = new Vector3(-4f, Random.Range(2f, 5f), 0f);
                var obstacleOp = Addressables.InstantiateAsync(obstacleSpawner, spawnPosition, Quaternion.identity);

                obstacleOp.Completed += (operation) =>
                {
                    var obstacle = operation.Result;
                    obstacle.transform.SetParent(transform);
                    rocks.Add(obstacle);

                    StartCoroutine(MoveObstacle(obstacle));
                };
            }
        }
   // }//


    private IEnumerator MoveObstacle(GameObject rock)
    {
        while (rock.transform.position.x > -10f)
        {
            rock.transform.Translate(Vector3.left * obstaclespeed * Time.deltaTime);
            yield return null;
        }
        Addressables.ReleaseInstance(rock);
    }


// Update is called once per frame
void Update()
    {
        
    }
}
