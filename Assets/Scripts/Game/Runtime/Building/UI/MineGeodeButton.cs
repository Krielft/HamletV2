using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hamlet.Game.Runtime
{
    public class MineGeodeButton : MonoBehaviour
    {
        [SerializeField]
        MineBuilding mine;
        CanvasGroup cg;

        [SerializeField]
        int level;

        private void Awake()
        {
            cg = GetComponent<CanvasGroup>();
        }
        private void OnEnable()
        {
            mine.OnLevelChange += Mine_OnLevelUp;
        }


        private void OnDisable()
        {
            mine.OnLevelChange -= Mine_OnLevelUp;
        }

        private void Mine_OnLevelUp()
        {
            bool isLevel = mine.LvlMine - 1 >= level;
            cg.alpha = isLevel ? 1 : 0;
            cg.blocksRaycasts = isLevel;
            cg.interactable = isLevel;
        }

        public void Collect() => mine.CollectAtLevel(level);
    }
}
