using System;
using System.Linq;
using System.Text;

namespace GH.DD.IpCalc
{
    public class Mask : Ip
    {
        public int MaskLength { private set; get; }
        
        public Mask(int[] octets) : base(octets)
        {
            if (!IsValid())
                throw new FormatException($"Error parsed mask is not valid. Raw octets: {octets}");

            MaskLength = CalcMaskLength();
        }

        private int CalcMaskLength()
        {
            var binMaskBuf = new StringBuilder(Ipv4Constants.MaskMaxLength);
            foreach (var octetBin in OctetsBin)
                binMaskBuf.Append(octetBin);

            var binMask = binMaskBuf.ToString();

            var binMaksOnes = binMask.Replace("0", string.Empty);

            return binMaksOnes.Length;
        }

        private bool IsValid()
        {
            var binMaskBuf = new StringBuilder(Ipv4Constants.MaskMaxLength);
            foreach (var octetBin in OctetsBin)
                binMaskBuf.Append(octetBin);

            var binMask = binMaskBuf.ToString();

            var binMaksOnes = binMask.Replace("0", string.Empty);

            if (binMask.StartsWith(binMaksOnes))
                return true;
            
            return false;
        }
        
        private bool IsValidByEachOctet()
        {
            if (Octets.Length != Ipv4Constants.OctetsCount)
                throw new FormatException($"Error {Octets}. Octets count != {Ipv4Constants.OctetsCount}");

            var lastOctetMax = true;
            foreach (var octet in Octets)
            {
                if (!lastOctetMax && octet != Ipv4Constants.OctetMinVal)
                    return false;

                if (!IsValidOctet(octet))
                    return false;
                
                if (octet != Ipv4Constants.OctetMaxVal)
                    lastOctetMax = false;
            }

            return true;
        }
        
        private bool IsValidOctet(int octet)
        {
            return Ipv4Constants.ValidMaskOctets.Contains(octet);
        }
    }
}