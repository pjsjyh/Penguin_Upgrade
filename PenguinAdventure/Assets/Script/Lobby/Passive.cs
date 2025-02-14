using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PassiceInfoScript;
using UnityEngine.UI;
public class Passive : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] PassiveInfo thisPassiveInfo;
    public void SetData(PassiveInfo passiveData)
    {
        thisPassiveInfo = passiveData;

        if(thisPassiveInfo.nowLevel==0)
        {
            BtnIsActive(false);
            ImageSet(false);

        }
        else
        {
            BtnIsActive(true);
            ImageSet(true);
        }

    }


    public void ClickPassive()
    {
        if (thisPassiveInfo.nowLevel > 0)
        {
            BtnIsActive(true);
            ImageSet(true);
        }
        PassiveManager.Instance.SetSelectedPassive(thisPassiveInfo);
    }
    public void BtnIsActive(bool isActive)
    {
        Image buttonImage = this.GetComponent<Image>();
        if (buttonImage != null)
        {
            if (isActive)
            {
                this.GetComponent<Button>().onClick.AddListener(ClickPassive);

            }
            else
            {
                this.GetComponent<Button>().onClick.AddListener(DisableClick);

            }
        }

    }
    void DisableClick() { }
    public void ImageSet(bool isLevelNum)
    {
        Image imageComponent = this.GetComponent<Image>();
        if (isLevelNum)
        {
            if (imageComponent != null && !string.IsNullOrEmpty(thisPassiveInfo.imgSource))
            {
                // imgSource에서 확장자 제외하고 불러옴 (예: "Images/myImage")
                Sprite newSprite = Resources.Load<Sprite>(thisPassiveInfo.imgSource);

                if (newSprite != null)
                {
                    imageComponent.sprite = newSprite;
                }
            }
        }
        else
        {
            Sprite newSprite = Resources.Load<Sprite>("Images/NotOpen");
            if (newSprite != null)
            {
                imageComponent.sprite = newSprite;
            }
        }
    }
}
