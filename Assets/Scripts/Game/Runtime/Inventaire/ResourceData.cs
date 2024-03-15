using UnityEngine;
namespace Hamlet.Game.Runtime.Player
{


    [CreateAssetMenu(menuName = "Hamlet/Resource")]
    public class ResourceData : ScriptableObject, IInventoryItem
    {
        public bool isPrincipalResource;

        public string Name => name;

        public int expeditionPower = 1;
    }
}