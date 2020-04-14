using System;
using System.Collections.Generic;
using System.Text;

namespace AuthentValitor.ICommon
{
    public interface IWeChatAppDecrypt
    {
        string GetOpenIdAndSessionKeyString(string code);
    }
}
