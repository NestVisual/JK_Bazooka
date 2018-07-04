using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 発射体の振る舞いを定義するBehaviourクラス.
/// Collider接触時に着弾のエフェクトを発生させて、PaintManagerで接触した箇所にペイントして、自身をDestoryする
/// </summary>
public class BulletBehaviour : MonoBehaviour
{
    /// <summary>
    /// 着弾時のパーティクルエフェクト
    /// </summary>
    public GameObject Explosion;

    /// <summary>
    /// 着弾時のサウンドエフェクト
    /// </summary>
    public AudioClip splashSound;

    /// <summary>
    /// 着弾時のサウンドボリューム
    /// </summary>
    public float volume;

    /// <summary>
    /// SpatialMappingのMesに対する衝突判定が不安定なため、RayCastを使って独自に判定する用の変数
    /// </summary>
    private Rigidbody rigidBody;
    private Vector3 lastPos;
    private Vector3 lastHitPos;
    private Vector3 lastHitNormal;
    private bool lastHit;

    public void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody>();
        this.updateCollisionDetectInfo();
    }

    public void Update()
    {
        var pos = this.transform.position;

        // Pos(t) < 衝突予測位置(t-1) < Pos(t-1) であれば、衝突と判定
        if (this.lastHit && Vector3.SqrMagnitude(this.lastHitPos - this.lastPos) < Vector3.SqrMagnitude(pos - this.lastPos))
        {
            this.OnHit(this.lastHitPos, this.lastHitNormal);
            return;
        }

        this.updateCollisionDetectInfo();
    }



    /// <summary>
    /// 衝突判定用に各フレームの位置、Raycast位置情報を更新する
    /// </summary>
    private void updateCollisionDetectInfo()
    {
        var pos = this.transform.position;
        var dir = this.rigidBody.velocity;
        this.lastHit = false;
        RaycastHit hitInfo;
        if (Physics.Raycast(pos, dir.normalized, out hitInfo, 5.0f))
        {
            if (hitInfo.collider.gameObject.layer == 31)
            {
                this.lastHitPos = hitInfo.point;
                this.lastHitNormal = hitInfo.normal;
                this.lastHit = true;
            }
        }
        this.lastPos = pos;

    }

    private void OnHit(Vector3 point, Vector3 normal)
    {
        if (Explosion != null)
        {
            float dist = Vector3.Distance(point, Camera.main.transform.position);
            if (dist > 5)
            {
                Instantiate(Explosion, point + Vector3.up * 0 - Camera.main.transform.forward * 0.6f, Quaternion.identity);
            }
            else if (dist > 3)
            {
                Instantiate(Explosion, point + Vector3.up * 0 - Camera.main.transform.forward * 0.3f, Quaternion.identity);
            }
            else
            {
                Instantiate(Explosion, point + Vector3.up * 0 - Camera.main.transform.forward * 0, Quaternion.identity);
            }
        }
        //AudioSource.PlayClipAtPoint(splashSound, point, volume);
        
        // 解放
        Destroy(this.gameObject);
    }
}