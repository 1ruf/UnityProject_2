using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Door_System : MonoBehaviour
{
    [SerializeField] private GameObject[] Door;
    [SerializeField] private GameObject SpawnParent;

    private SpriteRenderer[] doorSprite;
    private BoxCollider2D[] collider;

    private void Start()
    {
        doorSprite = new SpriteRenderer[Door.Length];
        collider = new BoxCollider2D[Door.Length];

        for (int i = 0; i < Door.Length; i++)
        {
            doorSprite[i] = Door[i].GetComponent<SpriteRenderer>();
            collider[i] = Door[i].GetComponent<BoxCollider2D>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            LockDoor();
        }
    }

    private void Update()
    {
        if (SpawnParent.transform.childCount == 0)
        {
            OpenDoor();
        }
    }
    private void LockDoor()
    {
        print("Lock_Work");
        DoorControl(Color.red,false);
    }

    private void OpenDoor()
    {
        print("Lock_Work");
        DoorControl(Color.green,true);
    }


    private void DoorControl(Color color,bool Open)
    {
        for (int i = 0; i < Door.Length; i++)
        {
            doorSprite[i].color = color;
            collider[i].isTrigger = Open;
        }
    }

}