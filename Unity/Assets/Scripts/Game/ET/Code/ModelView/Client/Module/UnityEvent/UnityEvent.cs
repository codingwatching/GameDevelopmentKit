namespace ET.Client
{
    [Invoke]
    public class UnityOnApplicationPauseHandler : AInvokeHandler<EventType.OnApplicationPause>
    {
        public override void Handle(EventType.OnApplicationPause arg)
        {
            if (Root.Instance != null)
            {
                EventSystem.Instance.Publish(Root.Instance.Scene, arg);
            }
        }
    }
    
    [Invoke]
    public class UnityOnApplicationFocusHandler : AInvokeHandler<EventType.OnApplicationFocus>
    {
        public override void Handle(EventType.OnApplicationFocus arg)
        {
            if (Root.Instance != null)
            {
                EventSystem.Instance.Publish(Root.Instance.Scene, arg);
            }
        }
    }
    
    [Invoke]
    public class UnityOnShutDownHandler : AInvokeHandler<EventType.OnApplicationQuit>
    {
        public override void Handle(EventType.OnApplicationQuit arg)
        {
            if (Root.Instance != null)
            {
                EventSystem.Instance.Publish(Root.Instance.Scene, arg);
            }
        }
    }
}