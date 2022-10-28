using System.Collections;
using System.Collections.Generic;
using Core.Factory;
using Core.InputController;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text _textKillEnemy;
    
    void Start()
    {
        _textKillEnemy.text = $"Enemies killed {ReactDeadEnemySingleton.Instance.SumDeadEnemy}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        ActiveUnitsSingleton.Instance.Reset();
        ReactDeadEnemySingleton.Instance.Reset();
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
