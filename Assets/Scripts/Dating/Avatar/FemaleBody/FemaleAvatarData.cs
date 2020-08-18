using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Dating.Avatar.FemaleBody
{
    [Serializable]
    public class FemaleAvatarData
    {
        private const int MaleChance = 5; // TODO: Move to settings
        private const int AccessoryChance = 25;
        
        private static readonly Random _random = new Random();

        public Color hairColor = Color.white;
        public HairBack hairBack = HairBack.Long;
        public HairFront hairFront = HairFront.Long;

        public bool beard = false;

        public Expression expression = Expression.Normal;
        public Glasses glasses = Glasses.None;
        public Blush blush = Blush.Small;

        public List<Accessories> accessories = new List<Accessories>();

        public Cloth cloth = Cloth.Towel;

        public void FixPossibleErrors()
        {
            if (hairBack == HairBack.Bob)
            {
                hairFront = HairFront.Short;
            }
        }

        public static FemaleAvatarData Random()
        {
            var avatar = new FemaleAvatarData();

            avatar.hairColor = UnityEngine.Random.ColorHSV(0,1,0,1,0.5f,1);
            avatar.hairBack = RandomEnumValue<HairBack>();
            avatar.hairFront = RandomEnumValue<HairFront>();

            avatar.beard = _random.Next(0, 100) < MaleChance;
            avatar.expression = RandomEnumValue<Expression>();
            avatar.glasses = RandomEnumValue<Glasses>();
            avatar.blush = RandomEnumValue<Blush>();
            avatar.cloth = RandomEnumValue<Cloth>();

            var accessories = Enum.GetValues(typeof(Accessories));
            foreach (var accessory in accessories)
            {
                if (_random.Next(0, 100) < AccessoryChance)
                {
                    avatar.accessories.Add((Accessories) accessory);
                }
            }

            avatar.FixPossibleErrors();
            return avatar;
        }

        private static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T) v.GetValue(_random.Next(v.Length));
        }
    }
}