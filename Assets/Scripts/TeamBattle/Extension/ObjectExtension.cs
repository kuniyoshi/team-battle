using UnityEngine;

namespace TeamBattle.Extension
{

    public static class ObjectExtension
    {

        public static T Nullable<T>(this T self)
            where T : Object
        {
            return self == null ? null : self;
        }

    }

}
