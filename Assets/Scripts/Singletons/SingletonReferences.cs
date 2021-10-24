using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonReferences : MonoBehaviour
{
    [SerializeField]
    private MasterManager _masterManager;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
