using Hamlet.Game.Runtime.Player;
using UnityEngine;

namespace Hamlet.Game.Runtime.Buildings
{


    [CreateAssetMenu(menuName = "Hamlet/BuildingData")]
    public class BuildingData : ScriptableObject
    {
        [SerializeField] public string BuildingName;
        [SerializeField] public int NmbrResourceClickvalue;
        [SerializeField] public int NmbrResourceAutoSecvalue;
        [SerializeField] public int SlotsPNJsvalue;
        [SerializeField] public ResourceData Data;

        /* public Upgrade[] NmbrResourceClick { get; set; }
         public Upgrade[] NmbrResourceAutoSec { get; set; }
         public Upgrade[] SlotsPNJs { get; }*/
    }
}