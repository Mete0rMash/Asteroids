using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private List<CollisionObject> group1;
    [SerializeField] private List<CollisionObject> group2;
    [SerializeField] private BulletPooler pool1;
    [SerializeField] private AsteroidPooler pool2;
    [SerializeField] private Player spaceS;

    private void Awake()
    {
        group1 = new List<CollisionObject>();
        group2 = new List<CollisionObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pool1.GetPool().Count; i++)
        {
            group1.Add(pool1.GetPool()[i].GetComponent<CollisionObject>());
        }

        group1.Add(spaceS);

        for (int i = 0; i < pool2.GetPool().Count; i++)
        {
            group2.Add(pool2.GetPool()[i].GetComponent<CollisionObject>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollisionGroups();
    }

    public void AddToList(CollisionObject objC)
    {
        if (!group2.Contains(objC))
        {
            group2.Add(objC);
        }
    }

    public void RemoveFromList(CollisionObject objC)
    {
        if (!group2.Contains(objC))
        {
            group2.Remove(objC);
        }
    }

    /*bool CheckCollision()
    {
        return CheckCollisionGroups();
    }*/

    private bool CheckCollisionGroups()
    {
        for (int i = 0; i < group1.Count; i++)
        {
            for (int j = 0; j < group2.Count; j++)
            {
                RectTransform obj1 = group1[i].GetComponent<RectTransform>();
                RectTransform obj2 = group2[j].GetComponent<RectTransform>();

                IsColliding(obj1, obj2, group1[i], group2[j]);
            }
        }
        return false;
    }

    private bool IsColliding(RectTransform obj1, RectTransform obj2, CollisionObject objc1, CollisionObject objc2)
    {
        if (!objc1.gameObject.activeSelf || !objc2.gameObject.activeSelf) return false;

        if (obj1.sizeDelta.x / 2 + obj2.sizeDelta.x / 2 >= Mathf.Abs(obj2.position.x - obj1.position.x))
        {
            if (obj1.sizeDelta.y / 2 + obj2.sizeDelta.y / 2 >= Mathf.Abs(obj2.position.y - obj1.position.y))
            {
                objc1.OnCollision(objc2.gameObject);
                objc2.OnCollision(objc1.gameObject);


                return true;
            }
        }

        return false;
    }
}
