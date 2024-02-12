using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehavior : MonoBehaviour
{
    [SerializeField] public float maxDistance = 64f;
    [SerializeField] private GameObject target;
    //
    [SerializeField] public float rotationSpeed = 5f;

    [SerializeField] private GameObject radiusSphere;

    private void Start()
    {
        this.radiusSphere = GameObject.Find("Radius").gameObject;
    }

    private void Update()
    {
        if (!ReferenceEquals(this.radiusSphere, null))
            this.radiusSphere.transform.localScale = new Vector3(this.maxDistance*2, 0.06f, this.maxDistance*2);

        if (this.target == null)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

            if (!ReferenceEquals(enemy, null))
                if ((enemy.transform.position - this.transform.position).magnitude <= maxDistance)
                    this.target = enemy;

            return;
        }

        if (ReferenceEquals(this.target, this)) return;
      
      float distToTarget = Vector3.Distance(this.transform.position, this.target.transform.position);
      Vector3 relativePos = this.target.transform.position - this.transform.position;

      this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(relativePos, Vector3.up), rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, this.maxDistance);
    }
}
