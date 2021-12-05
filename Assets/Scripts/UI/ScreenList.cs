using System.Collections.Generic;
using UnityEngine;

namespace UnityGame.UI
{
    [CreateAssetMenu(fileName = "ScreensList", menuName = "Data/ScreensList", order = 1)]
    public class ScreenList : ScriptableObject
    {
        public List<UIAbstractScreen> screens;
    }
}