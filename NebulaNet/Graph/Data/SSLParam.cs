using System;
using System.Collections.Generic;
using System.Text;

namespace NebulaNet.Graph.Data
{
    public abstract class SSLParam
    {
        public enum SignMode
        {
            NONE,
            SELF_SIGNED,
            CA_SIGNED
        }

        private SignMode signMode;

        public SSLParam(SignMode signMode)
        {
            this.signMode = signMode;
        }

        public SignMode getSignMode()
        {
            return signMode;
        }
    }
}