using GameFramework;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace UGF
{
    public class ScreenComponent : GameFrameworkComponent
    {
        [SerializeField] private GameObject m_UIRoot;

        /// <summary>
        /// 屏幕宽度
        /// </summary>
        public int Width { private set; get; }

        /// <summary>
        /// 屏幕高度
        /// </summary>
        public int Height { private set; get; }

        /// <summary>
        /// 屏幕安全区域
        /// </summary>
        public Rect SafeArea { private set; get; }

        /// <summary>
        /// 标准屏幕宽
        /// </summary>
        public int StandardWidth { private set; get; }
        
        /// <summary>
        /// 标准屏幕高
        /// </summary>
        public int StandardHeight { private set; get; }

        /// <summary>
        /// UI宽
        /// </summary>
        [HideInInspector]
        public float UIWidth;
        
        /// <summary>
        /// UI高
        /// </summary>
        [HideInInspector]
        public float UIHeight;
        
        /// <summary>
        /// 标准屏幕比例（高/宽）
        /// </summary>
        public float StandardVerticalRatio { private set; get; }
        
        /// <summary>
        /// 标准屏幕比例（高/宽）
        /// </summary>
        public float StandardHorizontalRatio { private set; get; }

        protected override void Awake()
        {
            base.Awake();
            CanvasScaler canvasScaler = m_UIRoot.GetComponent<CanvasScaler>();
            this.StandardWidth = (int)canvasScaler.referenceResolution.x;
            this.StandardHeight = (int)canvasScaler.referenceResolution.y;
            this.StandardVerticalRatio = 1f * this.StandardHeight / this.StandardWidth;
            this.StandardHorizontalRatio = 1f * this.StandardWidth / this.StandardHeight;
            this.Width = Screen.width;
            this.Height = Screen.height;
            Log.Info(Utility.Text.Format("设置屏幕宽:{0} ,高:{1} .", this.Width, this.Height));
            this.SafeArea = Screen.safeArea;
            Log.Info(Utility.Text.Format("设置屏幕安全区域 x:{0} ,y:{1} ,width:{2} ,height:{3} .", this.SafeArea.x, this.SafeArea.y, this.SafeArea.width, this.SafeArea.height));
            float ratio = SafeArea.height / SafeArea.width;
            canvasScaler.referenceResolution = new Vector2(this.StandardWidth, this.StandardHeight);
            canvasScaler.matchWidthOrHeight = ratio > StandardVerticalRatio ? 0 : 1;
            Canvas.ForceUpdateCanvases();
            RectTransform rectTransform = m_UIRoot.GetComponent<RectTransform>();
            this.UIWidth = rectTransform.sizeDelta.x;
            this.UIHeight = rectTransform.sizeDelta.y;
        }

        /// <summary>
        /// 设置屏幕数据
        /// </summary>
        /// <param name="width">屏幕宽</param>
        /// <param name="height">屏幕高</param>
        /// <param name="safeArea">屏幕的安全区域</param>
        private void Set(int width, int height, Rect safeArea)
        {
            
            AdjustCanvasScaler();
        }

        private void AdjustCanvasScaler()
        {
            
        }
    }
}