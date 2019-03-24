using TeamBattle.Model;
using UnityEditor;

namespace TeamBattle.Editor
{

    [CustomEditor(typeof(BattleGame))]
    public class BattleGameInspector : UnityEditor.Editor
    {
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var battleGame = (BattleGame)target;

            var count = "";

            battleGame.DebugReadCount(ref count);
            
            EditorGUILayout.LabelField("Count", count);
        }

    }

}
