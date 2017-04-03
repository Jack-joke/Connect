using Com.Inscripts.Interfaces;
using System;

namespace MessageSDKTest.Droid
{
    public class MyCallback : Java.Lang.Object, ICallbacks
    {
        Action<Org.Json.JSONObject> _onSuccess;
        Action<Org.Json.JSONObject> _onFail;

        public MyCallback(Action<Org.Json.JSONObject> onSuccess, Action<Org.Json.JSONObject> onFail = null)
        {
            this._onFail = onFail;
            this._onSuccess = onSuccess;
        }

        public void FailCallback(Org.Json.JSONObject p0)
        {
            this._onFail?.Invoke(p0);
        }
        public void SuccessCallback(Org.Json.JSONObject p0)
        {
            this._onSuccess?.Invoke(p0);
        }

    }
    
}
