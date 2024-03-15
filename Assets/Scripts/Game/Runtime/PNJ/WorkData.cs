using Hamlet.Game.Runtime.Player;
using UnityEngine;

namespace Hamlet.Game.Runtime.PNJs
{
    [CreateAssetMenu(menuName = "Hamlet/Work")]
    public class WorkData : ScriptableObject
    {
        public string WorkName;

        public Sprite sprite;
        public ResourceData resource;
    }

}
