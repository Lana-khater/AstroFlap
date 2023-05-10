using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks; 
using UnityEngine.ResourceManagement.AsyncOperations; //addressables

public class ObstacleSpawnerScript : MonoBehaviour
{
    public AssetReference obstacleSpawner; // obstaclePrefab// storeRef
    public float obstaclespeed = 10f; //5f;
    public float spawnInterval = 1f;
    public int maxObstaclesOnScreen = 3; //can edit outside

    private List<GameObject> rocks = new List<GameObject>(); //track

    void Start()
    {
        StartCoroutine(SpawnObstacle()); //Sequence
    }
    //Spawn then move
    public IEnumerator SpawnObstacle() //backgroundway
    {
        while (true)
        {
           // float randomInterval = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(spawnInterval);

           // var spawnPosition = new Vector3(-8f, Random.Range(-2f, 8f), 2f);
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
