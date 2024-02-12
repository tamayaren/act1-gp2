using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private ColorHandler colorHandler;
    private GameObject target;
    private float movementSpeed = 10f;

    private void Start()
    {
        this.target = GameObject.FindGameObjectWithTag("Player");
        this.colorHandler = GetComponent<ColorHandler>();

        this.movementSpeed = Random.Range(8f, 10f);

        colorHandler.CurrentColor = (ValidColor)Random.Range(0, (float)System.Enum.GetValues(typeof(ValidColor)).Cast<ValidColor>().Max());
    }

    private void Update()
    {
        if (this.target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, this.target.transform.position, movementSpeed * Time.deltaTime);

            Vector3 relativePos = this.target.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(relativePos, Vector3.up), 6f * Time.deltaTime);
        }

        if ((transform.position - target.transform.position).magnitude <= 1f)
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}
