using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AiToPlayer : MonoBehaviour
{
    [SerializeField] private List<AIPathController> Bots;

    private void Start()
    {
        InvokeRepeating("UpdatePath", 2f, 1);
    }

    private void UpdatePath()
    {
        Bots.Clear();
        Bots = FindObjectsOfType<AIPathController>().ToList();
        Bots.First().Target = transform;
    }
}
