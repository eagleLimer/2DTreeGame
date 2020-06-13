using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.UI;

namespace Completed
{
    public class SwitchPart : MonoBehaviour
    {
        [SerializeField] BodyParts[] bodyParts;
        [SerializeField] string[] labels;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].Init(labels);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                bodyParts[0].SwitchParts(labels);
            }
        }
    }

    [System.Serializable]
    public class BodyParts
    {
        [SerializeField] Button button;
        [SerializeField] SpriteResolver[] spriteResolver;
        public int id;

        public SpriteResolver[] SpriteResolver { get => spriteResolver; }

        //method to init the button callback
        public void Init(string[] labels)
        {
            //button.onClick.AddListener(delegate { SwitchParts(labels); });
        }

        //method that are going to be triggered by the button, and it will switch the sprites of each resolver list.
        public void SwitchParts(string[] labels)
        {
            id++;
            id = id % labels.Length;

            foreach (var item in spriteResolver)
            {
                item.SetCategoryAndLabel(item.GetCategory(), labels[id]);
            }
        }
    }
}