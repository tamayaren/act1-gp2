using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] private ColorHandler colorHandler;

    public float Speed = 64f;

    private void Start()
    {
        colorHandler = GetComponent<ColorHandler>();

        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (transform.forward * Speed), 35f * Time.deltaTime);

        //
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward * 50f, Color.green);

        RaycastHit objectHit; 
        if (Physics.Raycast(transform.position, forward, out objectHit, 50))
        {
            float distance = objectHit.distance;

            if (objectHit.collider.tag == "Enemy" && distance <= 3f)
            {
                GameObject enemyObject = objectHit.collider.gameObject;
                ColorHandler enemyColorHandler = enemyObject.GetComponent<ColorHandler>();

                if (enemyColorHandler.CurrentColor == colorHandler.CurrentColor)
                    Destroy(enemyObject);

                Destroy(gameObject);
            }
        }
    }
}
