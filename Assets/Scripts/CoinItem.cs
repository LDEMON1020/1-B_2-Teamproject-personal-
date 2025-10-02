using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : interactableObject
{
    [Header("���� ����")]
    public int coinValue = 10;
    public string questTag = "Coin";

    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
        objectName = "����";
        interactionText = "[E] ���� ȹ��";
        interactionType = InteractionType.Collecible;
    }

    // Update is called once per frame
    protected override void CollectItem()
    {
        if(QuestManager.Instance != null)
        {
            QuestManager.Instance.AddCollectProgress(questTag);
        }
        Destroy(gameObject);
    }
}
