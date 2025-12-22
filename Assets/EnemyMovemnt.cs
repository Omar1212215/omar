using UnityEngine;
using UnityEngine.AI;

public class EnemyMovemnt : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    
    void Update()
    {
         if (player != null)
 {
 navMeshAgent.SetDestination(player.position);
 }

    }
}
