using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.AI;

public class SpawnObject : MonoBehaviour, IInputClickHandler
{
    public GameObject objectPrefab;

    void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    public float range = 10.0f;
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                if (i < 5)
                {
                    Instantiate(objectPrefab, result, Quaternion.identity, transform);
                }
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    void Update()
    {
        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (GazeManager.Instance.IsGazingAtObject)
        {
            var hitInfo = GazeManager.Instance.HitInfo;
            
        }
    }
}