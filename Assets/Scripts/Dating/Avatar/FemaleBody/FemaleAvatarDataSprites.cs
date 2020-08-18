using System;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Dating.Avatar.FemaleBody
{
    [Serializable]
    public class FemaleAvatarDataSprites
    {
        public HairBackToSprite hairBackToSprite = new HairBackToSprite();
        public HairFrontToSprite hairFrontToSprite = new HairFrontToSprite();
        public ExpressionToSprite expressionToSprite = new ExpressionToSprite();
        public GlassesToSprite glassesToSprite = new GlassesToSprite();
        public BlushToSprite blushToSprite = new BlushToSprite();
        public ClothToSprite clothToSprite = new ClothToSprite();
    }

    [Serializable]
    public class HairBackToSprite : SerializableDictionaryBase<HairBack, Sprite>
    {
    }

    [Serializable]
    public class HairFrontToSprite : SerializableDictionaryBase<HairFront, Sprite>
    {
    }

    [Serializable]
    public class ExpressionToSprite : SerializableDictionaryBase<Expression, Sprite>
    {
    }

    [Serializable]
    public class GlassesToSprite : SerializableDictionaryBase<Glasses, Sprite>
    {
    }

    [Serializable]
    public class BlushToSprite : SerializableDictionaryBase<Blush, Sprite>
    {
    }

    [Serializable]
    public class ClothToSprite : SerializableDictionaryBase<Cloth, Sprite>
    {
    }
}