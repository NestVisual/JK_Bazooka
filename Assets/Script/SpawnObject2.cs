using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.AI;

public class SpawnObject2 : MonoBehaviour, IInputClickHandler
{
    public GameObject obj;		//敵キャラのプレハブ
    private GameObject[] objs;	//敵キャラを入れておく配列
    public int max;			    //この場所から同時に出現させる人数
    public float appearTime;		//次の敵キャラが出現するまでの時間
    public int total;			    //この場所から敵キャラが出現する回数
    private static int num;			    //何人出現したか
    private float currentTime;	//待ち時間の計測に使う
    public float range;

    void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
        objs = new GameObject[max];
        currentTime = 0.0f;
        num = 0;
    }
    
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        if (num < total)
        {
            currentTime += Time.deltaTime;

            if (currentTime > appearTime)
            {

                for (int i = 0; i < objs.Length; i++)
                {
                    Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
                    {
                        result = hit.position;
                        if (hit.position.y < 0)
                        {
                            if (objs[i] == null)
                            {
                                objs[i] = Instantiate(obj, result, Quaternion.identity, transform);
                                num++;
                            }
                        }
                        return true;
                    }
                }
                currentTime = 0.0f;
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