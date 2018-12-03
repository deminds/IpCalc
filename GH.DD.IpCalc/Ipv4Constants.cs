namespace GH.DD.IpCalc
{
    public class Ipv4Constants
    {
        public const int OctetMinVal = 0;
        public const int OctetMaxVal = 255;
        public const int OctetBinLength = 8;

        public const char OctetSeparator = '.';
        public const int OctetsCount = 4;

        public const int MaskMinLength = 0;
        public const int MaskMaxLength = 32;

        public static readonly int[] ValidMaskOctets = {0, 128, 192, 224, 240, 248, 252, 254, 255};
    }
}