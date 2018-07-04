using UnityEngine;
using UnityEngine.AI;

// Walk to a random position and repeat
[RequireComponent(typeof(NavMeshAgent))]
public class RandomWalk : MonoBehaviour
{
    public float m_Range = 3.0f;
    NavMeshAgent m_agent;
    public bool drawPath = false;
    LineRenderer lineRenderer;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        if (drawPath)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
    }

    void Update()
    {
        if (m_agent.pathPending || m_agent.remainingDistance > 0.1f)
        {
            return;
        }

        var nextPoint = m_Range * Random.insideUnitCircle;
        m_agent.destination = m_agent.transform.position + new Vector3(nextPoint.x, 0, nextPoint.y);

        if (drawPath)
        {
            var positions = m_agent.path.corners;
            lineRenderer.widthMultiplier = 0.1f;
            lineRenderer.positionCount = positions.Length;
            for (int i = 0; i < positions.Length; i++)
            {
                lineRenderer.SetPosition(i, positions[i]);
            }
        }
    }
}