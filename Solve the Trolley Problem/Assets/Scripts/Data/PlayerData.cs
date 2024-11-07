using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject _saveDataPrefab;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private Player _playerScript;
    [SerializeField] private PlayerSubData _saveData;

    public GameObject PlayerObj {  get { return _playerObj; } }
    public Player PlayerScript { get { return _playerScript; } }
    public PlayerSubData SaveData { get { return _saveData; } }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] predecessors = GameObject.FindGameObjectsWithTag("PlayerData");
        GameObject ogPlayerData = null;
        
        foreach (GameObject predecessor in predecessors)
        {
            if (predecessor != gameObject)
            {
                ogPlayerData = predecessor;
                ogPlayerData.GetComponent<PlayerData>().AcquirePlayer();
                Destroy(gameObject);
            }
        }

        if (ogPlayerData is null)
        {
            _saveData = Instantiate(_saveDataPrefab, gameObject.transform).GetComponent<PlayerSubData>();
            _saveData.Name = "Nameless";
            _saveData.LastScene = 1;
            AcquirePlayer();
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    public void AcquirePlayer()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        if (_playerObj is not null)
            _playerScript = _playerObj.GetComponent<Player>();
    }
}
