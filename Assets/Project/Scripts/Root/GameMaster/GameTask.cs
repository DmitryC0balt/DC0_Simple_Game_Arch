using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Root
{
    public abstract class GameTask : ScriptableObject
    {
        public abstract Task RunTask();
    }
}