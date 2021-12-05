using System.Collections.Generic;
using UnityEngine;

namespace UnityGame.UI
{
    [CreateAssetMenu(fileName = "ScreenList", menuName = "Data/ScreenList", order = 1)]
    public class ScreenList : ScriptableObject
    {
        public List<UIAbstractScreen> screens;
    }
}