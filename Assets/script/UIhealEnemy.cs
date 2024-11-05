using UnityEngine;
using UnityEngine.UI;

public class UIhealEnemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private seachPlayer tim;
    [SerializeField] private enemyHeal _enemyHeal;
    void Start()
    {
        tim = GetComponent<seachPlayer>();
        _enemyHeal = GetComponent<enemyHeal>();
        target = GetComponent<Transform>();
    }
    private void Update()
    {
        
        if (target != null)
        {
            Vector3 screenPos = tim.transform.position + new Vector3(0f,5f,0f);
           
        }
    }
}
