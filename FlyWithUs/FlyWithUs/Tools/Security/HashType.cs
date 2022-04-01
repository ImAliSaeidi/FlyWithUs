using System.ComponentModel;

namespace FlyWithUs.Hosted.Service.Tools.Security
{
    public enum HashType
    {
        [Description("MD5 Hashing")]
        MD5,
        [Description("SHA1 Hashing")]
        SHA1,
        [Description("SHA256 Hashing")]
        SHA256,
        [Description("SHA384 Hashing")]
        SHA384,
        [Description("SHA512 Hashing")]
        SHA512
    }
}
