using System;
using System.Collections;
using System.Collections.Generic;
using Hamlet.Game.Runtime.PNJs;
using NaughtyAttributes;
using UnityEngine;

namespace Hamlet.Game.Runtime
{
    public class MineBuilding : MonoBehaviour
    {   
        public event Action OnLevelChange;

        [SerializeField] 
        private Geode[] geodes;
        [SerializeField]
        private int level;

        private int MinedGeode => level - 1;
        public int LvlMine => level;

        public GameObject buttonMainGallerie;


        private void Start()
        {
            for (int i = 0; i < geodes.Length; i++)
            {
                geodes[i].maxHp = geodes[i].hp;
            }

            OnLevelChange?.Invoke();
        }
        public void CollectAtLevel(int level) => Collect(level - 1, false);
        public void CollectCurrentLevel() => Collect(MinedGeode, true);


        private void Collect(int index, bool withRandomness)
        {
            if (index < 0 || index >= geodes.Length)
                return;

            if (!geodes[index].TryCollect())
                return;

            //Rng
            if (withRandomness && index < geodes.Length - 1)
            {
                float randomNumber = UnityEngine.Random.value;
                if (randomNumber < .1f)
                {
                    geodes[index].Reset();
                    geodes[index + 1].Collect();
                    return;
                }
            }

            geodes[index].Reset();
            geodes[index].Collect();
        }



        public void LevelUp()
        {
            if (MinedGeode >= geodes.Length - 1)
                return;

            level++;
            OnLevelChange?.Invoke();

            buttonMainGallerie.SetActive(MinedGeode != geodes.Length - 1);
        }
    }
}
