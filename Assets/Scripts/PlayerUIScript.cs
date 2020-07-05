using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour
{
    public TreeCombat clingReference;
    public GameObject clingBarPrefab;
    public float startXPos;
    public float startYPos;
    public float barSpace;
    private Image[] barList;
    // Start is called before the first frame update
    void Start()
    {
        barList = new Image[clingReference.clingList.Length];
        for (int i = 0; i < clingReference.clingList.Length; i++)
        {
            Vector3 currentPos = new Vector3(startXPos, startYPos + barSpace * i, 0);
            GameObject clingBar = Instantiate(clingBarPrefab, transform) as GameObject;
            Vector3 barPos = clingBar.transform.position;
            clingBar.transform.position = new Vector3(barPos.x, barPos.y - barSpace * i, barPos.z);
            barList[i] = clingBar.transform.GetChild(2).GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < clingReference.clingList.Length; i++)
        {
            barList[i].fillAmount = clingReference.clingList[i].getEnergyPercentage();
        }
    }
}
