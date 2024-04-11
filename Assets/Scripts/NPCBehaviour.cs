using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] Transform path;
    [SerializeField] int childrenIndex;
    [SerializeField] Vector3 destination;
    [SerializeField] private Vector3 min, max;

    // Start is called before the first frame update
    void Start()
    {
        destination = path.GetChild(childrenIndex).position;
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        #region Patroll Movemente

        //if(Vector3.Distance(transform.position, destination) < 1.5f)
        //{
        //    childrenIndex++;
        //    childrenIndex = childrenIndex % path.childCount;

        //    destination = path.GetChild(childrenIndex).position;
        //    GetComponent<NavMeshAgent>().SetDestination(destination);
        //}

        #endregion

        #region Mouse Button

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, 1000))
            {
                GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }

        #endregion

        #region Random Patrol

        //if (Vector3.Distance(transform.position, destination) < 1.5f)
        //{
        //    childrenIndex++;
        //    childrenIndex = Random.Range(0, path.childCount);

        //    destination = path.GetChild(childrenIndex).position;
        //    GetComponent<NavMeshAgent>().SetDestination(destination);
        //}

        #endregion

        #region Random Movement

        //if (Vector3.Distance(transform.position, destination) < 1.5f)
        //{
        //    destination = RandomDestination();
        //    GetComponent<NavMeshAgent>().SetDestination(destination);
        //}

        #endregion
    }

    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }
}
