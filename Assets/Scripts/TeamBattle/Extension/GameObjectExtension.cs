using UnityEngine;
using UnityEngine.Assertions;

namespace TeamBattle.Extension
{

    public static class GameObjectExtension
    {

        public static T GetComponentStrictly<T>(this GameObject self)
            where T : Component
        {
            var component = self.GetComponent<T>();
            Assert.IsNotNull(component, "component != null");

            return component;
        }

        public static T GetComponentInChildrenStrictly<T>(this GameObject self)
            where T : Component
        {
            var component = self.GetComponentInChildren<T>();
            Assert.IsNotNull(component, "component != null");
            Assert.AreEqual(1, component.GetComponentsInChildren<T>().Length);

            return component;
        }

    }

}
