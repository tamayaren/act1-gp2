using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehavior : MonoBehaviour
{
    [SerializeField] private float maxDistance = 25f;
    [SerializeField] private GameObject target;
    //
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float movementSpeed = 10f;

    private void Update()
    {
      if (ReferenceEquals(this.target, this)) return;
      
      float distToTarget = Vector3.Distance(this.transform.position, this.target.transform.position);

      if (distToTarget < maxDistance)
        {
            Vector3 relativePos = this.target.transform.position - this.transform.position;

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(relativePos, Vector3.up), rotationSpeed * Time.deltaTime);
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.transform.position, movementSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, this.maxDistance);
    }
}
