using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("���� ����")]
    public int playerScore = 0;
    public int itemsColledted;

    [Header("UI ����")]
    public Text scoreText;
    public Text itemCountText;
    public Text gameStatusText;

    public static GameManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectItem()
    {
        itemsColledted++;
        Debug.Log($"������ ����! (�� : {itemsColledted} ��)");
    }

    public void UpdateUI()
    {
        if(scoreText != null)
        {
            scoreText.text = "���� : " + playerScore;

            if(itemCountText != null)
            {
                itemCountText.text = "������ : " + itemsColledted + "��";
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
