using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _amountSummons;
    [SerializeField] private int _amountSummonsToWin;

    [SerializeField] private float _waitBefore—reate = 1f;

    [SerializeField] private List<GameObject> _typeSummons;
    [SerializeField] private List<Transform> _startPositions;

    [SerializeField] private List<GameObject> _summons = new();

    private void Awake()
    {
        for (int i = 0; i < _amountSummons; i++)
        {
            GameObject newSummon = FillListSummons();
            newSummon.gameObject.SetActive(false);
            _summons.Add(newSummon);
        }
    }

    private void Start()
    {
        StartCoroutine(SendToTheAttack());
    }

    public void AddNewSummon(GameObject summon)
    {
        _summons.Add(summon);
    }

    private IEnumerator SendToTheAttack()
    {
        int amountCreatedSummonForLevel = 0;

        while (amountCreatedSummonForLevel < _amountSummonsToWin)
        {
            GameObject newSummon = ActivateNewSummon();
            newSummon.transform.position = _startPositions[Random.Range(0, _startPositions.Count)].position;

            amountCreatedSummonForLevel++;

            yield return new WaitForSeconds(_waitBefore—reate);
        }
    }

    private GameObject FillListSummons()
    {
        return Instantiate(_typeSummons[Random.Range(0, _typeSummons.Count)], transform);
    }

    private GameObject ActivateNewSummon()
    {
        GameObject _activateSummon = _summons[0];
        _activateSummon.gameObject.SetActive(true);
        _summons.Remove(_activateSummon);
        return _activateSummon;
    }
}
