using System;
using System.Collections.Generic;
using System.Net;

namespace CourseSAPD.NavigationSystem.Enums
{
    public static class EnumExtensions
    {
        private readonly static Dictionary<SceneType, string> _sceneTypes = new Dictionary<SceneType, string>()
        {
            {SceneType.None, "" },
            {SceneType.ListScene, "Список базы данных" },
            {SceneType.ListSearch, "Список базы данных" }
        };

        private readonly static Dictionary<ActionPoints, string> _actionPoints = new Dictionary<ActionPoints, string>()
        {
            {ActionPoints.Next, "->" },
            {ActionPoints.Previous, "<-" },
            {ActionPoints.HideOrShow, "Скрыть/раскрыть" },
            {ActionPoints.Sort, "Отсортировать" },
            {ActionPoints.Searсh, "Поиск по ключу" }
        };

        public static string GetFriendlyName(this Enum thisEnum)
        {
            Type type = thisEnum.GetType();
            switch (type)
            {
                case var t when t == typeof(SceneType):
                    return _sceneTypes[(SceneType)thisEnum];

                case var t when t == typeof(ActionPoints):
                    return _actionPoints[(ActionPoints)thisEnum];

                default:
                    throw new NotImplementedException($"Не используй меня с {type} :)");
            }
        }

        public static Array ExtractFromEnum(this Enum thisEnum) => Enum.GetValues(thisEnum.GetType());

        public static Enum SetValue(this Enum thisEnum, int value)
        {
            Type type = thisEnum.GetType();
            switch (type)
            {
                case var t when t == typeof(SceneType):
                    return (SceneType)value;

                case var t when t == typeof(ActionPoints):
                    return (ActionPoints)value;

                default:
                    throw new NotImplementedException($"Не используй меня с {type} :)");
            }
        }
    }
}
