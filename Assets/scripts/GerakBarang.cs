using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakBarang : MonoBehaviour
{
    float speed = 1.5f;
    public Sprite[] sprites;

    private Vector3 screenPoint;
    private Vector3 offset;
    private float firstX;
    void Start()
    {
        int index = Random.Range(0,sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    
    void Update()
    {
        float move = (speed * Time.deltaTime * 1f) + transform.position.y;
        transform.position = new Vector3(transform.position.x, move);
    }

    void OnMouseDown()
    {
        firstX = transform.position.x;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        transform.position = new Vector3(firstX, transform.position.y, screenPoint.z);
    }
}
