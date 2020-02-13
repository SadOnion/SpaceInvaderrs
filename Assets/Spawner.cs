using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]PathCreation.PathCreator left;
    [SerializeField]PathCreation.PathCreator right;

    public GameObject pathEnemy;
    public GameObject laserEenmy;
    public GameObject rushingEnemy;
    private List<GameObject> objectSpawned;
    private List<Coroutine> spawning;
    private float lvl;
    private bool isLaser;
    private float dificultie=1f;
    private void Start()
    {
        objectSpawned = new List<GameObject>();
        spawning = new List<Coroutine>();
        StartSpawning();
    }
    private void SpawnLaser()
    {
        GameObject o = Instantiate(laserEenmy,new Vector3(Mathf.Sign(Random.Range(-1,1))*6,4.25f,0),laserEenmy.transform.rotation);
        objectSpawned.Add(o);
    }
    
    private void SpawnFromPath(PathCreation.PathCreator path)
    {
         PathFollower p = Instantiate(pathEnemy,Vector3.up*10,pathEnemy.transform.rotation).GetComponent<PathFollower>();
            p.pathCreator = path;
        objectSpawned.Add(p.gameObject);
    }
    public void CleanSceneFromSpawnes()
    {
        foreach (var item in spawning)
        {
            StopCoroutine(item);
        }
        foreach (var item in objectSpawned)
        {
            if(item!=null)Destroy(item);
        }
    }
    public void StartSpawning()
    {
        lvl = GameManager.instance.level;
        dificultie = 1/lvl;
         spawning.Add(StartCoroutine(SpawnPath()));
        spawning.Add(StartCoroutine(SpawnRushing()));
        spawning.Add(StartCoroutine(SpawnLasers()));
    }
    private  IEnumerator SpawnLasers()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < lvl; i++)
        {
            SpawnLaser();
            yield return new WaitForSeconds(Random.Range(8,12));
        }

    }
    private IEnumerator SpawnRushing()
    {
        while (true)
        {
            yield return new WaitForSeconds(2*dificultie * .5f);
            int rand = UnityEngine.Random.Range(0,10);
            if(rand == 1 || rand ==0)
            {
                GameObject o = Instantiate(rushingEnemy,new Vector3(Random.Range(-3.5f,3.5f),Random.Range(6,8),0),rushingEnemy.transform.rotation);
                objectSpawned.Add(o);
            }
        }
       
    }
    private IEnumerator SpawnPath()
    {
        while (true)
        {
            int rand = Random.Range(0,2);
                PathCreation.PathCreator p = rand == 0? left:right;
            for (int i = 0; i < 5*lvl; i++)
            {
                yield return new WaitForSeconds(2*dificultie);  
                
                SpawnFromPath(p);
            }
            yield return new WaitForSeconds(10 *dificultie);
        }
    }
}
