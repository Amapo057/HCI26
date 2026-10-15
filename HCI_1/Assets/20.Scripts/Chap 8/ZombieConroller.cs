using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieConroller : MonoBehaviour
{
    public GameObject destinationFolder;
    Transform[] destinations;
    int destinationIndex;

    float minDistance = 1f;

    NavMeshAgent nav;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        destinations = destinationFolder.GetComponentsInChildren<Transform>();
        destinationIndex = Random.Range(1, destinations.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Arrived())
        {
            destinationIndex = Random.Range(1, destinations.Length);
        }
        nav.SetDestination(destinations[destinationIndex].position);
    }

    bool Arrived()
    {
        if(Vector3.Distance(transform.position, destinations[destinationIndex].position) < minDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
