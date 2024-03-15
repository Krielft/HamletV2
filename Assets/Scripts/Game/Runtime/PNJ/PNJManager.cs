using Hamlet.Game.Runtime.Buildings;
using System.Collections.Generic;
using UnityEngine;

namespace Hamlet.Game.Runtime.PNJs
{
    public class PNJManager : MonoBehaviour
    {
        public List<Building> buildings;
        [SerializeField] float intervalCollect;
        float currentTime;


        private void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime > intervalCollect)
            {
                foreach (Building b in buildings)
                {
                    b.Collect("AutoCollect");
                }
                currentTime = 0f;
            }

        }


    }

}
