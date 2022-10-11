using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pillarPrefabs;  //A list of pillar object templates
    [SerializeField]
    private float spawnMinTime; //The minimum amount of time to wait before spawning a pillar
    [SerializeField]
    private float spawnMaxTime; //The maximum amount of time to wait before spawning a pillar

    public GameObject prefab;
    public float spawnRate;
    public float minHeight;
    public float maxHeight;

    private float nextSpawnTime; //The next time to spawn a pillar

    // Start is called before the first frame update
    void Start()
    {
        //Initalize when you will spawn the first pillar here.
        spawnRate = 1f;
        minHeight = -3f;
        maxHeight = 0f;
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate); 
    }

    private void OnDisable()
    {
       CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        GameObject pillars = Instantiate(prefab, transform.position, Quaternion.identity);
        pillars.transform.position += Vector3.up * Random.Range(minHeight,maxHeight);
    }

    // Update is called once per frame
    void Update()
    {

        //Here we will want to check if it's time to spawn another pillar. 

        //To spawn a pillar:
        //Randomly select a pillar template from the list
        //Use Instantiate to create an instance of that template in the game world.
        //Select the next time to spawn a pillar
        //int a = Random.Range(0, 3);

        //GameObject pillarPrefabs = Instantiate(pillarPrefabs[a], transform.position);
        //pillarPrefabs.transform.position += Vector3.up * Random.Range(spawnMinTime, spawnMaxTime);
        /*using Random = UnityEngine.Random;*/

        
        
    }
}
