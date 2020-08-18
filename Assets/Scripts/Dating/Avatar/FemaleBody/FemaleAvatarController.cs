using System;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;
using UnityEngine.UI;

namespace Dating.Avatar.FemaleBody
{
    public class FemaleAvatarController : MonoBehaviour
    {
        public Image hairBack;
        public Image hairFront;
        public Image beard;
        public Image expression;
        public Image glasses;
        public Image blush;
        public Image cloth;

        public AccessoriesToObjects accessories = new AccessoriesToObjects();

        public FemaleAvatarDataSprites sprites;
        
        public FemaleAvatarData data;

        private void Start()
        {
            data = FemaleAvatarData.Random();
            Redraw();
        }

        public void SetData(FemaleAvatarData data)
        {
            this.data = data;
            Redraw();
        }

        public void Redraw()
        {
            // Hair
            hairBack.sprite = sprites.hairBackToSprite[data.hairBack];
            hairBack.color = data.hairColor;
            hairFront.sprite = sprites.hairFrontToSprite[data.hairFront];
            hairFront.color = data.hairColor;
            
            // Face
            beard.color = data.hairColor;
            beard.gameObject.SetActive(data.beard);
            expression.sprite = sprites.expressionToSprite[data.expression];
            glasses.sprite = sprites.glassesToSprite[data.glasses];
            glasses.gameObject.SetActive(data.glasses != Glasses.None);
            blush.sprite = sprites.blushToSprite[data.blush];
            blush.gameObject.SetActive(data.blush != Blush.None);
            
            // Accessories
            foreach (var obj in accessories)
            {
                obj.Value.SetActive(false);
            }
            foreach (var accessory in data.accessories)
            {
                accessories[accessory].SetActive(true);
            }
            
            // Cloth
            cloth.sprite = sprites.clothToSprite[data.cloth];
        }
    }

    [Serializable]
    public class AccessoriesToObjects : SerializableDictionaryBase<Accessories, GameObject>
    {
    }
}