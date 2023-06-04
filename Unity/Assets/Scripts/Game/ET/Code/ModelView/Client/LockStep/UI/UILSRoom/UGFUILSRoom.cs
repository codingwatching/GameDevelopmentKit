using UnityEngine;

namespace ET.Client
{
    [EnableMethod]
    [ComponentOf(typeof (UGFUIForm))]
    public partial class UGFUILSRoom: Entity, IAwake<Transform>, IDestroy
    {
        public int frame;
        public int predictFrame;
    }
}
