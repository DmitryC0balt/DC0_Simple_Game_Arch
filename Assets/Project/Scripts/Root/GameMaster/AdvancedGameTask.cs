using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Root
{
    public abstract class AdvancedGameTask : ScriptableObject
    {
        public abstract Task RunTask(GameRoot gameRoot);
    }
}